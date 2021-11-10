using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    [Table("Picture")]
    public class Picture
    {
        public int ID { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Resim Adı")]
        public string Name { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Resim Yolu")]
        public string PicturePath { get; set; }

        [Display(Name = "Görüntüleme Sırası")]
        public int DisplayIndex { get; set; }

        [Display(Name = "Bağlı Olduğu Ürün")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }

}
