using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using StoreAPI.Models;
using StoreAPI.DTO;
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
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var response = await _userService.GetAll();
            return Ok(response);
        }

        [HttpPut("edit")]
        public IActionResult edit(
            string newCompany,
            string newCity,
            string newCountry
        )
        {
            try
            {
                // UserDTO user = LoggedUser.Instance!.User!;

                // if (user == null)
                // {
                //     throw new Exception("Can not find the user");
                // }
                // UserDTO updated_user = _userService.Update(user, newCity, newCountry, newCompany);

                // // LoggedUser.Instance.User = updated_user;

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
