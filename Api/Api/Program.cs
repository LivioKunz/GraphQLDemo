using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var directory = Directory.GetCurrentDirectory();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(directory)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        
    }
}
