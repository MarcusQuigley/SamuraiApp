using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SamuraiApp.Domain;
using System;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        readonly string _connectionString = "Server=DESKTOP-EJI49CF; Database=SamuraiAppData;Trusted_Connection =True;";
        // "Server = (localdb)\\mssqllocaldb; Database=SamuraiAppData;Trusted_Connection = True;";

        //Data Source=DESKTOP-EJI49CF;Initial Catalog=AdventureWorks2012;Integrated Security=True;
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quote { get; set; }
        public DbSet<Battle> Battle { get; set; }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddConsole()
                                                           .AddFilter(DbLoggerCategory.Database.Command.Name,
                                                                      LogLevel.Information));
            return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(GetLoggerFactory())
                .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.SamuraiId, s.BattleId });
        }
    }
}
