using StoreAPI.DTO;
using StoreAPI.Models;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<Guid>> Register(User user);
        Task<ServiceResponse<string>> Login(string email, string password);
        List<UserDTO> GetAll();
        UserDTO GetLoggedAccount();
        UserDTO Update(UserDTO user, string newCity, string newCountry, string newCompany);
        UserDTO UpdatePassword(string email, string password, string newPassword);
        UserDTO ForgotPassword(string email, string newPassword);
    }
}
