using Microsoft.EntityFrameworkCore;
using Tasky.Domain.Entities;
using Project = Tasky.Domain.Entities.Project;
using Task = Tasky.Domain.Entities.Task;

namespace Tasky.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMembership> ProjectMemberships { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectMembership>()
                .HasKey(pm => new { pm.ProjectId, pm.UserId });

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);

            modelBuilder.Entity<Project>()
                .Navigation(p => p.Tasks)
                .HasField("_tasks")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            modelBuilder.Entity<Task>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
