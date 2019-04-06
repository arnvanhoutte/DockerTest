using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;

namespace DockerTest.FileUpload
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Upload app building");
            var sw = new Stopwatch();
            sw.Start();
            var build = CreateWebHostBuilder(args).Build();
            sw.Stop();
            Console.WriteLine("Upload app running: " + sw.ElapsedMilliseconds);
            build.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
