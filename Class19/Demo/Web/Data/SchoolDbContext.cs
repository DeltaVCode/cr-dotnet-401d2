using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class SchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // We have to have this because IdentityDbContext uses it
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>()
                .HasKey(enrollment => new // anonymous type, similar to JS { }
                {
                    enrollment.CourseId,
                    enrollment.StudentId,
                });

            modelBuilder.Entity<Transcript>()
                .HasKey(transcript => new
                {
                    transcript.StudentId,
                    transcript.CourseId,
                });

            modelBuilder.Entity<Technology>()
                .HasData(
                    new Technology { Id = 1, Name = ".NET Core" },
                    new Technology { Id = 2, Name = "Node.js" }
                );

            SeedRole(modelBuilder, "Administrator", "create", "update", "delete");
            SeedRole(modelBuilder, "Editor", "create", "update");
            SeedRole(modelBuilder, "Student");
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }

        // There should be a Students table with Student records in it
        public DbSet<Student> Students { get; set; }

        public DbSet<Technology> Technologies { get; set; }

        private int nextRoleClaimId = 1;

        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString(),
            };
            modelBuilder.Entity<IdentityRole>()
                .HasData(role);

            var roleClaims = permissions
                .Select(permission =>
                    new IdentityRoleClaim<string>
                    {
                        Id = nextRoleClaimId++,
                        RoleId = role.Id,
                        ClaimType = "permissions",
                        ClaimValue = permission,
                    })
                .ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .HasData(roleClaims);
        }
    }
}