using ChattingInterface;
using System.Collections.Concurrent;
using System.ServiceModel;

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
             
            return 0;
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
    }
}
