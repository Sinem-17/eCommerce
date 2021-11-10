using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
