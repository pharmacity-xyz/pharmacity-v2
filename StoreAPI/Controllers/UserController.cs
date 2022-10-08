﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using BusinessObjects.Models;
using DataAccess.DTO;
using Repositories;
using StoreAPI.Storage;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("register")]
        public IActionResult register(UserDTO userDTO)
        {
            try
            {
                // PasswordHasher<UserDTO> passwordHasher = new PasswordHasher<UserDTO>();
                // userDTO.Password = passwordHasher.HashPassword(userDTO, userDTO.Password);
                userDTO.Role = Role.USER.ToString();
                userRepository.Add(userDTO);

                return Ok(LoggedUser.Instance!.User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register/admin")]
        public IActionResult registerAdmin(UserDTO userDTO)
        {
            try
            {
                // PasswordHasher<UserDTO> passwordHasher = new PasswordHasher<UserDTO>();
                // userDTO.Password = passwordHasher.HashPassword(userDTO, userDTO.Password);
                userDTO.Role = Role.ADMIN.ToString();
                userRepository.Add(userDTO);

                return Ok(LoggedUser.Instance!.User);
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
                if (email.Equals("") && password.Equals(""))
                {
                    throw new Exception("Email and Password cannot be empty");
                }
                else
                {
                    if (email.Equals("")) throw new Exception("Email cannot be empty");
                    if (password!.Equals("")) throw new Exception("Password cannot be empty");
                }

                UserDTO user = userRepository.Login(email, password);
                // PasswordHasher<UserDTO> passwordHasher = new PasswordHasher<UserDTO>();

                // if (passwordHasher.VerifyHashedPassword(user, user.Password, password) ==
                //         PasswordVerificationResult.Failed
                //     )
                // {
                //     throw new Exception("You entered wrong password. Please type again.");
                // }

                LoggedUser.Instance!.User = user;

                return Ok(LoggedUser.Instance.User);

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

                // UserDTO user = userRepository.Login(email);
                // PasswordHasher<UserDTO> passwordHasher = new PasswordHasher<UserDTO>();

                // if (passwordHasher.VerifyHashedPassword(user, user.Password, password) ==
                //         PasswordVerificationResult.Failed
                //     )
                // {
                //     throw new Exception("You entered wrong password. Please type again.");
                // }
                UserDTO user = userRepository.UpdatePassword(email, password, newPassword);

                LoggedUser.Instance!.User = user;

                return Ok("Successfully changed");
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
                LoggedUser.Instance!.User = null;

                return Ok(LoggedUser.Instance.User);

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
                return Ok(LoggedUser.Instance!.User);
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
                userRepository.Update(user, newCity, newCountry, newCompany);

                LoggedUser.Instance.User = user;

                return Ok(LoggedUser.Instance.User);

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
                List<UserDTO> userDTOs = userRepository.GetAll();
                return Ok(userDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
