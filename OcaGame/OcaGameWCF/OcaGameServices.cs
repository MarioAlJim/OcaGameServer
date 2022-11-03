using OcaBussinessLogic;
using OcaDataAccess;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OcaGameWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public partial class OcaGameServices : IAuthentication
    {
        public User login(string userName, string password)
        {
            Authentication ocaGameServices = new Authentication();
            OcaDataAccess.Users userAcount = ocaGameServices.login(userName, password);
            User user = new User();
            if (userAcount.Nickname != null)
            {
                user.Nickname = userAcount.Nickname;
                user.Surname = userAcount.Surname;
                user.IdUser = userAcount.IdUser;
                user.Online = userAcount.Online;
                user.Experience = userAcount.Experience;
                user.Name = userAcount.Name;
                user.Email = userAcount.Email;
                user.Valid = userAcount.Valid;
                user.Password = userAcount.Password;
            }
            return user;
        }
    }

    public partial class OcaGameServices : IChatService
    {
        int nextId = 1;
        ConcurrentDictionary<String, OperationContext> UsersChat = new ConcurrentDictionary<String, OperationContext>();
        public void Join(string nickname)
        {
            this.UsersChat.TryAdd(nickname, OperationContext.Current);
        }

        public void SendMessage(string message, string identifier)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            foreach (var item in UsersChat)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var user = UsersChat.FirstOrDefault(i => i.Key == identifier);

                answer += ": " + user.Key + " " + message;
                item.Value.GetCallbackChannel<IChatClient>().RecieveMessage(answer);
            }

        }
    }

}