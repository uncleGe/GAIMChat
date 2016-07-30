using ChattingInterface;
using System.Collections.Concurrent;
using System.ServiceModel;
using System;
using System.Collections.Generic;

namespace ChattingServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class ChattingService : IChattingService
    {
        // Concurrent is threadsafe for multi-threaded server
        // Contains all current users on service
        public ConcurrentDictionary<string, ConnectedClient> _connectedClients = new ConcurrentDictionary<string, ConnectedClient>();

        public int Login(string userName)
        {
            // Checks duplicate userNames
            foreach(var client in _connectedClients)
            {
                if(client.Key.ToLower() == userName.ToLower())
                {
                    // Message "You're already logged in"
                    return 1;
                }
            }

            if (userName.Length == 0)
            {
                return 2;
            }

            // Gets and stores current calling user's callback channel 
            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();

            ConnectedClient newClient = new ConnectedClient();
            newClient.connection = establishedUserConnection;
            newClient.UserName = userName;

            _connectedClients.TryAdd(userName, newClient);

            UpdateHelper(0, userName);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Client login: {0} at {1}", newClient.UserName, DateTime.Now);
            Console.ResetColor();

            return 0;
        }

        public void Logout()
        {
            ConnectedClient client = GetMyClient();
            
            ConnectedClient removedClient;
            _connectedClients.TryRemove(client.UserName, out removedClient);

            UpdateHelper(1, removedClient.UserName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Client logout: {0} at {1}", removedClient.UserName, DateTime.Now);
            Console.ResetColor();
            
        }

        public ConnectedClient GetMyClient()
        {
            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();
            
            foreach(var client in _connectedClients)
            {
                if(client.Value.connection == establishedUserConnection)
                {
                    return client.Value;
                }
            }
            return null;
        }

        private void UpdateHelper(int value, string userName)
        {
            foreach (var client in _connectedClients)
            {
                if (client.Value.UserName.ToLower() != userName.ToLower())
                {
                    client.Value.connection.GetUpdate(value, userName);
                }
            }
        }

        // Client calls SendMessageToALL()
        public void SendMessageToAll(string message, string userName)
        {
            foreach (var client in _connectedClients)
            {
                if (client.Key.ToLower() != userName.ToLower())
                {
                    // Get message from the connected client's client interface
                    client.Value.connection.GetMessage(message, userName);
                }
            }
        }

        public List<string> GetCurrentUsers()
        {
            List<string> listOfUsers = new List<string>();
            foreach (var client in _connectedClients)
            {
                listOfUsers.Add(client.Value.UserName);
            }
            return listOfUsers;
        }
    }
}
