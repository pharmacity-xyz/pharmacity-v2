using StoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Product>()
            //     .HasOne(p => p.ProductImage)
            //     .WithOne(i => i.Product)
            //     .HasForeignKey<ProductImage>(pi => pi.ProductImageId);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("MyStoreDB"));
        }

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<ProductImage>? ProductImages { get; set; }
        public virtual DbSet<Order>? Orders { get; set; }
        public virtual DbSet<OrderDetail>? OrderDetails { get; set; }

    }
}
