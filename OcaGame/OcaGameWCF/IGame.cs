using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OcaGameWCF
{
    internal interface IGame
    {
        Game CreateGame(Game game);
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
