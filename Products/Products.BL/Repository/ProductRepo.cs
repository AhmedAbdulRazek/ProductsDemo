using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Products.BL.Interfaces;
using Products.BL.ViewModel;
using Products.DAL.Context;
using Products.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Products.BL.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductContext ProductContext;
        private readonly IHttpContextAccessor HttpContextAccessor;
        private readonly UserManager<IdentityUser> UserManager;

        public ProductRepo(ProductContext ProductContext, IHttpContextAccessor HttpContextAccessor, UserManager<IdentityUser> UserManager)
        {
            this.ProductContext = ProductContext;
            this.HttpContextAccessor = HttpContextAccessor;
            this.UserManager = UserManager;
        }

        public IEnumerable<ProductVM> GetAll()
        {

            var Products = ProductContext.Products.Include(s => s.Category).Select(p => new ProductVM()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CreationDate = p.CreationDate,
                StartDate = p.StartDate,
                Duration = p.Duration,
                CategoryName = p.Category.Name,
                UserName = p.User.UserName,
                UserId = p.UserId
            });

            return Products;
            
        }

        public IEnumerable<ProductVM> GetAllAfterDuration()
        {
            
            double TotalDays = (DateTime.Now.Year * 365) + (DateTime.Now.Month * 30) + DateTime.Now.Day;

            var Products = ProductContext.Products.Include(s => s.Category)
                .Where(a => (a.StartDate.Year * 365 + a.StartDate.Month * 30 + a.StartDate.Day + a.Duration) > TotalDays)
                .Select(p => new ProductVM()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CreationDate = p.CreationDate,
                    StartDate = p.StartDate,
                    Duration = p.Duration,
                    CategoryName = p.Category.Name,
                    UserName = p.User.UserName,
                    UserId = p.UserId
                }).ToList();

            return Products;
            
        }

        public ProductVM GetById(int id)
        {
            var Product = ProductContext.Products.Include(s => s.Category).Where(d => d.Id == id).Select(p => new ProductVM()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CreationDate = p.CreationDate,
                StartDate = p.StartDate,
                Duration = p.Duration,
                CategoryName = p.Category.Name,
                UserName = p.User.UserName,
                UserId = p.UserId
            }).FirstOrDefault();

            return Product;
        }
        public void Create(CreateProductVM Product)
        {

            string Id = HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Product Obj = new Product()
            {
                Name = Product.Name,
                Price = Product.Price,
                CreationDate = DateTime.Now,
                StartDate = Product.StartDate,
                Duration = Product.Duration,
                CategoryID = Product.CategoryID,
                UserId = Id
            };

            ProductContext.Products.Add(Obj);
            ProductContext.SaveChanges();
        }

        public void Edit(ProductVM Product)
        {

            Product OldProduct = ProductContext.Products.Find(Product.Id);

            OldProduct.Name = Product.Name;
            OldProduct.Price = Product.Price;
            OldProduct.CreationDate = Product.CreationDate;
            OldProduct.StartDate = Product.StartDate;
            OldProduct.Duration = Product.Duration;
            OldProduct.CategoryID = Product.CategoryID;
            OldProduct.UserId = Product.UserId;

            ProductContext.SaveChanges();

        }

        //public IEnumerable<ProductVM> GetProductsByCategory(ProductVM Product)
        //{
        //    int CategoryId = Product.CategoryID;
        //    var Products =  ProductContext.Products.Where(e => e.CategoryID == CategoryId)
        //        .Select(p => new ProductVM()
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            Price = p.Price,
        //            CreationDate = p.CreationDate,
        //            StartDate = p.StartDate,
        //            Duration = p.Duration,
        //            CategoryName = p.Category.Name,
        //            UserName = p.User.UserName,
        //            UserId = p.UserId
        //        }).ToList();

        //    return Products;

        //}


        public IEnumerable<ProductVM> GetProductsByCategoryID(int id)
        {

            double TotalDays = (DateTime.Now.Year * 365) + (DateTime.Now.Month * 30) + DateTime.Now.Day;
            ////.Where(e => e.CategoryID == id )
            var Products = ProductContext.Products
                .Where(a => (a.CategoryID == id) && (a.StartDate.Year * 365 + a.StartDate.Month * 30 + a.StartDate.Day + a.Duration) > TotalDays)
                .Select(p => new ProductVM()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CreationDate = p.CreationDate,
                    StartDate = p.StartDate,
                    Duration = p.Duration,
                    CategoryName = p.Category.Name,
                    UserName = p.User.UserName,
                    UserId = p.UserId
                }).ToList();

            return Products;

        }


        public void Delete(int id)
        {
            Product Product = ProductContext.Products.Find(id);

            ProductContext.Products.Remove(Product);
            ProductContext.SaveChanges();
        }

        
       
    }
}
