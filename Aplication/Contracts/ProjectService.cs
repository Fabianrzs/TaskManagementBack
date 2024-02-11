using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Aplication.Contracts
{
    public class ProjectService : GenericService<Project>, IProjectService
    {
        public ProjectService(IProjectRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
        }
    }
}
