using Domain.Entities;
using Domain.Repositories;
using Infrastruture.Context;

namespace Infrastruture.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
