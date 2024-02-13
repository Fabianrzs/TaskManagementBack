using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System;
using WebApi.Commons;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class ProjectController : CrudControllerBase<Project, ProjectDto>
    {
        public ProjectController(IProjectService service) : base(service)
        {
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            var proyects = await _service.GetAllAsync<ProjectDto>();
            proyects.Data.ToList().ForEach(task => task.Owner = userId);

            return Ok(proyects);
        }
    }
}
