using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;

namespace DockerTest.Blog
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Blog app building");
            var sw = new Stopwatch();
            sw.Start();
            var build = CreateWebHostBuilder(args).Build();
            sw.Stop();
            Console.WriteLine("Blog app running: " + sw.ElapsedMilliseconds);
            build.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
