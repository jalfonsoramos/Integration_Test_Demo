using Microsoft.Owin.Hosting;
using System;
using Zorbek.Demo.Host.Dependencies;
using Zorbek.Demo.WebApi;

namespace Zorbek.Demo.Host
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host
            using (WebApp.Start(baseAddress, (appBuilder) => new Startup(new NinjectConfig()).Configuration(appBuilder)))
            {
                Console.WriteLine("Server running at {0} - press Enter to quit. ", baseAddress);
                Console.ReadLine();
            }
        }
    }
}