using Domain.Entities;
using Domain.Repositories;
using Infrastruture.Context;
using Infrastruture.Repositories;
using Microsoft.EntityFrameworkCore;
using TestBack.Dummy;

namespace TestBack.Repositories
{
    [TestClass]
    public class GenericRepositoryTests
    {
        private AppDbContext _dbContext;
        private IGenericRepository<SampleEntity> _genericRepository;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new AppDbContext(options);
            _genericRepository = new GenericRepository<SampleEntity>(_dbContext);
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAllEntities()
        {
            var entities = SampleEntityDummy.Samples();
            _dbContext.AddRange(entities);
            await _genericRepository.SaveAsync();

            var result = await _genericRepository.GetAllAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(entities.Count, result.Count());
        }

        [TestMethod]
        public async Task GetAsync_ShouldReturnMatchingEntities()
        {
            var entities = SampleEntityDummy.Samples();
            _dbContext.AddRange(entities);
            await _genericRepository.SaveAsync();
            var result = await _genericRepository.GetAsync(e => e.Id == entities.First().Id); 
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task GetByIdAsync_ShouldReturnEntityWithMatchingId()
        {
            var entities = SampleEntityDummy.Samples();
            _dbContext.AddRange(entities);
            await _genericRepository.SaveAsync();
            var result = await _genericRepository.GetByIdAsync(entities.First().Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(entities.First().Name, result.Name);
        }

        [TestMethod]
        public async Task InsertAsync_ShouldAddNewEntity()
        {
            var entity = SampleEntityDummy.Sample();
            await _genericRepository.InsertAsync(entity);
            await _genericRepository.SaveAsync();
            var result = await _dbContext.Samples.FindAsync(entity.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(entity.Name, result.Name);
        }

        [TestMethod]
        public async Task UpdateAsync_ShouldUpdateExistingEntity()
        {
            var entity = SampleEntityDummy.Sample();

            await _dbContext.Samples.AddAsync(entity);
            await _genericRepository.SaveAsync();
            entity.Name = "Updated Entity";
            await _genericRepository.UpdateAsync(entity);
            await _genericRepository.SaveAsync();
            var result = await _dbContext.Samples.FindAsync(entity.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Entity", result.Name);
        }

        [TestMethod]
        public async Task DeleteAsync_ShouldRemoveExistingEntity()
        {
            var entity = SampleEntityDummy.Sample();
            await _dbContext.Samples.AddAsync(entity);
            await _genericRepository.SaveAsync();
            
            await _genericRepository.DeleteAsync(entity.Id);
            await _dbContext.SaveChangesAsync();
            var result = await _dbContext.Samples.FindAsync(entity.Id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task SaveAsync_ShouldSaveChangesToDatabase()
        {
            var entity = SampleEntityDummy.Sample();
            await _dbContext.Samples.AddAsync(entity);
            var result = await _genericRepository.SaveAsync();
            Assert.AreEqual(1, result);
        }

    }

}

