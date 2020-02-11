using System;
using System.Collections.Generic;
using System.Text;
using Job.DBModel;
using Job.Helper;
using Job.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Job.Context
{
    public class DBLocalContext : DbContext
    {
        public readonly AppSettings _settings;
        public DBLocalContext(DbContextOptions<DBLocalContext> options, IConfiguration opt) : base(options)
        {
            _settings = ConfigurationHelper.GetAppSettings(opt);
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if ( !optionsBuilder.IsConfigured )
            {
                if ( _settings.db.ConnectionString is null )
                {
                    throw new ArgumentNullException("ConnectionString");
                }

                optionsBuilder.UseSqlServer(_settings.db.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Place>().HasData(
                //Инициализация координатами г. Москва
                new List<Place>() {new Place() {
                    Id = 1,
                    Latitude = 55.751379,
                    Longitude = 37.618853
                } });
        }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
