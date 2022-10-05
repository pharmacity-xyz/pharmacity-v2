using BusinessObjects.Model;
using DataAccess.DTO;

namespace DataAccess.Util
{
    public class UserMapper
    {
        public static UserDTO? mapToDTO(User user)
        {
            if (user != null)
            {
                return new UserDTO
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    Country = user.Country,
                    CompanyName = user.CompanyName,
                    City = user.City,
                    Password = user.Password,
                    Role = user.Role
                };
            }
            else
            {
                return null;
            }

        }

        public static User mapToEntity(UserDTO userDTO)
        {
            User user = new User
            {
                UserId = Guid.NewGuid(),
                Email = userDTO.Email,
                Country = userDTO.Country,
                CompanyName = userDTO.CompanyName,
                City = userDTO.City,
                Password = userDTO.Password,
                Role = userDTO.Role?.ToString()
            };

            return user;
        }
    }
}