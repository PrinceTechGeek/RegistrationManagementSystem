using Microsoft.EntityFrameworkCore;
using EventRegistrationSystem.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EventRegistrationSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().HasKey(r => r.RegistrationId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
