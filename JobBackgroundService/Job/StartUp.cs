using Job.Context;
using Job.Middleware;
using Job.Service;
using Job.YaHttpClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Job
{
    public class StartUp
    {
        public readonly IHostingEnvironment Environment;
        public IConfiguration Configuration { get; private set; }
        public StartUp(IConfiguration configuration, IHostingEnvironment environment)
        {
            Environment = environment;
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<JobService>();

            services.AddEntityFrameworkSqlServer().AddDbContext<DBLocalContext>();

            services.AddTransient<CheckHeaderHandler>();
            services.AddHttpClient("YandexWeather").AddHttpMessageHandler<CheckHeaderHandler>();
            services.AddTransient<YandexHttpClient>();
        }

        public void Configure(IApplicationBuilder app) { }
    }
}
