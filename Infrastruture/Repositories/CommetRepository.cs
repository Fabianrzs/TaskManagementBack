using Domain.Entities;
using Infrastruture.Context;
using MongoDB.Driver;

namespace Infrastruture.Repositories
{
    public class CommentRepository
    {
        public IMongoCollection<Comment> _collection { get; set; }
        public CommentRepository(MongoDbContext<Comment> dbContext)
        { 
            _collection = dbContext.GetCollection();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            var comments = await _collection.FindAsync<Comment>(_ => true);
            return await comments.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(Guid id)
        {
            var comment = await _collection.FindAsync(c => c.Id == id);
            return await comment.FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _collection.DeleteOneAsync(c => c.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<bool> UpdateAsync(Comment comment)
        {
            var result = await _collection.ReplaceOneAsync(c => c.Id == comment.Id, comment);
            return result.ModifiedCount > 0;
        }

        public async Task<Comment> SaveAsync(Comment comment)
        {
            await _collection.InsertOneAsync(comment);
            return comment;
        }

    }
}
