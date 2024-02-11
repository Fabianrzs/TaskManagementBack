using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastruture.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<SampleEntity> Samples { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collaborator>()
                .HasKey(up => new { up.IdUser, up.IdProject });

            modelBuilder.Entity<Collaborator>()
                .HasOne(up => up.User)
                .WithMany(u => u.Collaborators)
                .HasForeignKey(up => up.IdUser);

            modelBuilder.Entity<Collaborator>()
                .HasOne(up => up.Project)
                .WithMany(p => p.Collaborators)
                .HasForeignKey(up => up.IdProject);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.IdProject);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Manage)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.IdManage);
        }
    }
}
