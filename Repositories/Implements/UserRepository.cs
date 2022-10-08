using Microsoft.AspNetCore.Identity;

using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using BusinessObjects.Model;

namespace Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        public void Add(UserDTO userDTO)
        {
            User new_user = new User
            {
                UserId = Guid.NewGuid(),
                Email = userDTO.Email,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                City = userDTO.City,
                Country = userDTO.Country,
                CompanyName = userDTO.CompanyName,
                Role = userDTO.Role?.ToString()
            };
            UserDAO.Instance.AddNewUser(new_user);
        }

        public List<UserDTO> GetAll()
        {
            return UserDAO.Instance.FetchAllUsers().Select(m => UserMapper.mapToDTO(m)).ToList()!;
        }

        public UserDTO Login(string email)
        {
            return UserMapper.mapToDTO(UserDAO.Instance.FindUserByEmail(email))!;
        }

        public UserDTO GetLoggedAccount()
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO user, string newCity, string newCountry, string newCompany)
        {
            User temp_user = UserDAO.Instance.FindUserByEmail(user.Email);
            temp_user.City = newCity;
            temp_user.Country = newCountry;
            temp_user.CompanyName = newCompany;
            UserDAO.Instance.UpdateUser(temp_user);
        }

        public UserDTO UpdatePassword(string email, string password, string newPassword)
        {
            User temp_user = UserDAO.Instance.FindUserByEmail(email);
            UserDAO.Instance.UpdateUserPassword(temp_user, password, newPassword);
            return UserMapper.mapToDTO(temp_user)!;
        }
    }
}
