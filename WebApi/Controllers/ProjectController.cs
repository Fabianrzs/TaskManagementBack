using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using Site.Commons;

namespace Site.Controllers
{
    public class ProjectController : CrudControllerBase<Project, ProjectDto>
    {
        public ProjectController(IProjectService service) : base(service)
        {
        }
    }
}
