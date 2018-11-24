using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuctionSystem.WebApi.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("time")]
        public async Task<DateTimeOffset> GetTime()
        {
            return await Task.FromResult(DateTimeOffset.UtcNow);
        }
    }
}