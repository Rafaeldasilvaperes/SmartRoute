using Microsoft.EntityFrameworkCore;
using SmartRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Infrastructure.Persistence
{
    public class SmartRouteDbContext : DbContext
    {
        public SmartRouteDbContext(DbContextOptions<SmartRouteDbContext> options)
        : base(options) { }

        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id)
                      .HasDefaultValueSql("NEWSEQUENTIALID()");
            });
        }
    }
}
