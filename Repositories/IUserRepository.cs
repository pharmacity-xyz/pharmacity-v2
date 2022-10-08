using DataAccess.DTO;

namespace Repositories
{
    public interface IUserRepository
    {
        void Add(UserDTO member);
        List<UserDTO> GetAll();
        UserDTO Login(string email);
        UserDTO GetLoggedAccount();
        void Update(UserDTO user, string newCity, string newCountry, string newCompany);
        UserDTO UpdatePassword(string email, string password, string newPassword);
    }
}
