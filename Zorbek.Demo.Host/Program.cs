using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Demo.WebApi;

namespace Zorbek.Demo.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/api/";

            // Start OWIN host 
            using (WebApp.Start(baseAddress, (appBuilder) => new Startup(new KernelFactory()).Configuration(appBuilder)))
            {
                Console.WriteLine("Server running at {0} - press Enter to quit. ", baseAddress);
                Console.ReadLine();
            }
        }
    }
}
