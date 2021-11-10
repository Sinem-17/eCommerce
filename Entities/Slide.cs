using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    [Table("Slide")]
    public class Slide
    {
        public int ID { get; set; }// id ID Id primary key identity(1,1)

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Slogan")]
        public string Slogan { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Slide Başlığı")]
        public string Title { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Slide Açıklaması")]
        public string Description { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Resim Dosyası")]
        public string Picture { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Ürün Adresi")]
        public string Link { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "Fiyat Bilgisi")]
        public decimal Price { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }

    }
}
