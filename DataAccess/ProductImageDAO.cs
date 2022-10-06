using BusinessObjects.Data;
using BusinessObjects.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductImageDAO
    {
        private static ProductImageDAO? instance = null;
        private static readonly object iLock = new object();
        public ProductImageDAO()
        {
        }

        public static ProductImageDAO Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductImageDAO();
                    }
                    return instance;
                }
            }
        }

        public void AddNewProductImage(ProductImage productImage)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.ProductImages!.Add(productImage);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "in ProductImageDAO");
            }
        }

        public ProductImage GetProductImage(Guid productId)
        {
            var productImage = new ProductImage();
            try
            {
                using (var context = new AppDbContext())
                {
                    productImage = context.ProductImages!.SingleOrDefault(pi => pi.ProductId == productId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return productImage!;
        }

        public void UpdateProductImage(ProductImage productImage)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Entry<ProductImage>(productImage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteProductImage(Guid productId)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var pDelete = context.ProductImages!.SingleOrDefault(pi => pi.ProductId == productId);
                    context.ProductImages!.Remove(pDelete!);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}