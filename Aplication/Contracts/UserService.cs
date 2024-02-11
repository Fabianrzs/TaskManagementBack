using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Aplication.Contracts
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
        }
    }
}
