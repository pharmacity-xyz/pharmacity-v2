using StoreAPI.DTO;
using StoreAPI.Models;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<Category>>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Category>>> GetAdminCategories()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Category>>> AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Category>>> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Category>>> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
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
