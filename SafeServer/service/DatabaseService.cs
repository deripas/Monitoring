using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NLog.Extensions.Logging;
using SafeServer.dto;

namespace SafeServer.service
{
    public class DatabaseService : DbContext
    {
        public DbSet<Camera> Camera { get; set; }
        public DbSet<Nvr> Nvr { get; set; }
        public DbSet<Alert> Alert { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(new NLogLoggerFactory())
                .UseNpgsql("Server=127.0.0.1;Port=5432;Database=monitoring;User Id=postgres;Password=postgres;CommandTimeout=20;");
        }
    }
}
