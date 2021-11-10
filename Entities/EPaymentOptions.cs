using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    public enum EPaymentOptions
    {
        [Display(Name = "Kredi Kartı ile Ödeme")]
        KrediKartı =1,

        [Display(Name = "Havale-EFT ile Ödeme")]
        HavaleEFT,

        [Display(Name = "Kapıda Ödeme")]
        KapıdaOdeme
    }
}
