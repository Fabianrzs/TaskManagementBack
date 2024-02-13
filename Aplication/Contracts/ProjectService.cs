using Aplication.Base;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Aplication.Contracts
{
    public class ProjectService : GenericService<Project>, IProjectService
    {
        public ProjectService(IProjectRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper) { }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync<TDto>(Guid guid)
        {
            var entities = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<Project>, IEnumerable<TDto>>(entities.Where(x=>x.IdUser == guid));
            if (!dtos.Any())
                throw new NoContentException($"No {nameof(TDto)} found.");

            return new Response<IEnumerable<TDto>>(dtos);
        }
    }
}
