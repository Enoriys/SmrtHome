using DevicesController.Controller;
using DevicesController.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmrtHomeService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HomeService.SmartHomeService)))
            {
                host.Open();
                Console.WriteLine("Host started @ "+DateTime.Now.ToString());
                Console.ReadLine();
            }
        }

    }
}
