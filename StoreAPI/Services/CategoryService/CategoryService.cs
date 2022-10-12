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

        public async Task<ServiceResponse<List<Category>>> AddCategory(Category category)
        {
            _context.Categories!.Add(category);
            await _context.SaveChangesAsync();
            return await GetCategories();
        }

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories!.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };
        }



        public Task<ServiceResponse<List<Category>>> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Category>>> DeleteCategory(Guid id)
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
