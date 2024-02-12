using Domain.Entities;
using Infrastruture.Context;
using Infrastruture.Helppers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace TestBack.Repositories
{
    [TestClass]
    public class MongoDbContextTests
    {
        private IMongoCollection<Comment>? _collection;

        [TestInitialize]
        public void Initialize()
        {
            var options = Options.Create(new CommentsDataBase
            {
                MongoConnection = "mongodb://root:!1PasswordBackEnd.@localhost:27017/",
                DatabaseName = "TaskManagament"
            });

            var context = new MongoDbContext(options);
            _collection = context.GetCollection<Comment>();
        }

        [TestMethod]
        public void GetCollection_ReturnsCorrectCollection()
        {
            Assert.IsNotNull(_collection);
            Assert.IsInstanceOfType(_collection, typeof(IMongoCollection<Comment>));
        }
        [TestMethod]
        public void SaveAsync_SavesComment()
        {
            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                Message = "Test Comment",
                Owner = Guid.NewGuid(),
                Relation = Guid.NewGuid(),
                Date = DateTime.Now,
            };

            _collection!.InsertOne(comment);
            var savedComment = _collection.Find(c => c.Id == comment.Id).FirstOrDefault();
            Assert.IsNotNull(savedComment);
            Assert.AreEqual(comment.Message, savedComment.Message);
        }

        [TestMethod]
        public void DeleteAsync_DeleteComment()
        {
            var deletedComment = _collection.Find(c => true).FirstOrDefault();
            var deletedResult = _collection!.DeleteOne(c => c.Id == deletedComment.Id);
            Assert.AreEqual(deletedResult.DeletedCount, 1);
        }

        [TestMethod]
        public void UpdateAsync_UpdatesComment()
        {
            var comment = _collection.Find(c => true).FirstOrDefault();
            if (comment != null)
            {
                var newText = "Updated Test Comment";
                comment.Message = newText;
                _collection.ReplaceOne(c => c.Id == comment.Id, comment);
                var updatedComment = _collection.Find(c => c.Id == comment.Id).FirstOrDefault();
                Assert.IsNotNull(updatedComment);
                Assert.AreEqual(newText, updatedComment.Message);
            }
            else
            {
                Assert.Inconclusive("No comment found for updating.");
            }
        }

        [TestMethod]
        public void GetByIdAsync_GetsCommentById()
        {
            var comment = _collection.Find(c => true).FirstOrDefault();
            if (comment != null)
            {
                var retrievedComment = _collection.Find(c => c.Id == comment.Id).FirstOrDefault();
                Assert.IsNotNull(retrievedComment);
                Assert.AreEqual(comment.Id, retrievedComment.Id);
            }
            else
            {
                Assert.Inconclusive("No comment found for retrieval.");
            }
        }

        [TestMethod]
        public void FilterAsync_FiltersComments()
        {
            var userId = Guid.NewGuid();
            var filteredComments = _collection.Find(c => c.Owner == userId).ToList();
            Assert.IsNotNull(filteredComments);
            Assert.IsTrue(filteredComments.All(c => c.Owner == userId));
        }

    }
}
