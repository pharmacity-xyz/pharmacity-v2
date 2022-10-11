﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserDTO userDTO)
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<Guid>>> Register(UserRegister request)
        {
            var response = await _userService.Register(
                new User
                {
                    UserId = Guid.NewGuid(),
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    City = request.City,
                    Country = request.Country,
                    CompanyName = request.CompanyName,
                },
                request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var response = await _userService.Login(request.Email, request.Password);
            if (!response.Success)
            {

                return BadRequest(response);
            }

            return Ok(response);

        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            // try
            // {
            //     List<UserDTO> userDTOs = _userService.GetAll();
            //     return Ok(userDTOs);
            // }
            // catch (Exception e)
            // {
            //     return BadRequest(e.Message);
            // }
            return Ok();
        }

        [HttpGet("logout")]
        public IActionResult logout()
        {
            try
            {
                // LoggedUser.Instance!.User = null;

                // return Ok(LoggedUser.Instance.User);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("logged_member")]
        public IActionResult loggedUser()
        {
            try
            {
                // return Ok(LoggedUser.Instance!.User);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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

        [HttpPost("change_password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword(string newPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _userService.ChangePassword(Guid.Parse(userId), newPassword);

            if (!response.Success)
            {

                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
