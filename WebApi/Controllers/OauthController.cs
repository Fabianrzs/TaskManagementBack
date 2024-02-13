using Aplication.Dtos;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WebApi.Commons;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OauthController: ControllerBase 
    {
        IOauthService _authService;
        public OauthController(IOauthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Token")]
        public virtual async Task<IActionResult> Token(TokenRequest request)
        {
            var response = await _authService.Token(request);
            var token = JwtHandler.GenerateAccessToken(response.Data);
            return Ok(token);
        }
        [HttpPost("Refresh")]
        public virtual async Task<IActionResult> Refresh()
        {
            var id = User.FindFirstValue("Id");
            var response = await _authService.Refresh(new Guid(id));
            var token = JwtHandler.GenerateAccessToken(response.Data);
            return Ok(token);
        }
    }
}
