using System.ServiceModel;

namespace OcaGameWCF
{
    [ServiceContract]
    public interface IChatClient
    {
        [OperationContract(IsOneWay = true)]
        void RecieveMessage(string message);
    }

    [ServiceContract(CallbackContract = typeof(IChatClient))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Join(string nickname);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, string identifier);
    }
}
