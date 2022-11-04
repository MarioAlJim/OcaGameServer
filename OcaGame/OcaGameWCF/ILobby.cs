using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OcaGameWCF
{
    [ServiceContract]
    public interface ILobbyClient
    {
        [OperationContract(IsOneWay = true)]
        void FriendsList(string message);



    }

    [ServiceContract(CallbackContract = typeof(ILobbyClient))]
    public interface ILobbyService
    {
        [OperationContract(IsOneWay = true)]
        void JoinLobby(string nickname);

        [OperationContract(IsOneWay = true)]
        void Disconnect();




    }
}
