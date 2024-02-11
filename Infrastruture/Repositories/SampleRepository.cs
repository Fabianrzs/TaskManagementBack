using Domain.Entities;
using Domain.Repositories;
using Infrastruture.Context;

namespace Infrastruture.Repositories
{
    public class SampleRepository : GenericRepository<SampleEntity>, ISampleRepository
    {
        public SampleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
