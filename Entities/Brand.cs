using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    [Table("Brand")]
    public class Brand
    {
        public int ID { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Marka Adı")]
        public string Name { get; set; }

        [Display(Name = "Görüntüleme Sırası")]
        public int DisplayIndex { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
