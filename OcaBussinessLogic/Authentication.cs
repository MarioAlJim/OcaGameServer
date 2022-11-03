using OcaDataAccess;
using System;
using System.Linq;

namespace OcaBussinessLogic
{
    public class Authentication
    {
        public Authentication()
        {
        }

        public Users login(string userName, string password)
        {
            Users user = new Users();
            using (var context = new OcaDBEntities())
            {
                int userCont = (from Users in context.Users
                             where Users.Nickname == userName && Users.Password == password
                             select Users).Count();

                var users = (from Users in context.Users
                             where Users.Nickname == userName && Users.Password == password select Users).ToList();

                if (userCont > 0)
                {
                    user = users.First();
                }
                
            }
            return user;
        }



    }
}
