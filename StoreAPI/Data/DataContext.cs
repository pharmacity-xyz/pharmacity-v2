using StoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>().HasKey(ci => new { ci.UserId, ci.ProductId });

            modelBuilder.Entity<OrderItem>().HasKey(oi => new { oi.OrderId, oi.ProductId });

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<ProductImage>? ProductImages { get; set; }
        public virtual DbSet<CartItem>? CartItems { get; set; }
        public virtual DbSet<Order>? Orders { get; set; }
        public virtual DbSet<OrderItem>? OrderItems { get; set; }

    }
}
