using StoreAPI.DTO;
using StoreAPI.Models;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<Guid>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        // List<UserDTO> GetAll();
        // UserDTO GetLoggedAccount();
        // UserDTO Update(UserDTO user, string newCity, string newCountry, string newCompany);
        Task<ServiceResponse<bool>> ChangePassword(Guid userId, string newPassword);
    }
}
