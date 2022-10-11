﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


using BusinessObjects.Models;
using DataAccess.DTO;
using StoreAPI.Services;
// using StoreAPI.Storage;

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
        public ActionResult<UserDTO> Register(UserDTO userDTO)
        {
            try
            {
                userDTO.Role = Role.USER.ToString();
                _userService.Add(userDTO);

                return Ok(userDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register/admin"), Authorize(Roles = "Admin")]
        public IActionResult RegisterAdmin(UserDTO userDTO)
        {
            try
            {
                userDTO.Role = Role.ADMIN.ToString();
                _userService.Add(userDTO);

                return Ok(userDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            try
            {
                UserDTO user = _userService.Login(email, password);

                // LoggedUser.Instance!.User = user;

                string token = CreateToken(user);

                return Ok(token);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                List<UserDTO> userDTOs = _userService.GetAll();
                return Ok(userDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
                UserDTO user = LoggedUser.Instance!.User!;

                if (user == null)
                {
                    throw new Exception("Can not find the user");
                }
                UserDTO updated_user = _userService.Update(user, newCity, newCountry, newCompany);

                // LoggedUser.Instance.User = updated_user;

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("forgot_password")]
        public IActionResult forgotPassword(string email, string newPassword)
        {
            try
            {
                var updated_user = _userService.ForgotPassword(email, newPassword);
                // LoggedUser.Instance!.User = updated_user;
                return Ok("Update password successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("change_password")]
        public IActionResult changePass(
                    string email,
                    string password,
                    string newPassword,
                    string confirmNewPassword
                )
        {
            try
            {
                if (!confirmNewPassword.Equals(newPassword))
                {
                    throw new Exception("Confirm password does not match new password");
                }

                UserDTO user = _userService.UpdatePassword(email, password, newPassword);

                LoggedUser.Instance!.User = user;

                return Ok("Successfully changed");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
    }
}
