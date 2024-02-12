using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using Site.Commons;

namespace Site.Controllers
{
    public class CommentController : CrudControllerBase<Comment, CommentDto>
    {
        public CommentController(ICommentService service) : base(service)
        {
        }
    }
}
