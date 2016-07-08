using System;
using System.ServiceModel;

namespace ChattingServer
{
    class Program
    {
        public static ChattingService _server;
        static void Main(string[] args)
        {
            _server = new ChattingService();
            {
                using (ServiceHost host = new ServiceHost(_server))
                {
                    host.Open();
                    Console.WriteLine("Server is running...");
                    Console.ReadLine();
                }
            }           
        }
    }
}
