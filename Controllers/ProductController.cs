using Ecommerce.BL.Repositories;
using Ecommerce.DAL.Entities;
using Ecommerce.Tools;
using Ecommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        MSSQLRepo<Product> repoProduct;
        public ProductController( MSSQLRepo<Product> _repoProduct)
        {
            repoProduct = _repoProduct;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/urun/{name}/{id}")]
        public IActionResult Detail(string name ,int id)
        {
            Product product = repoProduct.GetAll(g=>g.ID==id).Include(i=>i.Category).Include(i=>i.Pictures).FirstOrDefault() ?? null;
            if (product != null)
            {
                ProductVM productVM = new ProductVM();
                productVM.Product = product;
                productVM.Products = repoProduct.GetAll(g => g.ID == id).Include(i => i.Category).Include(i => i.Pictures).Take(8).ToList();
                return View(productVM);
            }
             
            else return Redirect("/");
        }

        [Route("/urun/ara")]
        public JsonResult SearchProduct(string _text)
        {
            IEnumerable<Product> products = repoProduct.GetAll(x => x.Name.ToLower().Contains(_text.ToLower()) || x.Description.ToLower().Contains(_text.ToLower())).Include(i => i.Pictures);
            return Json(products.Select(s => new { Link="/urun/"+Tools.GeneralTool.UrlConvert(s.Name)+"/"+ s.ID.ToString(), Resim = s.Pictures.Any()? s.Pictures.FirstOrDefault().PicturePath: "/product/nopicture.jpg", Ad = s.Name }));
        }
    }
}
