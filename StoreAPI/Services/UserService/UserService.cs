using StoreAPI.Models;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public UserService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<User>>> GetAll()
        {
            var allUsers = await _context.Users!.ToListAsync();
            return new ServiceResponse<List<User>> { Data = allUsers };
        }

        public async Task<ServiceResponse<User>> GetUser()
        {
            Guid userId = _authService.GetUserId();
            // var user = _context.Users!.FirstOrDefault(a => a.UserId == userId);
            var user = await _context.Users!.FindAsync(userId);
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
