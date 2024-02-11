using Domain.Entities;
using Domain.Repositories;
using Infrastruture.Context;

namespace Infrastruture.Repositories
{
    public class CollaboratorRepository : GenericRepository<Collaborator>, ICollaboratorRepository
    {
        public CollaboratorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
