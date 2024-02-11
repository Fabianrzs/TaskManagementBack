using Aplication.Base;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using System.Linq.Expressions;

namespace Aplication.Contracts
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseEntity
    {

        private readonly IGenericRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync<TDto>()
        {
            var entities = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
            if (!dtos.Any())
                throw new NoContentException($"No {nameof(TDto)} found.");

            return new Response<IEnumerable<TDto>>(dtos);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAsync<TDto>(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _repository.GetAsync(predicate);
            var dtos = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
            if (!dtos.Any())
                throw new NoContentException($"No {nameof(TDto)} found matching the given predicate.");

            return new Response<IEnumerable<TDto>>(dtos);
        }

        public async Task<Response<TDto>> GetByIdAsync<TDto>(object id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var dto = _mapper.Map<TEntity, TDto>(entity);
            if (dto == null)
                throw new NoContentException($"{nameof(TEntity)} with ID '{id}' not found.");

            return new Response<TDto>(dto);
        }

        public async Task<Response<TDto>> InsertAsync<TDto>(TDto dto)
        {
            var entity = _mapper.Map<TDto, TEntity>(dto);
            var existingEntity = await _repository.GetByIdAsync(entity.Id);
            if (existingEntity != null)
                throw new ConflictException($"{nameof(TEntity)} with ID '{entity.Id}' already exists.");

            await _repository.InsertAsync(entity);
            await _unitOfWork.SaveChanges();

            return new Response<TDto>(dto);
        }

        public async Task<Response<TDto>> UpdateAsync<TDto>(TDto dto)
        {
            var entity = _mapper.Map<TDto, TEntity>(dto);
            var existingEntity = await _repository.GetByIdAsync(entity.Id);
            if (existingEntity == null)
                throw new NoContentException($"{nameof(TEntity)} with ID '{entity.Id}' not found.");

            await _repository.UpdateAsync(entity);
            await _unitOfWork.SaveChanges();

            return new Response<TDto>(dto);
        }

        public async Task<Response<object>> DeleteAsync(object id)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
                throw new NoContentException($"{nameof(TEntity)} with ID '{id}' not found.");

            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChanges();

            return new Response<object>();
        }
    }
}
