using StoreAPI.Models;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<Guid>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<bool>> ChangePassword(Guid userId, string newPassword);
    }
}
