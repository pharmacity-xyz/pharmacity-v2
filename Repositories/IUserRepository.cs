using DataAccess.DTO;

namespace Repositories
{
    public interface IUserRepository
    {
        void Add(UserDTO member);
        List<UserDTO> GetAll();
        UserDTO Login(string email, string password);
        UserDTO GetLoggedAccount();
        void Update(UserDTO member);
        void UpdatePassword(UserDTO user);
    }
}
