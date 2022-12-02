using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using StoreAPI.Models;
using StoreAPI.Services;
using StoreAPI.Utils;
using StoreAPI.DTO;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> GetAll()
        {
            var response = await _userService.GetAll();
            return Ok(response);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ServiceResponse<User>>> GetUser()
        {
            var response = await _userService.GetUser();
            return Ok(response);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult<ServiceResponse<User>>> AddOrUpdate(UserUpdate request)
        {
            var response = await _userService.Update(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
