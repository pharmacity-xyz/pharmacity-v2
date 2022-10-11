using Microsoft.AspNetCore.Mvc;

using StoreAPI.Models;
using StoreAPI.Services;
using StoreAPI.Utils;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet("get_all")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> GetAll()
        {
            var response = await _userService.GetAll();
            return Ok(response);
        }

        [HttpPut("add_or_update")]
        public async Task<ActionResult<ServiceResponse<User>>> AddOrUpdate(User user)
        {
            var response = await _userService.AddOrUpdate(user);
            return Ok(response);
        }
    }
}
