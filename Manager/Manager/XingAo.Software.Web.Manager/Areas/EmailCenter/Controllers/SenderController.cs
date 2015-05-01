using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XingAo.Core.Data;
using XingAo.Software.ConfigCenter;
using XingAo.Core;
using XingAo.Core.Web;
using XingAo.Software.UserCenter.Model;
using XingAo.Software.ConfigCenter.Email;
using XingAo.Core.Mail;

namespace XingAo.Software.Web.Manager.Areas.EmailCenter.Controllers
{
    public class SenderController : Controller
    {
        EmailSenderRepository repository = new EmailSenderRepository();
        Pagination pagination = new Pagination();
        UnitOfWork uk = new UnitOfWork();
        //
        // GET: /EmailCenter/Sender/

        public ActionResult Index()
        {
            pagination.PageNum = Request["PageNum"].ObjToInt() == -1 ? 1 : Request["PageNum"].ObjToInt();
            var where = QueryBuilder.Create<EmailSenderModel>()
                   .Like(c => c.Name, "");
            IList<EmailSenderModel> model = repository.Search(where, p => p.OrderByDescending(m => m.SenderTime), pagination);
            ViewBag.Pagination = pagination;
            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.Rel = Request["rel"];
            GetTemplateList();
            GetUserInfoList();
            return View();
        }

        /// <summary>
        /// 获取模板列表
        /// </summary>
        private void GetTemplateList()
        {
            EmailTemplateRepository templateRep = new EmailTemplateRepository();
            IEnumerable<SelectListItem> provinceList = (from t in templateRep.FindAll()
                                                        orderby t.Title
                                                        select new SelectListItem
                                                        {
                                                            Value = t.Id.ToString(),
                                                            Text = t.Title
                                                        }).Distinct();
            List<SelectListItem> Items = new List<SelectListItem>();
            Items.Add(new SelectListItem { Value = "请选择", Text = "--请选择--" });
            Items.AddRange(provinceList);
            ViewBag.EmailTemplate = Items;
        }
        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        private void GetUserInfoList()
        {
            ViewData["UserInfo"] = uk.FindAll<GroupModel>().ToList();
        }

        [HttpPost]
        public JsonResult Add(string[] SendMail, string Acceptors, string template, string Title, string Content)
        {
            foreach(var send in SendMail)
            {
                if (string.IsNullOrEmpty(send))
                    continue;
                repository.SendEmail(send, Title, Content);
            }
            return Json(MsgResult.SuccessAndClosedDailog("发送完成", Request["rel"].ToString()));
        }

        public ActionResult Review(int id)
        {
            EmailSenderModel model = repository.FindSign(m => m.Id == id);
            return View(model);
        }

        public JsonResult Resender(int[] ids)
        {
            foreach (int id in ids)
            {
                EmailSenderModel model = repository.FindSign(m => m.Id == id);
                repository.SendEmail(model.Acceptor, model.Title, model.Content);
            }
            return Json(MsgResult.Success("发送完成", Request["rel"].ToString()));
        }
    }
}
