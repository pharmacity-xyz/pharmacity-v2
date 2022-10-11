using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;

using StoreAPI.Models;
using StoreAPI.Data;
using StoreAPI.DTO;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IAuthService _authService;

        public UserService(
            AppDbContext context,
            IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // public Guid GetUserId() => Guid.Parse(
        //     _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));

        // public string GetUserEmail() => _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Email);


        public List<UserDTO> GetAll()
        {
            // return UserDAO.Instance.FetchAllUsers().Select(m => UserMapper.mapToDTO(m)).ToList()!;
            throw new NotImplementedException();
        }

        public UserDTO GetLoggedAccount()
        {
            throw new NotImplementedException();
        }

        // private string CreateToken(User user)
        // {
        //     List<Claim> claims = new List<Claim> {
        //         new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        //         new Claim(ClaimTypes.Email, user.Email),
        //         new Claim(ClaimTypes.Role, user.Role!),
        //     };

        //     var key = new SymmetricSecurityKey(
        //         System.Text.Encoding.UTF8.GetBytes(
        //             _configuration.GetSection("AppSettings:Token").Value
        //         )
        //     );

        //     var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //     var token = new JwtSecurityToken(
        //         claims: claims,
        //         expires: DateTime.Now.AddDays(1),
        //         signingCredentials: cred
        //     );

        //     var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        //     return jwt;
        // }

        // private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        // {
        //     using (var hmac = new HMACSHA512())
        //     {
        //         passwordSalt = hmac.Key;
        //         passwordHash = hmac
        //             .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //     }
        // }

        // private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        // {
        //     using (var hmac = new HMACSHA512(passwordSalt))
        //     {
        //         var computedHash =
        //             hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //         return computedHash.SequenceEqual(passwordHash);
        //     }
        // }

        public async Task<ServiceResponse<User>> GetUser()
        {
            Guid userId = _authService.GetUserId();
            var user = _context.Users!.FirstOrDefault(a => a.UserId == userId);
            return new ServiceResponse<User> { Data = user };
        }

        public async Task<ServiceResponse<User>> AddOrUpdate(User user)
        {
            var response = new ServiceResponse<User>();
            var dbUser = (await GetUser()).Data;
            if (dbUser == null)
            {
                user.UserId = _authService.GetUserId();
                _context.Users!.Add(user);
                response.Data = user;
            }
            else
            {
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.Country = user.Country;
                dbUser.City = user.City;
                response.Data = dbUser;
            }

            await _context.SaveChangesAsync();

            return response;
        }
    }
}
