using OcaDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcaBussinessLogic
{
    public class UsersAdministration
    {

        public Boolean SignUpUser(string nickname, string password)
        {
            Console.WriteLine("*** Add User Starts ***");

            using (var context = new OcaDBEntities())
            {
                //Log DB commands to console
                context.Database.Log = Console.WriteLine;

                //Add a new student and address
                var newStudent = context.Users.Add(new User() { Nickname = nickname, Password = password });
                context.SaveChanges(); // Executes Insert command
                Console.WriteLine("*** Add User Succes");

            }

            return true;
        }


    }
}
