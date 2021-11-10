using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Models
{
    public class Cart
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPicture { get; set; }
        public int Quantity { get; set; }
    }
}
