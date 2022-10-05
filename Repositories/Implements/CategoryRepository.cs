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
            return CategoryDAO.Instance.GetCategories().Select(m => CategoryMapper.mapToDTO(m)).ToList();
        }

        public void Update(CategoryDTO categoryDTO)
        {
            Category category = CategoryDAO.Instance.GetCategoryById(categoryDTO.CategoryId);
            CategoryDAO.Instance.Update(category);
        }

        public void Delete(Guid id)
        {
            CategoryDAO.Instance.DeleteCategory(id);
        }
    }
}
