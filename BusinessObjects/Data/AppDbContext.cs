﻿using BusinessObjects.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));
        }

        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<Order>? Orders { get; set; }
        public virtual DbSet<OrderDetail>? OrderDetails { get; set; }
        public virtual DbSet<User>? Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(order => order.OrderDetail)
                .WithOne(orderDetail => orderDetail.Order)
                .HasForeignKey<OrderDetail>(orderDetail => orderDetail.OrderForeignKey);
        }
    }
}
