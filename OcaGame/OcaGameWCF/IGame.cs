using System.Runtime.Serialization;
using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcaGameWCF
{
    [ServiceContract]
    public interface IGame
    {
        [OperationContract]
        Game CreateGame(Game game);

        [OperationContract]
        int StartGame();
    }

    [DataContract]
    public class Game
    {
        [DataMember]
        public int NumberOfPlayers { get; set; }
        [DataMember]
        public string TurnTime { get; set; }
        [DataMember]
        public int Background { get; set; }
        [DataMember]
        public int Code { get; set; }
    }
}
