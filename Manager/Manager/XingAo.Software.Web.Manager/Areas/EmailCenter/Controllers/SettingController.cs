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
        //
        // GET: /EmailCenter/Setting/

        public ActionResult Index()
        {
            EmailSettingRepository repository = new EmailSettingRepository();
            return View(repository.GetLastEmailSetting());
        }
        [HttpPost]
        public JsonResult Index(EmailSettingModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    EmailSettingRepository repository = new EmailSettingRepository();
                    repository.Add(model);
                    return Json(JUIJsonResult.ShowResult("修改成功", "", JUIJsonResult.StateCode.Success, ""));
                }
                return Json(JUIJsonResult.ShowResult("数据验证错误，请确定。", "", JUIJsonResult.StateCode.Err, ""));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// <para>获取配置的Email配置信息</para>
        /// <para>GET : /EmailCenter/Setting/GetEmailSetting/</para>
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEmailSetting()
        {
            EmailSettingRepository repository = new EmailSettingRepository();
            return Json(repository.GetLastEmailSetting());
        }
    }
}
