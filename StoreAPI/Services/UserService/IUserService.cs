using StoreAPI.DTO;
using StoreAPI.Models;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetAll();
        Task<ServiceResponse<User>> GetUser();
        Task<ServiceResponse<User>> Update(UserUpdate request);
    }
}
