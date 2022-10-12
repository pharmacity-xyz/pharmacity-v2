using StoreAPI.Models;
using StoreAPI.Utils;
using StoreAPI.DTO;

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
            var user = await _context.Users!.FindAsync(userId);
            return new ServiceResponse<User> { Data = user };
        }

        public async Task<ServiceResponse<User>> Update(UserUpdate request)
        {
            var response = new ServiceResponse<User>();
            var dbUser = (await GetUser()).Data;
            if (dbUser == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else
            {
                dbUser.FirstName = request.FirstName;
                dbUser.LastName = request.LastName;
                dbUser.City = request.City;
                dbUser.Country = request.Country;
                dbUser.CompanyName = request.CompanyName;
                response.Data = dbUser;
            }

            await _context.SaveChangesAsync();

            return response;
        }
    }
}
