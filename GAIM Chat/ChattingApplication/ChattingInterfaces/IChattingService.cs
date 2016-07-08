using System.ServiceModel;

namespace ChattingInterface
{
    [ServiceContract(CallbackContract = typeof(IClient))]
    public interface IChattingService
    {
        [OperationContract]
        int Login(string userName);

        [OperationContract]
        void SendMessageToAll(string message, string userName);
    }
}
