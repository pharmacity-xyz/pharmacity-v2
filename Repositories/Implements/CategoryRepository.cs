using BusinessObjects.Model;
using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;

namespace Repositories.Implements
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Add(CategoryDTO categoryDTO)
        {
            Category newCategory = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = categoryDTO.CategoryName,
            };

            CategoryDAO.Instance.Add(newCategory);
        }

        public List<CategoryDTO> GetCategory()
        {
            return CategoryDAO.Instance.GetCategories().Select(m => Mapper.mapToDTO(m)).ToList();
        }

        public void Update(CategoryDTO categoryDTO)
        {
            CategoryDAO.Instance.Update(Mapper.mapToEntity(categoryDTO));
        }

        public void Delete(Guid id)
        {
            CategoryDAO.Instance.DeleteCategory(id);
        }
    }
}
