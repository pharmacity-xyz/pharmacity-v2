using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using BusinessObjects.Model;

namespace Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        public void Add(UserDTO user)
        {
            UserDAO.Instance.SaveMember(Mapper.mapToEntity(user));
        }

        public List<UserDTO> GetAll()
        {
            return UserDAO.Instance.FindAll().Select(m => Mapper.mapToDTO(m)).ToList()!;
        }

        public UserDTO Login(string email, string password)
        {
            return Mapper.mapToDTO(UserDAO.Instance.FindMemberByEmailPassword(email, password))!;
        }

        public UserDTO GetLoggedAccount()
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO user)
        {
            UserDAO.Instance.UpdateMember(Mapper.mapToEntity(user));
        }

        public void UpdatePassword(UserDTO user)
        {
            User temp_user = UserDAO.Instance.FindMemberByEmailPassword(user.Email!, user.Password!);
            UserDAO.Instance.UpdateMember(temp_user);
        }
    }
}
