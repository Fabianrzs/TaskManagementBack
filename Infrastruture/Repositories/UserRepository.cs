using Domain.Entities;
using Domain.Repositories;
using Infrastruture.Context;

namespace Infrastruture.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
