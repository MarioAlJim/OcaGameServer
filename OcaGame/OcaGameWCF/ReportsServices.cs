using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcaGameWCF
{
    public partial class ReportsServices : IReports
    {
        public List<Reports> getReports()
        {
            OcaBussinessLogic.ReportsAdministration reportsAdministration = new OcaBussinessLogic.ReportsAdministration();
            List<OcaDataAccess.Reports> list = new List<OcaDataAccess.Reports>();
            List<Reports> listConverted = new List<Reports>();
            list = reportsAdministration.getUsersReports();
            foreach (var reportSelected in list)
            {
                Reports report = new Reports();
                report.typeReport = reportSelected.typeReport;
                report.IdReport = reportSelected.IdReport;
                report.IdUser = reportSelected.IdUser;
                listConverted.Add(report);
            }
            return listConverted;
        }
    }
}
