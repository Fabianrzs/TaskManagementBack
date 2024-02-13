using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;

namespace Site.Controllers
{
    public class CommentController : CrudControllerBase<Comment, CommentDto>
    {
        public CommentController(ICommentService service) : base(service)
        {
        }
        [HttpGet("tasks/{taskId}")]
        public async Task<IActionResult> GetAll(Guid taskId)
        {
            var tasks = await _service.GetAllAsync<Comment>();
            return Ok(tasks.Data.Where(x => x.Relation == taskId));
        }
    }
}
