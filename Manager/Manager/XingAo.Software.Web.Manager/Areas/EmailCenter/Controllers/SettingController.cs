using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XingAo.Software.ConfigCenter.Email;
using XingAo.Core.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Software.Web.Manager.Areas.EmailCenter.Controllers
{
    public class SettingController : Controller
    {
        public readonly static string EmailSettingName = "EmailSetting";

        //
        // GET: /EmailCenter/EmailSetting/

        public ActionResult Index()
        {

            
            UnitOfWork uk = new UnitOfWork();
            ConfigCenter.SettingModel model = 
                uk.FindAll<ConfigCenter.SettingModel>().OrderByDescending(p => p.CreateTime).FirstOrDefault();
            return View(model.Value.JsonToObject<EmailSettingModel>());
        }

        /// <summary>
        /// <para>获取配置的Email配置信息</para>
        /// <para>GET : /EmailCenter/EmailSetting/GetEmailSetting/</para>
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEmailSetting()
        {
            UnitOfWork uk = new UnitOfWork();
            ConfigCenter.SettingModel model = uk.FindSigne<ConfigCenter.SettingModel>(s => s.Name == EmailSettingName);
            return Json(model.Value.JsonToObject<EmailSettingModel>());
        }

        [HttpPost]
        public JsonResult Index(EmailSettingModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    //var xx = new { keys = this.ModelState.Keys, values = this.ModelState.Select(m =>new{ise=m.Value.Errors} ).ToList() };
                    //return this.Json(xx)
                    //  return json(  .showerror(this.ModelState);
                    ConfigCenter.SettingModel setting = new ConfigCenter.SettingModel();
                    setting.Name = EmailSettingName;
                    setting.Value = model.ToJSON();
                    setting.CreateTime = DateTime.Now;
                    UnitOfWork uk = new UnitOfWork();
                    uk.Save<ConfigCenter.SettingModel>(setting, setting.UId);
                    return Json(JUIJsonResult.ShowResult("修改成功", "", JUIJsonResult.StateCode.Success, ""));
                }
                return Json(JUIJsonResult.ShowResult("数据验证错误，请确定。", "", JUIJsonResult.StateCode.Err, ""));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
