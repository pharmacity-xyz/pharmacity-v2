using StoreAPI.Models;
using StoreAPI.Data;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IAuthService _authService;

        public UserService(AppDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<User>>> GetAll()
        {
            var allUsers = _context.Users!.ToList();
            return new ServiceResponse<List<User>> { Data = allUsers };
        }

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
