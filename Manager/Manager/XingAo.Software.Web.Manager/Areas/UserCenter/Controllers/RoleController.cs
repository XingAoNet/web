using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XingAo.Core.Data;
using XingAo.Software.UserCenter.Model;

namespace XingAo.Software.Web.Manager.Areas.UserCenter.Controllers
{
    public class RoleController : Controller
    {
        UnitOfWork uk = new UnitOfWork(); 
        //
        // GET: /UserCenter/Role/

        public ActionResult Index()
        {
            IList<RoleModel> model = uk.FindAll<RoleModel>().ToList();
            return View(model);
        }

    }
}
