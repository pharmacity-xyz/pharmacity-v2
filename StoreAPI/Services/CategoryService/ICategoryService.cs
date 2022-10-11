using DataAccess.DTO;

namespace StoreAPI.Services
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetCategory();
        void Add(CategoryDTO categoryDTO);
        void Delete(Guid id);
        void Update(CategoryDTO categoryDTO);
    }
}
