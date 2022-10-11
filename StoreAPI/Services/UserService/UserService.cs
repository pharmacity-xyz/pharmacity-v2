using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;

using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using BusinessObjects.Model;
using StoreAPI.Data;

namespace StoreAPI.Services
{
    public class UserService : IUserService
    {

        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

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

        public string GetUserEmail() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);

        public void Add(UserDTO userDTO)
        {
            User new_user = new User
            {
                UserId = Guid.NewGuid(),
                Email = userDTO.Email,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                City = userDTO.City,
                Country = userDTO.Country,
                CompanyName = userDTO.CompanyName,
                Role = userDTO.Role?.ToString()
            };
            UserDAO.Instance.AddNewUser(new_user);
        }

        public List<UserDTO> GetAll()
        {
            return UserDAO.Instance.FetchAllUsers().Select(m => UserMapper.mapToDTO(m)).ToList()!;
        }

        public UserDTO Login(string email, string provided_password)
        {
            User user = UserDAO.Instance.FindUserByEmail(email);
            UserDAO.Instance.VerifyPassword(user, provided_password);
            return UserMapper.mapToDTO(user)!;
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
    }
}
