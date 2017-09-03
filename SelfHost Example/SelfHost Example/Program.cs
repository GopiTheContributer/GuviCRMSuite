using System;
using Microsoft.Owin.Hosting;

namespace GuviCRMSuite
{
    class Program
    {
        static void Main()
        {
            const string URL = "http://localhost:12681";
            using (WebApp.Start<Startup>(URL))
            {
                Console.WriteLine("Web Server is running on: " + URL + "\n Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
}