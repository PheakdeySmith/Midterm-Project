using Microsoft.EntityFrameworkCore;
using Midterm_Project.Models;
using System;
using System.Collections.Generic;

namespace Midterm_Project.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices", CreatedAt = DateTime.UtcNow },
                new Category { Id = 2, Name = "Clothing", Description = "Clothing items", CreatedAt = DateTime.UtcNow },
                new Category { Id = 3, Name = "Books", Description = "Books and literature", CreatedAt = DateTime.UtcNow },
                new Category { Id = 4, Name = "Home Appliances", Description = "Household appliances", CreatedAt = DateTime.UtcNow },
                new Category { Id = 5, Name = "Furniture", Description = "Furniture items", CreatedAt = DateTime.UtcNow }
            );

            // Seed Suppliers
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "ABC Electronics", ContactPerson = "John Doe", Email = "john@example.com", Phone = "123456789", Address = "123 Main St" },
                new Supplier { Id = 2, Name = "XYZ Clothing", ContactPerson = "Jane Smith", Email = "jane@example.com", Phone = "987654321", Address = "456 Elm St" },
                new Supplier { Id = 3, Name = "Book World", ContactPerson = "Alice Johnson", Email = "alice@example.com", Phone = "456123789", Address = "789 Oak St" },
                new Supplier { Id = 4, Name = "Home Comfort Appliances", ContactPerson = "Michael Brown", Email = "michael@example.com", Phone = "654987321", Address = "987 Pine St" },
                new Supplier { Id = 5, Name = "Furniture Palace", ContactPerson = "Emily White", Email = "emily@example.com", Phone = "321789654", Address = "654 Cedar St" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Smartphone", Price = 499.99m, Description = "Latest smartphone model", StockQuantity = 100, CreatedAt = DateTime.UtcNow, SupplierId = 1, CategoryId = 1 },
                new Product { Id = 2, Name = "T-Shirt", Price = 19.99m, Description = "Cotton T-Shirt", StockQuantity = 200, CreatedAt = DateTime.UtcNow, SupplierId = 2, CategoryId = 2 },
                new Product { Id = 3, Name = "Novel", Price = 9.99m, Description = "Best-selling novel", StockQuantity = 50, CreatedAt = DateTime.UtcNow, SupplierId = 3, CategoryId = 3 },
                new Product { Id = 4, Name = "Refrigerator", Price = 799.99m, Description = "Large capacity refrigerator", StockQuantity = 20, CreatedAt = DateTime.UtcNow, SupplierId = 4, CategoryId = 4 },
                new Product { Id = 5, Name = "Sofa", Price = 899.99m, Description = "Comfortable sofa set", StockQuantity = 10, CreatedAt = DateTime.UtcNow, SupplierId = 5, CategoryId = 5 }
            );
        }
    }
}
