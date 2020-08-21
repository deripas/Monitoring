using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NLog.Extensions.Logging;
using SafeServer.dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace SafeServer.service
{
    public class DatabaseService : DbContext
    {
        public DbSet<Camera> Camera { get; set; }
        public DbSet<Nvr> Nvr { get; set; }
        public DbSet<Alert> Alert { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Value> Value { get; set; }
        public DbSet<LTR> LTR { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = ConfigurationBinder.GetValue<string>(DI.Instance.Config, "Settings:DbConnection");
            optionsBuilder
                .UseLoggerFactory(new NLogLoggerFactory())
                .EnableSensitiveDataLogging()
                .UseNpgsql(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Value>().HasNoKey();
        }

        public void InsertValues(List<Value> batch)
        {
            if (batch.Count == 0) return;

            var values = String.Join(',', batch.Select(x => string.Format(CultureInfo.InvariantCulture, "({0},'{1:o}',{2:0.00})", x.device, x.time, x.val)));
            Database.ExecuteSqlRaw(string.Format("INSERT INTO measure(device, time, val) VALUES {0};", values));
        }

        public List<Value> SelectValues(int id, DateTime from, DateTime to)
        {
            return Value.FromSqlRaw("SELECT * FROM measure WHERE device={0} AND (time BETWEEN {1} AND {2}) ORDER BY time", id, from, to).ToList();
        }
    }
}
