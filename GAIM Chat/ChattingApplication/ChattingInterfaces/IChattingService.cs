using System.Collections.Generic;
using System.ServiceModel;

namespace ChattingInterface
{
    [ServiceContract(CallbackContract = typeof(IClient))]
    public interface IChattingService
    {
        [OperationContract]
        int Login(string userName);

        [OperationContract]
        void Logout();

        [OperationContract]
        void SendMessageToAll(string message, string userName);

        [OperationContract]
        List<string> GetCurrentUsers();
    }
}
