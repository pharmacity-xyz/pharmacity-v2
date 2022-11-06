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
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<Guid>>> Register(UserRegister request)
        {
            var response = await _authService.Register(
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
        public async Task<ActionResult<ServiceResponse<LoginResponse>>> Login(UserLogin request)
        {
            var response = await _authService.Login(request.Email, request.Password);
            if (!response.Success)
            {

                return BadRequest(response);
            }

            return Ok(response);

        }

        [HttpPost("change_password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword(string newPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.ChangePassword(Guid.Parse(userId), newPassword);

            if (!response.Success)
            {

                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("get_email")]
        public async Task<ActionResult<ServiceResponse<bool>>> GetEmail(string email)
        {
            var user = await _authService.GetUserByEmail(email);
            return new ServiceResponse<bool>
            {
                Data = user != null ? true : false,
                Success = user != null ? true : false,
                Message = user != null ? "" : "Can not find the user"
            };
        }

        [HttpPost("forgot_password")]
        public async Task<ActionResult<ServiceResponse<bool>>> ForgotPassword(string email, string newPassword)
        {
            var user = await _authService.GetUserByEmail(email);
            var response = await _authService.ChangePassword(user!.UserId, newPassword);

            if (!response.Success)
            {

                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
