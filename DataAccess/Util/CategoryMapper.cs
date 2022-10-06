using BusinessObjects.Model;
using DataAccess.DTO;

namespace DataAccess.Util
{
    public class CategoryMapper
    {
        public static CategoryDTO mapToDTO(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.Name
            };
            return categoryDTO;
        }

        public static Category createNewCategory(CategoryDTO categoryDTO)
        {
            return new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = categoryDTO.CategoryName!
            };
        }
    }
}