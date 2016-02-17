using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.FtpUserIsolation.FtpUserIsolationServiceHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Uri httpUrl = new Uri("http://localhost:8091/FtpUserIsolationService");
                WebServiceHost host = new WebServiceHost(typeof(MicroServices.FtpUserIsolation.FtpUserIsolationService.FtpUserIsolationService), httpUrl);
                host.Open();

                foreach (ServiceEndpoint se in host.Description.Endpoints)
                Console.WriteLine("Service is host with endpoint " + se.Address);
                //Console.WriteLine("ASP.Net : " + ServiceHostingEnvironment.AspNetCompatibilityEnabled);
                Console.WriteLine("Host is running... Press <Enter> key to stop");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
