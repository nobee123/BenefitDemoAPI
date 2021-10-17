using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;

namespace BenefitCalculation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                            .UseStartup<Startup>()
                            .Build();
            return host;
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var host = new WebHostBuilder()
              .UseKestrel()
              .ConfigureServices(services => services.AddAutofac())

              // .UseCloudFoundryHosting()
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseIISIntegration()
              .ConfigureAppConfiguration((builderContext, config) =>
              {
                  config.SetBasePath(builderContext.HostingEnvironment.ContentRootPath)
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);                              
               })              
              .UseStartup<Startup>();

            return host;
        }
    }
}
 