using BCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {

        private string connectionString;
        public DatabaseContext(string connectionString)
        {
            this.connectionString = connectionString;
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
            if (string.IsNullOrEmpty(this.connectionString))
                throw new Exception("Connection string cannot be null.");
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
    }
}
