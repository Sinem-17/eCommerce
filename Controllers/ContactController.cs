using Ecommerce.BL.Repositories;
using Ecommerce.DAL.Entities;
using Ecommerce.Tools;
using Ecommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Controllers
{
    public class ContactController : Controller
    {
        MSSQLRepo<Product> repoProduct;
        MSSQLRepo<SiteInfo> repoSiteInfo;
        MSSQLRepo<ContactForm> repoContantForm;
        public ContactController(MSSQLRepo<SiteInfo> _repoSiteInfo, MSSQLRepo<Product> _repoProduct, MSSQLRepo<ContactForm> _repoContantForm)
        {
            repoProduct = _repoProduct;
            repoSiteInfo = _repoSiteInfo;
            repoContantForm = _repoContantForm;
        }
        public IActionResult Index()
        {
            ContactVM contactVM = new ContactVM {

                Contact = repoSiteInfo.GetBy(g => g.ESiteInfo == ESiteInfo.Contact),
                Social = repoSiteInfo.GetBy(g => g.ESiteInfo == ESiteInfo.Social),
                Products=repoProduct.GetAll().OrderBy(g=>Guid.NewGuid()).Take(4).ToList()
            };

            return View(contactVM);
        }

        [HttpPost]
        public IActionResult Index(ContactVM model)
        {
            model.ContactForm.RecDate = DateTime.Now;
            model.ContactForm.IPNO = HttpContext.Connection.RemoteIpAddress.ToString();
            repoContantForm.Add(model.ContactForm);


            string[] mailto = { "umityazici@gmail.com", "cankeser26@gmail.com",model.ContactForm.MailAddress };
            string body = "Aşağıda bilgileri bulunan ziyaretçinizden mail aldınız<h1/> Adı:" + model.ContactForm.Name + ",Soyadı:" + model.ContactForm.Surname + ",IPNo:"+model.ContactForm.IPNO+"";
            string mailGondermeSonucu = GeneralTool.SendMail("smtp.gmail.com,587","divisimacanta@gmail.com","divisima123","divisimacanta@gmail.com","Divisima Sipariş Hattı",mailto,model.ContactForm.Subject,body);

            return RedirectToAction("Index");
        }
    }
}
