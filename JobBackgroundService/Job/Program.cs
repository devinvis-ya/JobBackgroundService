using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Job
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Job service started...");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch ( Exception ex)
            {
                Console.WriteLine("Job service stoped...", ex);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<StartUp>();
    }
}
