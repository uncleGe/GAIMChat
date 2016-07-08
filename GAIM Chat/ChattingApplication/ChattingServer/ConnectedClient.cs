using ChattingInterface;

namespace ChattingServer
{
    public class ConnectedClient
    {
        public IClient connection;
        public string UserName { get; set; }
    }
}
