using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Motorola.MotoTaxi.Orders.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        // https://codingblast.com/asp-net-core-configuration/
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(ConfigureConfiguration)
                .UseStartup<Startup>();



        private static void ConfigureConfiguration(
            WebHostBuilderContext context, 
            IConfigurationBuilder config)
        {

            var env = context.HostingEnvironment;

            // Trace.WriteLine(context.HostingEnvironment.EnvironmentName);

            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            config.AddXmlFile("appsettings.xml", optional: false, reloadOnChange: true);
            config.AddXmlFile($"appsettings.{env.EnvironmentName}.xml", optional: true, reloadOnChange: true);


        }
    }
}
