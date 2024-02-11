using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using Site.Commons;

namespace Site.Controllers
{
    public class TaskController : CrudControllerBase<TaskEntity, TaskEntityDto>
    {
        public TaskController(ITaskEntityService service) : base(service)
        {
        }
    }
}
