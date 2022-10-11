using StoreAPI.DTO;
using StoreAPI.Models;
// using DataAccess;
// using DataAccess.DTO;
// using DataAccess.Util;

namespace StoreAPI.Services
{
    public class CategoryService : ICategoryService
    {
        public void Add(Category category)
        {
            // Category newCategory = new Category
            // {
            //     CategoryId = Guid.NewGuid(),
            //     Name = categoryDTO.CategoryName!,
            // };

            // CategoryDAO.Instance.Add(newCategory);
            throw new NotImplementedException();
        }

        public List<Category> GetCategory()
        {
            throw new NotImplementedException();
            // return CategoryDAO.Instance.GetCategories().Select(m => CategoryMapper.mapToDTO(m)).ToList();
        }

        public void Update(Category categoryDTO)
        {
            throw new NotImplementedException();
            // Category category = CategoryDAO.Instance.GetCategoryById(categoryDTO.CategoryId);
            // CategoryDAO.Instance.Update(category);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
            // CategoryDAO.Instance.DeleteCategory(id);
        }

        public void Add(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
