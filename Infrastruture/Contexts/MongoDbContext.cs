using Domain.Entities;
using Infrastruture.Helppers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastruture.Context
{
    public class MongoDbContext
    {
        public readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<CommentsDataBase> options)
        {
            var client = new MongoClient(options.Value.MongoConnection);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}
