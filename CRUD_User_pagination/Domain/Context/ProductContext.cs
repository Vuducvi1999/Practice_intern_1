using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> db) : base(db) { }

    }
}
