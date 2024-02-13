using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;

namespace Site.Controllers
{
    public class TaskController : CrudControllerBase<TaskEntity, TaskEntityDto>
    {
        public TaskController(ITaskEntityService service) : base(service)
        {
        }
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetAll(Guid projectId)
        {
            var tasks = await _service.GetAllAsync<TaskEntityDto>();
            tasks.Data.ToList().ForEach(task => task.IdProject = projectId);
            return Ok(tasks);
        }
    }
}
