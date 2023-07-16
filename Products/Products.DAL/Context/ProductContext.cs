using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Products.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.DAL.Context
{
    public class ProductContext : IdentityDbContext
    {
        public ProductContext()
        {
                
        }

        public ProductContext(DbContextOptions<ProductContext> opt) : base(opt)
        {
                
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
