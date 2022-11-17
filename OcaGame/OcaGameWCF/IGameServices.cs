using System.Runtime.Serialization;
using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcaGameWCF
{
    [ServiceContract]
    public interface IGameServiceClient
    {
        [OperationContract(IsOneWay = true)]
        void NewUserInLobby(string nickname);

        [OperationContract(IsOneWay = true)]
        void RecieveStartGame(int startGame);
    }
    [ServiceContract(CallbackContract = typeof(IGameServiceClient))]

    public interface IGameServices
    {
        [OperationContract]
        Game CreateGame(Game game);

        [OperationContract]
        void AddMeToGame(string userName, int code);

        [OperationContract]
        bool LeaveGame(string userName);
    } 

    [DataContract]
    public class Game
    {
        [DataMember]
        public int NumberOfPlayers { get; set; }
        [DataMember]
        public int TurnTime { get; set; }
        [DataMember]
        public int Background { get; set; }
        [DataMember]
        public int Code { get; set; }
    }
}
