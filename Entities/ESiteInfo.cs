using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    public enum ESiteInfo
    {
        [Display(Name = "Sosyal Medya Bilgileri")]
        Social =1,

        [Display(Name = "Site Arka Plan Bilgileri")]
        Meta,

        [Display(Name = "İletişim Bilgileri")]
        Contact
    }
}
