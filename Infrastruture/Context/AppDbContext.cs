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
    }
}
