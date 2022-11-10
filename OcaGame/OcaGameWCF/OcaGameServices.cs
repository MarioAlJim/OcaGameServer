using OcaBussinessLogic;
using OcaDataAccess;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows;

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

    public partial class OcaGameServices : IEmail
    {
        public int send(string receiver)
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
    }


}