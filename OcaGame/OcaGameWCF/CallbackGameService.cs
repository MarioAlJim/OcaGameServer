using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcaGameWCF
{
    internal class CallbackGameService : IGameServiceClient
    {
        private readonly List<string> UsersInLobby;
        public void NewUserInLobby(string nickname)
        {
            this.UsersInLobby.Add(nickname);
        }

        public void RecieveStartGame(int startGame)
        {
            throw new NotImplementedException();
        }
        internal CallbackGameService()
        {
            this.UsersInLobby = new List<string>();
        }

        internal IList<string> Responses
        {
            get { return this.UsersInLobby; }
        }
    }
}
