using Domain.Entities;
using Domain.Repositories;
using Infrastruture.Context;
using MongoDB.Driver;
using SharpCompress.Common;
using System;
using System.Linq.Expressions;

namespace Infrastruture.Repositories
{
    public abstract class MongoGenericRepository <TEntity> : IGenericRepository<TEntity> where TEntity : Domain.Entities.BaseEntity
    {
        public IMongoCollection<TEntity> _collection { get; set; }
        public MongoGenericRepository(MongoDbContext<TEntity> dbContext)
        { 
            _collection = dbContext.GetCollection();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var comments = await _collection.FindAsync(_ => true);
            return await comments.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var comments = await _collection.FindAsync(predicate);
            return await comments.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var comment = await _collection.FindAsync(c => c.Id == id);
            return await comment.FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _collection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _collection.ReplaceOneAsync(c => c.Id == entity.Id, entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

    }
}
