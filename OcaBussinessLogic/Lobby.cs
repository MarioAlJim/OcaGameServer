using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcaBussinessLogic
{
    internal class Lobby
    {
        private string[] usersInLobby;
        private int numUsers = 0;
        private int maxUsers;

        public Lobby(int maxUsers)
        {
            this.maxUsers = maxUsers ;
            usersInLobby = new string[maxUsers];
        }

        public int addUser(string newUser)
        {
            int result;
            if (numUsers < maxUsers)
            {
                usersInLobby[numUsers] = newUser;
                numUsers++;
                result = 1;
            } else
            {
                result = 0;
            }

            return result;
        }

        public int deleteUser(string deleteUser)
        {
            int result = 0;
            for (int i = 0; i <= numUsers; i++)
            {
                if (usersInLobby[i] == deleteUser)
                {
                    usersInLobby[i] = "";
                    result = 1;
                }
            }
            return result;
        }
    }
}
