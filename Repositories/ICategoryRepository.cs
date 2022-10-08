using DataAccess.DTO;

namespace Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> GetCategory();
        void Add(CategoryDTO categoryDTO);
        void Delete(Guid id);
        void Update(CategoryDTO categoryDTO);
    }
}
