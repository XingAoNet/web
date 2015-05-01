using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XingAo.Core.Data;
using System.Collections;
using XingAo.Software.UserCenter.Model;
using XingAo.Core.Web;

namespace XingAo.Software.Web.Manager.Areas.UserCenter.Controllers
{
    public class UserController : Controller
    {
        UnitOfWork uk = new UnitOfWork();
        //
        // GET: /UserCenter/User/

        public ActionResult Index()
        {
            UnitOfWork uk = new UnitOfWork();
            IList<UserModel> userModels = uk.FindAll<UserModel>().ToList();
            return View(userModels);
        }

        public ActionResult Edit(string rel, int id = 0)
        {
            ViewBag.Rel = rel;
            UserModel userModel = uk.FindSigne<UserModel>(u => u.Id == id) ;

            return View(userModel);
        }

        [HttpPost]
        public JsonResult Edit(UserModel model, string rel)
        {
            uk.Save<UserModel>(model, model.Id);
            return Json(MsgResult.SuccessAndClosedDailog("修改成功。", rel));
        }

        [HttpPost]
        public JsonResult Del(int[] ids, string rel)
        {
            if (uk.Remove<UserModel>(u => ids.Contains(u.Id)))
                return Json(MsgResult.Success("删除成功。", rel));
            else
                return Json(MsgResult.Success("删除失败。", rel));
        }

        public ActionResult ChangePassword(string rel, int id)
        {
            ViewBag.Rel = rel;
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public JsonResult ChangePassword(ChangePasswordModel model, string rel, int id)
        {
            UserModel userModel = uk.FindSigne<UserModel>(u => u.Id == id);
            userModel.Password = model.NewPassword;
            uk.Save<UserModel>(userModel, id);
            return Json(MsgResult.SuccessAndClosedDailog("修改成功。", rel));
        }
    }
}
