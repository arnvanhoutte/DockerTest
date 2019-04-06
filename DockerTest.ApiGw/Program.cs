using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace DockerTest.ApiGw
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Gateway app building");
            var sw = new Stopwatch();
            sw.Start();
            var build = CreateWebHostBuilder(args).Build();
            sw.Stop();
            Console.WriteLine("Gateway app running: " + sw.ElapsedMilliseconds);
            build.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, config) => config.AddJsonFile("configuration.json", optional: false, reloadOnChange: false))
                .UseStartup<Startup>();
    }
}
