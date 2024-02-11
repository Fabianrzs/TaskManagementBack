using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastruture.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<SampleEntity> Samples { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
