using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    [Table("Product")]
    public class Product
    {
        public int ID { get; set; }// id ID Id primary key identity(1,1)

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [StringLength(250), Column(TypeName = "varchar(250)"), Display(Name = "Ürün Açıklaması")]
        public string Description { get; set; }

        [Display(Name = "Stok Miktarı")]
        public int Stock { get; set; }

        [Column(TypeName = "text"), Display(Name = "Ürün Detayı")]
        public string Detail { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime RecDate { get; set; }

        [Display(Name = "Kategorisi")]
        public int? CategoryID { get; set; }//nullable
        public Category Category { get; set; }

        [Display(Name = "Markası")]
        public int? BrandID { get; set; }//nullable
        public Brand Brand { get; set; }

        public ICollection<Picture> Pictures { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
