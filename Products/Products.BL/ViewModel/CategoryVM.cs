using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Products.BL.ViewModel
{
    public class CategoryVM
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
