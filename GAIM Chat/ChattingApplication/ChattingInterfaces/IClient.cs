using System.ServiceModel;

namespace ChattingInterface
{
    // Service calls on client
    public interface IClient
    {
        [OperationContract]
        void GetMessage(string message, string userName);

    }
}
