using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;

using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using StoreAPI.Models;
using StoreAPI.Data;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public class UserService : IUserService
    {

        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

        public UserService(
            AppDbContext context,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId() => Guid.Parse(
            _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public string GetUserEmail() => _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Email);

        public async Task<ServiceResponse<Guid>> Register(User user)
        {
            UserDAO.Instance.AddNewUser(user);
            user.Password = CreateHashedPassword(user, user.Password);
            _context.Users?.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Guid> { Data = user.UserId, Message = "Registration successful" };
        }

        public List<UserDTO> GetAll()
        {
            return UserDAO.Instance.FetchAllUsers().Select(m => UserMapper.mapToDTO(m)).ToList()!;
        }

        public async Task<ServiceResponse<string>> Login(string email, string provided_password)
        {
            var response = new ServiceResponse<string>();
            var user = _context.Users!.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if ()
                User user = UserDAO.Instance.FindUserByEmail(email);
            UserDAO.Instance.VerifyPassword(user, provided_password);
            return response;

        }

        public UserDTO GetLoggedAccount()
        {
            throw new NotImplementedException();
        }

        public UserDTO Update(UserDTO user, string newCity, string newCountry, string newCompany)
        {
            User temp_user = UserDAO.Instance.FindUserByEmail(user.Email);
            temp_user.City = newCity;
            temp_user.Country = newCountry;
            temp_user.CompanyName = newCompany;
            UserDAO.Instance.UpdateUser(temp_user);
            return UserMapper.mapToDTO(temp_user)!;
        }

        public UserDTO UpdatePassword(string email, string password, string newPassword)
        {
            User temp_user = UserDAO.Instance.FindUserByEmail(email);
            UserDAO.Instance.UpdateUserPassword(temp_user, password, newPassword);
            return UserMapper.mapToDTO(temp_user)!;
        }

        public UserDTO ForgotPassword(string email, string newPassword)
        {
            User temp_user = UserDAO.Instance.FindUserByEmail(email);
            User updated_user = UserDAO.Instance.ForgotPassword(temp_user, newPassword);
            return UserMapper.mapToDTO(updated_user)!;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
                new Claim(ClaimTypes.Role, user.Role!),
            };

            var key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value
                )
            );

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        // private string CreateHashedPassword(User user, string password)
        // {
        //     return passwordHasher.HashPassword(user, password);
        // }
    }
}
