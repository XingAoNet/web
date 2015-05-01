using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Software.ConfigCenter;
using XingAo.Core.Web;
using XingAo.Software.ConfigCenter.Email;

namespace XingAo.Software.Web.Manager.Areas.EmailCenter.Controllers
{
    public class TemplateController : Controller
    {
        EmailTemplateRepository repository = new EmailTemplateRepository();
        Pagination pagination = new Pagination();
        //
        // GET: /EmailCenter/Template/

        public ActionResult Index()
        {
            pagination.PageNum = Request["PageNum"].ObjToInt() == -1 ? 1 : Request["PageNum"].ObjToInt();
            var where = QueryBuilder.Create<EmailTemplateModel>()
                   .Like(c => c.Name, "");
            IList<EmailTemplateModel> model = repository.Search(where, p => p.OrderByDescending(m => m.CreateTime), pagination);
            ViewBag.Pagination = pagination;
            return View(model);
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Rel = Request["rel"];
            return View(repository.FindSign(m => m.Id == id));
        }

        [HttpPost]
        public JsonResult Edit(EmailTemplateModel model)
        {
            repository.Edit(model.Id, model);
            return Json(MsgResult.SuccessAndClosedDailog("修改成功。", Request["rel"]));
        }

        [HttpPost]
        public JsonResult Del(int[] ids)
        {
            if (repository.Delete(u => ids.Contains(u.Id)))
                return Json(MsgResult.Success("删除成功。", Request["rel"]));
            else
                return Json(MsgResult.Success("删除失败。", Request["rel"]));
        }
    }
}
