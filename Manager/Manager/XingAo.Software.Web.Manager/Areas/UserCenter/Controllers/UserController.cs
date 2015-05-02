using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XingAo.Core.Data;
using System.Collections;
using XingAo.Software.UserCenter.Model;
using XingAo.Core;
using XingAo.Core.Web;
using XingAo.Software.UserCenter.Impl;

namespace XingAo.Software.Web.Manager.Areas.UserCenter.Controllers
{
    public class UserController : Controller
    {
        UserRepository repository = new UserRepository();
        Pagination pagination = new Pagination();
        //
        // GET: /UserCenter/User/

        public ActionResult Index()
        {
            pagination.PageNum = Request["PageNum"].ObjToInt() == -1 ? 1 : Request["PageNum"].ObjToInt();
            var where = QueryBuilder.Create<UserModel>()
                   .Like(c => c.UserName, "");
            IList<UserModel> model = repository.Search(where, p => p.OrderByDescending(m => m.RegisterTime), pagination);
            ViewBag.Pagination = pagination;
            return View(model);
        }

        public ActionResult ChangePassword(int id)
        {
            ViewBag.Rel = Request["rel"];
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public JsonResult ChangePassword(ChangePasswordModel model, int id)
        {
            UserModel userModel = repository.FindSign(u => u.Id == id);
            if (userModel != null)
            {
                userModel.Password = model.NewPassword.ToMD5Two();
                repository.Edit(id, userModel);
                return Json(MsgResult.SuccessAndClosedDailog("修改成功。", Request["rel"]));
            }
            else
                return Json(MsgResult.Error("修改的用户不存在。", Request["rel"]));
        }
    }
}
