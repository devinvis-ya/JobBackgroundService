﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Job.Context;
using Job.Service;
using Job.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Job
{
    public class StartUp
    {
        public IHostingEnvironment Environment { get; }
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

        }

        public void Configure(IApplicationBuilder app) { }
    }
}
