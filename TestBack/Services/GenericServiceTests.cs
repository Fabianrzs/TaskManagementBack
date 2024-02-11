using Aplication.Contracts;
using Aplication.Interfaces;
using Aplication.Mappers;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infrastruture.Context;
using Infrastruture.Repositories;
using Microsoft.EntityFrameworkCore;
using TestBack.Dummy;

namespace TestBack.Repositories
{
    [TestClass]
    public class GenericServiceTests
    {
        private AppDbContext _dbContext;
        private IGenericService<SampleEntity> _genericService;

        [TestInitialize]
        public void Initialize()
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SampleEntity, SampleDto>();
            }));
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new AppDbContext(options);
            var genericRepository = new GenericRepository<SampleEntity>(_dbContext);
            IUnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            _genericService = new GenericService<SampleEntity>(genericRepository, unitOfWork, mapper);

        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnDtos_WhenEntitiesExist()
        {
            var entities = SampleEntityDummy.Samples();
            _dbContext.AddRange(entities);
            await _dbContext.SaveChangesAsync();
            var response = await _genericService.GetAllAsync<SampleDto>();
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(entities.Count, response.Data.Count());
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldThrowNoContent_WhenNoEntitiesExist()
        {
            // Act & Assert
            await Assert.ThrowsExceptionAsync<NoContentException>(async () => await _genericService.GetAllAsync<SampleDto>());
        }

    }
}

