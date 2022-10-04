using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        UserDTO Login(string email, string password);
        UserDTO GetLoggedAccount();
        void Add(UserDTO member);
        void Update(UserDTO member);
        List<UserDTO> GetAll();
    }
}
