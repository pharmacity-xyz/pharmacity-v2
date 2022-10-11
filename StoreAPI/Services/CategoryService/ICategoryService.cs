using StoreAPI.DTO;
using StoreAPI.Models;

namespace StoreAPI.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategory();
        void Add(CategoryDTO categoryDTO);
        void Delete(Guid id);
        void Update(CategoryDTO categoryDTO);
    }
}
