using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Aplication.Contracts
{
    public class CollaboratorService : GenericService<Collaborator>, ICollaboratorService
    {
        public CollaboratorService(ICollaboratorRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
        }
    }
}
