using BrainHub.DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BrainHub.DomainLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Sbu> Sbus { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CustomRole> CustomRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Configure Employee → IdentityUser one-to-one relationship
            builder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne() // IdentityUser<int> does not have navigation back
                .HasForeignKey<Employee>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Employee>()
                .HasOne(e => e.CustomRole)
                .WithMany()
                .HasForeignKey(e => e.CustomRoleId)
                .OnDelete(DeleteBehavior.Restrict);

            ApplicationDbContextSeeder.Seed(builder);
        }

        // Suppressing the warning
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
            );
        }
    }
}
