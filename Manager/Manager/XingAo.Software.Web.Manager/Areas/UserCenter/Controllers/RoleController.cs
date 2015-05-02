using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Software.UserCenter.Model;
using XingAo.Software.UserCenter.Impl;

namespace XingAo.Software.Web.Manager.Areas.UserCenter.Controllers
{
    public class RoleController : Controller
    {
        RoleRepository repository = new RoleRepository();
        Pagination pagination = new Pagination();
        //
        // GET: /UserCenter/Role/

        public ActionResult Index()
        {
            pagination.PageNum = Request["PageNum"].ObjToInt() == -1 ? 1 : Request["PageNum"].ObjToInt();
            var where = QueryBuilder.Create<RoleModel>()
                   .Like(c => c.Name, "");
            IList<RoleModel> model = repository.Search(where, p => p.OrderByDescending(m => m.CreateTime), pagination);
            ViewBag.Pagination = pagination;
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}
