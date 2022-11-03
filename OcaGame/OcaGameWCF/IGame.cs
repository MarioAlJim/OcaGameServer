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
        int CreateGame(Game game);
        int StartGame();
    }

    [DataContract]
    public class Game
    {
        [DataMember]
        public int numberOfPlayers { get; set; }
        [DataMember]
        public string turnTime { get; set; }
        [DataMember]
        public int Background { get; set; }
        [DataMember]
        public string code { get; set; }
    }
}
