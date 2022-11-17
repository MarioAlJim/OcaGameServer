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
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
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
        public Boolean SignUp(string nickname, string password)
        {
            OcaBussinessLogic.UsersAdministration users = new OcaBussinessLogic.UsersAdministration();
            Boolean sucess = false;
            sucess = users.SignUpUser(nickname, password);
            return sucess;

        }
    }

    public partial class OcaGameServices : IChatService
    {
        ConcurrentDictionary<String, OperationContext> UsersChat = new ConcurrentDictionary<String, OperationContext>();
        public void Join(string nickname)
        {
            this.UsersChat.TryAdd(nickname, OperationContext.Current);
        }

        public void SendMessage(string message, string identifier)
        {
           // var connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            foreach (var item in UsersChat)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var user = UsersChat.FirstOrDefault(i => i.Key == identifier);

                answer += ": " + user.Key + " " + message;
                item.Value.GetCallbackChannel<IChatClient>().RecieveMessage(answer);
            }

        }
    }

    public partial class OcaGameServices : IGameServices
    {
        ConcurrentDictionary<int, CallbackGameService> lobbys = new ConcurrentDictionary<int, CallbackGameService>();
        ConcurrentDictionary<string, CallbackGameService> usersGame = new ConcurrentDictionary<string, CallbackGameService>();
        private void createLobby (int code)
        {
            CallbackGameService gameCallbackService = new CallbackGameService();
            lobbys.TryAdd(code, gameCallbackService);
        }

        public void AddMeToGame(string nickname, int code)
        { 
            bool joinResult = false;
            usersGame.TryAdd(nickname, OperationContext.Current);
            try
            {

                CallbackGameService callback = lobbys[code];
                callback.NewUserInLobby(nickname);
            }
            // catches an issue with a user disconnect and loggs off that user
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return;
        }

        public Game CreateGame(Game game)
        {
            Random random = new Random();
            int code = random.Next(100000, 200000);
            game.Code = code;
            createLobby (code);
            return game;
        }

        public bool LeaveGame(string userName)
        {
            return true;
        }

    }
    
    public partial class OcaGameServices : IEmail
    {
        public int sendEmail(string receiver)
        {
            Random random = new Random();
            int number = random.Next(1000, 100000);

            MailMessage message = new MailMessage();

            String from = "OcaGameServices@hotmail.com";

            message.From = new MailAddress(from, "OcaGameServices");
            message.To.Add(receiver);
            message.Subject = "Correo de verificacion";
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = "El codigo de verificacion para el cambio de contraseña es: " + number + " regrese al juego e ingreselo";
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            smtp.Credentials = new NetworkCredential(from, "Ocagameadmin$");
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(message);
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede enviar el correo de verificacion, revise el correo ingresado");
                number = 0;
            }

            return number;
        }

        public User GetUserFromEmail(string email)
        {
            UsersAdministration ocaGameServices = new UsersAdministration();
            OcaDataAccess.Users userAccount = ocaGameServices.GetUserFromEmail(email);
            User user = new User();
            if (userAccount.Nickname != null)
            {
                user.Nickname = userAccount.Nickname;
                user.IdUser = userAccount.IdUser;
                user.Name = userAccount.Name;
                user.Email = userAccount.Email;
                user.Valid = userAccount.Valid;
                user.Password = userAccount.Password;
            }
            return user;
        }

        public bool UpdatePassword(User user)
        {

            OcaDataAccess.Users userData = new OcaDataAccess.Users();
            bool result = false;
            UsersAdministration ocaGameServices = new UsersAdministration();
            userData.Nickname = user.Nickname;
            userData.IdUser = user.IdUser;
            userData.Name = user.Name;
            userData.Email = user.Email;
            userData.Valid = user.Valid;
            userData.Password = user.Password;
            result = ocaGameServices.UpdatePassword(userData);
            return result;
        }
    }

}
