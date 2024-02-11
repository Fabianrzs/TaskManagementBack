using Domain.Entities;
using Infrastruture.Helppers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastruture.Context
{
    public class MongoDbContext<TEntity> where TEntity : BaseMongo
    {
        public readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<CommentsDataBase> options)
        {
            var client = new MongoClient(options.Value.MongoConnection);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }
        public IMongoCollection<TEntity> GetCollection()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}
