using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        public int ID { get; set; }// id ID Id primary key identity(1,1)

        [Display(Name = "Ürün ID")]
        public int? ProductID { get; set; }
        public Product Product { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "Ürün Fiyatı")]
        public decimal ProductPrice { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Ürün Resmi")]
        public string ProductPicture { get; set; }

        [Display(Name = "Ürün Miktarı")]
        public int Quantity { get; set; }

        [Display(Name = "Bağlı Olduğu Sipariş")]
        public int OrdersID { get; set; }
        public Orders Orders { get; set; }



    }
}
