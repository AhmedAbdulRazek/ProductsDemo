using Products.BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.BL.Interfaces
{
    public interface IProductRepo
    {

        public IEnumerable<ProductVM> GetAll();
        public IEnumerable<ProductVM> GetAllAfterDuration(); 
        public ProductVM GetById(int id);
        public void Create(CreateProductVM Product);
        public void Edit(ProductVM Product);
        //public IEnumerable<ProductVM> GetProductsByCategory(ProductVM product);
        public IEnumerable<ProductVM> GetProductsByCategoryID(int id);
        public void Delete(int id);

    }
}
