using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcaBussinessLogic
{

    public sealed class LobbysList
    {
        private LobbysList()
        {
        }
        private static LobbysList _instance;

        public int[] lobbys = new int[6];
        private int numLobby = 0;

        public static LobbysList GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LobbysList();
            }
            return _instance;
        }

        public void addLobby(int code)
        {
            lobbys[numLobby] = nickname;
        }

        public void deleteLobby(string nickname)
        {
            for (int i = 0; i < numUsers; i++)
            {
                if (nickname == usersInLobby[i])
                {
                    lobbys[i] = 0;
                }

            }
            Array.Sort(lobbys);
        }
    }
}
