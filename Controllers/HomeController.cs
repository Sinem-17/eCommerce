using Ecommerce.BL.Repositories;
using Ecommerce.DAL.Entities;
using Ecommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        MSSQLRepo<Slide> repoSlide;
        MSSQLRepo<Product> repoProduct;
        MSSQLRepo<SiteInfo> repoSiteInfo;
        public HomeController(MSSQLRepo<Slide> _repoSlide, MSSQLRepo<Product> _repoProduct, MSSQLRepo<SiteInfo> _repoSiteInfo)
        {
            repoSlide = _repoSlide;
            repoProduct = _repoProduct;
            repoSiteInfo = _repoSiteInfo;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Slides = repoSlide.GetAll().OrderBy(o => o.DisplayIndex);
            homeVM.LastProducts = repoProduct.GetAll().Include(i => i.Pictures).OrderByDescending(o => o.RecDate).Take(5);// select top 8 * from product order by recdate desc
            homeVM.SalesProducts = repoProduct.GetAll().Include(i => i.Pictures).OrderByDescending(o => o.RecDate).Skip(5).Take(8).OrderBy(o => Guid.NewGuid());
            homeVM.Meta = repoSiteInfo.GetBy(x => x.ESiteInfo == ESiteInfo.Meta);

            return View(homeVM);
        }

        [Route("/hata/{code}")]
        public IActionResult ErrorPage(string code)
        {
            ViewBag.Code = code;
            return View();
        }
    }

}
