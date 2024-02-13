using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;

namespace Site.Controllers
{
    public class ProjectController : CrudControllerBase<Project, ProjectDto>
    {
        public ProjectController(IProjectService service) : base(service)
        {
        }

        [HttpGet("/{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            return Ok(await _service.GetAllAsync<ProjectDto>());
        }
    }
}
