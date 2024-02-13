using Aplication.Interfaces;
using Aplication.Mappers;
using Domain.Entities;
using WebApi.Commons;

namespace Site.Controllers
{
    public class UserController : CrudControllerBase<User, UserDto>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}
