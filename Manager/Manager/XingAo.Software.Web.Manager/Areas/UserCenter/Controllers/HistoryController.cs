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
    public class HistoryController : Controller
    {
        //
        // GET: /UserCenter/History/

        UserHistoryRepository repository = new UserHistoryRepository();
        Pagination pagination = new Pagination();

        public ActionResult Index()
        {
            pagination.PageNum = Request["PageNum"].ObjToInt() == -1 ? 1 : Request["PageNum"].ObjToInt();
            var where = QueryBuilder.Create<OperationLogModel>()
                   .Like(c => c.User.UserName, "");
            IList<OperationLogModel> model = repository.Search(where, p => p.OrderByDescending(m => m.CreateTime), pagination);
            ViewBag.Pagination = pagination;
            return View(model);
        }

    }
}
