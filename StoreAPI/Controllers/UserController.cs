using BusinessObjects.Models;
using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Implements;
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

        [HttpPost("login")]
        public IActionResult Login(UserDTO userDTO)
        {
            try
            {
                if (userDTO.Email!.Equals("") && userDTO.Password!.Equals(""))
                {
                    throw new Exception("Email and Password cannot be empty");
                }
                else
                {
                    if (userDTO.Email.Equals("")) throw new Exception("Email cannot be empty");
                    if (userDTO.Password!.Equals("")) throw new Exception("Password cannot be empty");
                }


                UserDTO member = userRepository.Login(userDTO.Email, userDTO.Password);

                LoggedUser.Instance.User = member;

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("changePassword")]
        public IActionResult changePass(string email, string password, string newPassword, string confirmNewPassword)
        {
            try
            {
                UserDTO user = userRepository.Login(email, password);

                if (!confirmNewPassword.Equals(newPassword)) throw new Exception("Confirm password does not match new password");

                user.Password = newPassword;

                userRepository.Update(user);

                LoggedUser.Instance.User = user;

                return Ok(LoggedUser.Instance.User);

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
                LoggedUser.Instance.User = null;

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("loggedMember")]
        public IActionResult loggedUser()
        {
            try
            {
                return Ok(LoggedUser.Instance.User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult register(UserDTO userDTO)
        {
            try
            {
                //if (memberDTO.Email.Equals("") && memberDTO.Password.Equals(""))
                //{
                //    throw new Exception("Email and Password cannot be empty");
                //}
                //else
                //{
                //    if (memberDTO.Email.Equals("")) throw new Exception("Email cannot be empty");
                //    if (memberDTO.Password.Equals("")) throw new Exception("Password cannot be empty");
                //}

                userDTO.Role = Role.USER.ToString();
                userRepository.Add(userDTO);

                return Ok(LoggedUser.Instance.User);

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
                UserDTO user = LoggedUser.Instance.User;

                if (user == null)
                {
                    throw new Exception("Can't do this action");
                }

                user.City = newCity;
                user.Country = newCountry;
                user.CompanyName = newCompany;

                userRepository.Update(user);

                LoggedUser.Instance.User = user;

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAll")]
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
