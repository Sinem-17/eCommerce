using Ecommerce.BL.Repositories;
using Ecommerce.DAL.Entities;
using Ecommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        MSSQLRepo<SiteInfo> repoSiteInfo;
        public FooterViewComponent(MSSQLRepo<SiteInfo> _repoSiteInfo)
        {

            repoSiteInfo = _repoSiteInfo;
        }
        public IViewComponentResult Invoke()
        {
            FooterVM footerVM = new FooterVM{
                Social=repoSiteInfo.GetBy(g=>g.ESiteInfo==ESiteInfo.Social),//linq lambda expression
                Contact=repoSiteInfo.GetBy(g=>g.ESiteInfo==ESiteInfo.Contact)
            };
            return View(footerVM);
        }
    }
}
