using Domain.Entities;
using Domain.Repositories;
using Infrastruture.Context;

namespace Infrastruture.Repositories
{
    public class CommentRepository : MongoGenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(MongoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
