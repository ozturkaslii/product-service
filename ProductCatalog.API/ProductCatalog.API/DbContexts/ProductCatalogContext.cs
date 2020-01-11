﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Entities;

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
                    Id = Guid.NewGuid(),
                    Code = "C1476",
                    Name = "Havana Light Grey Jacket",
                    Price = 399.0m,
                    LastUpdated = DateTimeOffset.Now
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Code = "P5752",
                    Name = "Lezio Mid Blue Check Suit",
                    Price = 359.0m,
                    LastUpdated = DateTimeOffset.Now
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Code = "J461LB",
                    Name = "Navy Overcoat",
                    Price = 499.0m,
                    LastUpdated = DateTimeOffset.Now
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Code = "H6049",
                    Name = "Light Blue Stripe Shirt",
                    Price = 99.0m,
                    LastUpdated = DateTimeOffset.Now
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}