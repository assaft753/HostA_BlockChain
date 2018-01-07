using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HostAServerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HostA.HostAServices)))
            {
                host.Open();
                Console.WriteLine("Host A Started");
                Console.ReadLine();
            }
        }
    }
}
