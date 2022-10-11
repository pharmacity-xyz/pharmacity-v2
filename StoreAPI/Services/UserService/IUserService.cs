using StoreAPI.DTO;
using StoreAPI.Models;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<int>> Register(User user);
        List<UserDTO> GetAll();
        UserDTO Login(string email, string provided_password);
        UserDTO GetLoggedAccount();
        UserDTO Update(UserDTO user, string newCity, string newCountry, string newCompany);
        UserDTO UpdatePassword(string email, string password, string newPassword);
        UserDTO ForgotPassword(string email, string newPassword);
    }
}
