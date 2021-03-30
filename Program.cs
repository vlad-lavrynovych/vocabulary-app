using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app
{
    //The host is typically configured, built, and run by code in the Program class.
    public class Program
    {
        //The Main method:
        //Calls a CreateHostBuilder method to create and configure a builder object.
        //Calls Build and Run methods on the builder object.
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // For an HTTP workload , web templates generate the following code to create a host
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
