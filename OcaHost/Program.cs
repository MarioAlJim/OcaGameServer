using OcaGameWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OcaHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost clientHost = new ServiceHost(typeof(OcaGameServices));
                clientHost.Open();
                ServiceHost hostAdmin = new ServiceHost(typeof(ReportsServices));
                hostAdmin.Open();

                Console.WriteLine("Server is running");
                Console.WriteLine("Press <ENTER> to quit.");
                Console.ReadLine();
                hostAdmin.Open();
                clientHost.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.WriteLine("Press <ENTER> to quit.");
                Console.ReadLine();
            }
        }
    }
}
