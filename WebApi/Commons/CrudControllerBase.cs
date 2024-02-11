using Aplication.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Site.Commons
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CrudControllerBase<TEntity, TDto> : ControllerBase where TEntity : BaseEntity
    {
        protected readonly IGenericService<TEntity> _service;

        public CrudControllerBase(IGenericService<TEntity> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add([FromBody] TDto dto)
        {
            return Ok(await _service.InsertAsync(dto));
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync<TDto>(id));
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync<TDto>());
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(Guid id, [FromBody] TDto dto)
        {
            return Ok(await _service.UpdateAsync(dto)); // Aquí puedes pasar id si es necesario
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            return Ok(_service.DeleteAsync(id));
        }

    }
}
