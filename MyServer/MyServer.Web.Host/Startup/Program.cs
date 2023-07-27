using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MyServer.Web.Host.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory;
            System.IO.Directory.SetCurrentDirectory(path);
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
