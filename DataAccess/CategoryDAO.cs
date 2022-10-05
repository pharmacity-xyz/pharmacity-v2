using BusinessObjects.Data;
using BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        private static CategoryDAO? instance = null;
        private static readonly object iLock = new object();

        public CategoryDAO()
        {

        }

        public static CategoryDAO Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Category> GetCategories()
        {
            var listCategories = new List<Category>();
            try
            {
                using (var context = new AppDbContext())
                {
                    listCategories = context.Categories!.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listCategories;
        }

        public void Add(Category category)
        {
            try
            {
                var db = new AppDbContext();
                db.Categories!.Add(category);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Category category)
        {
            try
            {
                using (var context = new AppDbContext())
                {

                    context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteCategory(Guid id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var cDelete = context.Categories!.SingleOrDefault(x => x.CategoryId == id);
                    context.Categories!.Remove(cDelete!);
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
