using System;
using System.Diagnostics;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DockerTest.Client
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Web app building");
            var sw = new Stopwatch();
            sw.Start();
            var build = CreateWebHostBuilder(args).Build();
            sw.Stop();
            Console.WriteLine("Web app running: " + sw.ElapsedMilliseconds);
            build.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
