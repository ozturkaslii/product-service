using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Entities;
using System;

namespace ProductCatalog.API.DbContexts
{
    public class ProductCatalogContext : DbContext
    {
        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Code = "C1476",
                    Name = "Havana Light Grey Jacket",
                    Price = 399.0m,
                    LastUpdated = DateTimeOffset.Now
                },
                new Product
                {
                    Id = 2,
                    Code = "P5752",
                    Name = "Lezio Mid Blue Check Suit",
                    Price = 359.0m,
                    LastUpdated = DateTimeOffset.Now
                },
                new Product
                {
                    Id = 3,
                    Code = "J461LB",
                    Name = "Navy Overcoat",
                    Price = 499.0m,
                    LastUpdated = DateTimeOffset.Now
                },
                new Product
                {
                    Id = 4,
                    Code = "H6049",
                    Name = "Light Blue Stripe Shirt",
                    Price = 99.0m,
                    LastUpdated = DateTimeOffset.Now
                });

            //Set product code as unique
            modelBuilder.Entity<Product>().HasIndex(p => p.Code).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
