using Ecommerce.BL.Repositories;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        MSSQLRepo<Category> repoCategory;
        public HeaderViewComponent(MSSQLRepo<Category> _repoCategory)
        {
            repoCategory = _repoCategory;
        }
        public IViewComponentResult Invoke()
        {
            return View(repoCategory.GetAll().OrderBy(o=>o.DisplayIndex));
        }

    }
}
