using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public User LoginWithUser(string email, string password)
        {
            return UserDAO.Instance.FindMemberByEmailPassword(email, password);
        }

        public UserDTO GetLoggedAccount()
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO user)
        {
            UserDAO.Instance.UpdateMember(Mapper.mapToEntity(user));
        }

        public void UpdatePassword(User user)
        {
            UserDAO.Instance.UpdateMember(user);
        }


    }
}
