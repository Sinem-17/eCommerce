using Ecommerce.BL.Repositories;
using Ecommerce.DAL.Entities;
using Ecommerce.WebUI.Models;
using Ecommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Controllers
{
    public class CartController : Controller
    {
        MSSQLRepo<Product> repoProduct;
        MSSQLRepo<Orders> repoOrders;
        MSSQLRepo<OrderDetail> repoOrderDetail;
        public CartController(MSSQLRepo<Product> _repoProduct, MSSQLRepo<Orders> _repoOrders, MSSQLRepo<OrderDetail> _repoOrderDetail)
        {
            repoOrderDetail = _repoOrderDetail;
            repoOrders = _repoOrders;
            repoProduct = _repoProduct;
        }
        [Route("/Sepetim")]
        public IActionResult Index()
        {
            CartVM cartVM = new CartVM
            {
                Carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"]),
                Products = repoProduct.GetAll().Include(i => i.Pictures).OrderBy(o => Guid.NewGuid()).Take(4)
            };
            return View(cartVM);
        }
        public IActionResult AddProduct(int _productID, int _quantity)
        {
            Product product = repoProduct.GetAll(g => g.ID == _productID).Include(i=>i.Pictures).FirstOrDefault() ?? null;
            if (product != null)
            {
                List<Cart> carts;
                string firstPicture = product.Pictures.FirstOrDefault().PicturePath ?? "/product/nopicture.jpg";
                Cart cart = new Cart { ProductID = product.ID, ProductName = product.Name, ProductPrice = product.Price, Quantity = _quantity,ProductPicture=firstPicture };
                if (Request.Cookies["SepetCookie"] == null) carts = new List<Cart>();
                
                else
                {
                    carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"]);
                    foreach (Cart c in carts)
                    {
                        if (c.ProductID == _productID) c.Quantity = _quantity;
                        
                    }
                }
                carts.Add(cart);
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("SepetCookie", JsonConvert.SerializeObject(carts), cookieOptions);
                return Content(product.Name);

            }
            else return Redirect("/");
        }

        public int GetProductCount()
        {
            if (Request.Cookies["SepetCookie"] == null) return 0;
            else
            {
                List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"]);
                return carts.Sum(s=>s.Quantity);
            }

        }

        [Route("/Sepetim/SiparisiTamamla")]
        public IActionResult Checkout()
        {
            CartCheckoutVM cartCheckoutVM = new CartCheckoutVM
            {
                Carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"])
            };

            return View(cartCheckoutVM);
        }
        [Route("/Sepetim/SiparisiTamamla"),HttpPost]
        public IActionResult Checkout(CartCheckoutVM model)
        {
            string lastID = "1";
            if (repoOrders.GetAll().Any()) lastID = repoOrders.GetAll().OrderByDescending(O=>O.ID).First().ID.ToString();
            model.Orders.OrderNumber = lastID + DateTime.Now.Second.ToString() + lastID + DateTime.Now.Minute.ToString() + lastID + DateTime.Now.Hour.ToString();
            model.Orders.LastIPNO = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            model.Orders.RecDate = DateTime.Now;
            repoOrders.Add(model.Orders);

            List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"]);
            if (carts.Any())
            {
                foreach (Cart c in carts)
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrdersID = model.Orders.ID,
                        ProductID = c.ProductID,
                        ProductName=c.ProductName,
                        ProductPicture=c.ProductPicture,
                        Quantity=c.Quantity,
                        ProductPrice=c.ProductPrice
                        
                    };
                    repoOrderDetail.Add(orderDetail);
                }
            }
            Response.Cookies.Delete("SepetCookie");

            return Redirect("/");
        }

    }
    

}
