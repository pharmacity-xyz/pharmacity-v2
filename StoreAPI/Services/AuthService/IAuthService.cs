using StoreAPI.Models;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<Guid>> Register(User user, string password);
        Task<ServiceResponse<LoginResponse>> Login(string email, string password);
        Task<ServiceResponse<bool>> ChangePassword(Guid userId, string newPassword);
        Guid GetUserId();
        string GetUserEmail();
        Task<User?> GetUserByEmail(string email);
    }
}
