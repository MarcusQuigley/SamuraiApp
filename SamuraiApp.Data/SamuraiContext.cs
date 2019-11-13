using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;

namespace SamuraiApp.Data
{
    public class SamuraiContext :DbContext
    {
        readonly string _connectionString = "Server=DESKTOP-EJI49CF; Database=SamuraiAppData;Trusted_Connection =True;";
        // "Server = (localdb)\\mssqllocaldb; Database=SamuraiAppData;Trusted_Connection = True;";

        //Data Source=DESKTOP-EJI49CF;Initial Catalog=AdventureWorks2012;Integrated Security=True;
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quote { get; set; }
        public DbSet<Battle> Battle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
