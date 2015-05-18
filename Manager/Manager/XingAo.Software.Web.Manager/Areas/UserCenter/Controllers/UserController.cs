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
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ChangePassword(int id)
        {
            ViewBag.Rel = Request["rel"];
            ViewBag.Id = id;
            return View();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 审核用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Audit(int ids)
        {
            UserModel userModel = repository.FindSign(u => u.Id == ids);
            if (userModel != null)
            {
                //审核后用户同时可用
                userModel.Audit = true;
                userModel.Enable = true;
                repository.Edit(ids, userModel);
                return Json(MsgResult.Success("修改成功。", Request["rel"]));
            }
            else
                return Json(MsgResult.Error("修改的用户不存在。", Request["rel"]));
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult IsDel(int ids)
        {
            UserModel userModel = repository.FindSign(u => u.Id == ids);
            if (userModel != null)
            {
                //删除后用户同时禁用
                userModel.IsDel = true;
                userModel.Enable = false;
                repository.Edit(ids, userModel);
                return Json(MsgResult.Success("修改成功。", Request["rel"]));
            }
            else
                return Json(MsgResult.Error("修改的用户不存在。", Request["rel"]));
        }
        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Enable(int ids)
        {
            UserModel userModel = repository.FindSign(u => u.Id == ids);
            if (userModel != null)
            {
                userModel.Enable = false;
                repository.Edit(ids, userModel);
                return Json(MsgResult.Success("修改成功。", Request["rel"]));
            }
            else
                return Json(MsgResult.Error("修改的用户不存在。", Request["rel"]));
        }
    }
}
