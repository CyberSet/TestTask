using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Data
{
    public class citizensContext : DbContext
    {
        public citizensContext(DbContextOptions<citizensContext> options) : base(options)
        {
        }
        public DbSet<citizens> Citizens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<citizens>().ToTable("Citizens");
        }
    }
}
