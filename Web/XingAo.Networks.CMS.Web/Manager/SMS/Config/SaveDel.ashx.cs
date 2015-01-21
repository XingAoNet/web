using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.SMS.Config//----------修改命名空间
{
    /// <summary>
    /// SaveDel1 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "SMSSettingsManagement";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string code = "200", msg = "提交成功！", callbackaction = "";
            Model.SMSConfig conf = new Model.SMSConfig();
            conf.PhoneUsername = context.Request.Form["txtPhoneUsername"];
            conf.PhonePassword = context.Request.Form["txtPhonePassword"];
            context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}