using System.Threading.Tasks;
using AuctionSystem.Contracts.Services;
using AuctionSystem.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.WebApi.Controllers
{
    [Route("users")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var tokenSet = await Task.Run(() => _loginService.Login(request.Email, request.Password));
            if (tokenSet == null)
                return Unauthorized();

            return Ok(tokenSet);
        }
    }
}