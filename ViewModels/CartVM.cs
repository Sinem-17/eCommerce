using Ecommerce.DAL.Entities;
using Ecommerce.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.ViewModels
{
    public class CartVM
    {
        public IEnumerable<Cart> Carts { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
