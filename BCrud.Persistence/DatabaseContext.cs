using BCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext()
        {

        }

        public DbSet<Trade> Trades { get; set; }

        public DbSet<TradeLevel> TradeLevels { get; set; }

        public DbSet<Syllabus> Syllabi { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-O2E45CT;Database=BCrudDb;Trusted_Connection=True;user id=sa;password=1234;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
