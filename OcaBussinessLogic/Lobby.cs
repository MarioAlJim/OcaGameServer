using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcaBussinessLogic
{
    public class Lobby
    {
        public string[] usersInLobby = new string[6];
        private int numUsers = 0;

        public void addUser(string nickname)
        {
            usersInLobby[numUsers] = nickname;
        }

        public void deleteUser(string nickname)
        {
            for (int i = 0; i < numUsers) 
        }
    }
}
