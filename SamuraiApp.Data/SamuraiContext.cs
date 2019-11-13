using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Data
{
   public class SamuraiContext: DbContext
    {
        readonly string _connectionString = "Server = (localdb)\\mssqllocaldb; Database=SamuraiAppData;Trusted_Connection = True;";
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quote { get; set; }
        public DbSet<Battle> Battle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
