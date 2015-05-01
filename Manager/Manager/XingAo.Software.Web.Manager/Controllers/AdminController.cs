using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XingAo.Core.Data;
using XingAo.Software.ConfigCenter;

namespace XingAo.Software.Web.Manager.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            UnitOfWork uk = new UnitOfWork();
            IList<MenuModel> menuModels = uk.FindByFunc<MenuModel>(m => string.IsNullOrEmpty(m.ParentMenuID)).OrderBy(m=>m.OrderNum).ToList();
            ViewData["MenuModel"] = menuModels;
            return View();
        }

        public ActionResult AdminInfo()
        {
            return PartialView();
        }

        public ActionResult Headerbar(string menuId)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Sidebar(string menuId)
        {
            UnitOfWork uk = new UnitOfWork();
            ViewData["MenuName"] = uk.FindSigne<MenuModel>(m => m.MenuID == menuId && m.IsViewMenu > 0);
            if (string.IsNullOrEmpty(menuId))
            {
                ViewData["SubMenuModel"] = uk.FindByFunc<MenuModel>(m => m.NavName == "系统配置中心" && m.IsViewMenu > 0).OrderBy(m => m.OrderNum).ToList();
            }
            else
            {
                ViewData["SubMenuModel"] = uk.FindByFunc<MenuModel>(m => m.ParentMenuID == menuId && m.IsViewMenu > 0).OrderBy(m => m.OrderNum).ToList();
            }
            
            return View();
        }
    }
}
