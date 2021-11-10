using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    [Table("ContactForm")]
    public class ContactForm
    {
        public int ID { get; set; }// id ID Id primary key identity(1,1)

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Ad")]
        public string Name { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Soyad")]
        public string Surname { get; set; }

        [StringLength(20), Column(TypeName = "varchar(20)"), Display(Name = "Telefon")]
        public string Phone { get; set; }

        [StringLength(80), Column(TypeName = "varchar(80)"), Display(Name = "Mail Adresi")]
        public string MailAddress { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Konu")]
        public string Subject { get; set; }

        [StringLength(250), Column(TypeName = "varchar(250)"), Display(Name = "Mesaj")]
        public string Message { get; set; }

        [Column(TypeName = "datetime"), Display(Name = "Kayıt Tarihi")]
        public DateTime RecDate { get; set; }

        [StringLength(20), Column(TypeName = "varchar(20)"), Display(Name = "IP")]
        public string IPNO { get; set; }



    }
}
