using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.ViewModels
{
    public class ContactVM
    {
        public SiteInfo Social { get; set; }
        public SiteInfo Contact { get; set; }
        public ContactForm ContactForm { get; set; }
        public List<Product> Products { get; set; }
    }
}
