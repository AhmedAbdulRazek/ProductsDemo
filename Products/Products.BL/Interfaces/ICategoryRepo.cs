using Products.BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.BL.Interfaces
{
    public interface ICategoryRepo
    {

        public ICollection<CategoryVM> GetAll();

    }
}
