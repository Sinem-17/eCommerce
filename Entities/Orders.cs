using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    [Table("Orders")]
    public class Orders
    {
        public int ID { get; set; }// id ID Id primary key identity(1,1)

        [StringLength(10), Column(TypeName = "varchar(10)"), Display(Name = "Sipariş Numarası")]
        public string OrderNumber { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Adres")]
        public string Address { get; set; }

        [StringLength(80), Column(TypeName = "varchar(80)"), Display(Name = "Mail Adresi")]
        public string MailAddress { get; set; }

        [StringLength(20), Column(TypeName = "varchar(20)"), Display(Name = "Telefon")]
        public string Phone { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Ülke")]
        public string Country { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Şehir")]
        public string City { get; set; }

        [StringLength(10), Column(TypeName = "varchar(10)"), Display(Name = "Posta Kodu")]
        public string PostalCode { get; set; }

        [ Column(TypeName = "decimal(18,2)"), Display(Name = "Kargo Ücreti")]
        public decimal CargoPrice { get; set; }

        [Display(Name = "Ödeme Seçeneği")]
        public EPaymentOptions PaymentOption { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        public DateTime RecDate { get; set; }

        [StringLength(20), Column(TypeName = "varchar(20)"), Display(Name = "Sipariş verdiği IP No")]
        public string LastIPNO { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }



    }
}
