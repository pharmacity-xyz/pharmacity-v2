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

        public async Task<ServiceResponse<List<Category>>> UpdateCategory(Category category)
        {
            var dbCategory = await GetCategoryById(category.CategoryId);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    Message = "Category not found."
                };
            }

            dbCategory.Name = category.Name;

            await _context.SaveChangesAsync();

            return await GetCategories();
        }

        public Task<ServiceResponse<List<Category>>> DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        private async Task<Category?> GetCategoryById(Guid id)
        {
            return await _context.Categories!.FirstOrDefaultAsync(c => c.CategoryId == id);
        }


        

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
            // CategoryDAO.Instance.DeleteCategory(id);
        }
    }
}
