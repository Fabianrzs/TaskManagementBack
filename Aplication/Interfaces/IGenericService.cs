using Aplication.Base;
using Domain.Entities;
using System.Linq.Expressions;

namespace Aplication.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : BaseEntity
    {
        Task<Response<IEnumerable<TDto>>> GetAllAsync<TDto>();
        Task<Response<IEnumerable<TDto>>> GetAsync<TDto>(Expression<Func<TEntity, bool>> predicate);
        Task<Response<TDto>> GetByIdAsync<TDto>(object id);
        Task<Response<TDto>> InsertAsync<TDto>(TDto dto);
        Task<Response<TDto>> UpdateAsync<TDto>(TDto dto);
        Task<Response<object>> DeleteAsync(object id);
    }
}
