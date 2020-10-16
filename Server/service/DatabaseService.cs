﻿using Microsoft.EntityFrameworkCore;
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
                .UseNpgsql(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Value>().HasNoKey();
        }

        public void InsertValues(IList<Value> batch)
        {
            if (batch.Count == 0) return;
            
            var values = String.Join(',', batch.Select(x => string.Format(CultureInfo.InvariantCulture, "({0},'{1:o}',{2:0.00000})", x.device, x.time, x.val)));
            Database.ExecuteSqlRaw(string.Format("INSERT INTO measure(device, time, val) VALUES {0};", values));
        }

        public List<Value> SelectValues(int id, DateTime from, DateTime to)
        {
            return Value.FromSqlRaw("SELECT * FROM measure WHERE device={0} AND (time BETWEEN {1} AND {2}) ORDER BY time", id, from, to).ToList();
        }

        public IQueryable<Device> GetDeviceFull()
        {
            var sql = @"
WITH dev AS (
    select d.id, name, enable, removed, camera, type, description, version, stand_id, siren,
           d.config || json_object_agg(m.field, json_build_object('sn', m.sn, 'num', m.num, 'index', m.ch - 1, 'cfg', m.cfg))::jsonb as config
    from ltr_device m,
         device d
    where m.device = d.id
    group by d.id
)
select d.id, name, enable, removed, camera, type, description, version, stand_id, siren, 
       d.config || json_build_object('siren', json_build_object('sn', m.sn, 'num', m.num, 'index', m.ch - 1))::jsonb as config
from dev d,
     ltr_device m
where d.siren = m.device
order by d.id;
";
            return Device.FromSqlRaw(sql);
        }
    }
}
