using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using Site.Commons;

namespace Site.Controllers
{
    public class CollaboratorController : CrudControllerBase<Collaborator, CollaboratorDto>
    {
        public CollaboratorController(ICollaboratorService service) : base(service)
        {
        }
    }
}
