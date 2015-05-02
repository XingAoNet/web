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
    public class PointRecordController : Controller
    {
        //
        // GET: /UserCenter/PointRecord/

        PointRecordRepository repository = new PointRecordRepository();
        Pagination pagination = new Pagination();

        public ActionResult Index()
        {
            pagination.PageNum = Request["PageNum"].ObjToInt() == -1 ? 1 : Request["PageNum"].ObjToInt();
            var where = QueryBuilder.Create<PointRecordModel>()
                   .Like(c => c.User.UserName, "");
            IList<PointRecordModel> model = repository.Search(where, p => p.OrderByDescending(m => m.CreateTime), pagination);
            ViewBag.Pagination = pagination;
            return View(model);
        }


    }
}
