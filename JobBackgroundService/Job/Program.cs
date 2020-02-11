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
                Console.WriteLine("Job service is started...");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch ( Exception ex)
            {
                Console.WriteLine("Job service is stopped by an Exception...", ex);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder<StartUp>(args);
    }
}
