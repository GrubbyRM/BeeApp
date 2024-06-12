using BeeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Infrastructure.Persistence
{
    public class BeeAppDbContext : DbContext
    {
        public BeeAppDbContext(DbContextOptions<BeeAppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Domain.Entities.Inspection> Inspections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Inspection>()
                .OwnsOne(c => c.BeehiveDetails);
        }
    }
}
