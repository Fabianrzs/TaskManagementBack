using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Aplication.Contracts
{
    public class SampleService : GenericService<SampleEntity>, ISampleService
    {
        public SampleService(ISampleRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
        }
    }
}
