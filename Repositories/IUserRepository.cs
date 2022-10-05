using DataAccess.DTO;
using BusinessObjects.Model;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        void Add(UserDTO member);
        List<UserDTO> GetAll();
        UserDTO Login(string email, string password);
        User LoginWithUser(string email, string password);
        UserDTO GetLoggedAccount();
        void Update(UserDTO member);
        void UpdatePassword(User user);
    }
}
