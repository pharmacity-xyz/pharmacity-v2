﻿using DataAccess.DTO;

namespace Repositories
{
    public interface IProductRepository
    {
        void AddNewProduct(ProductDTO p);
        List<ProductDTO> GetProducts();
        List<ProductDTO> GetProductsByCategory(Guid id);
        ProductDTO GetProductById(Guid id);
        void UpdateProduct(ProductDTO p);
        void DeleteProduct(Guid id);
    }
}
