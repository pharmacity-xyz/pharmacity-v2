using DataAccess.DTO;

namespace StoreAPI.Services
{
    public interface IUserService
    {
        void Add(UserDTO member);
        List<UserDTO> GetAll();
        UserDTO Login(string email, string provided_password);
        UserDTO GetLoggedAccount();
        UserDTO Update(UserDTO user, string newCity, string newCountry, string newCompany);
        UserDTO UpdatePassword(string email, string password, string newPassword);
        UserDTO ForgotPassword(string email, string newPassword);
    }
}
