using OcaDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcaBussinessLogic
{
    public class ReportsAdministration
    {

        public List<Reports> getUsersReports()
        {
            List<Reports> usersReports = new List<Reports>();
            using (var context = new OcaDBEntities())
            {
                usersReports = (from Reports in context.Reports select Reports).ToList();
            }
            return usersReports;
        }
    }
}
