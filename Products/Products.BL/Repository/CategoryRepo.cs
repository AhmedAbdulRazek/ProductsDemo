using Products.BL.Interfaces;
using Products.BL.ViewModel;
using Products.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.BL.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ProductContext ProductContext;

        public CategoryRepo(ProductContext ProductContext)
        {
            this.ProductContext = ProductContext;
        }
        public ICollection<CategoryVM> GetAll()
        {
            var Categories = ProductContext.Categories.Select(c => new CategoryVM()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return Categories;

        }
    }
}
