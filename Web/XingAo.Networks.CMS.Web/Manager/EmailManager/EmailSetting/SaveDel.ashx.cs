using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.EmailManager.EmailSetting//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "MailSettingsManagement";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            Model.Email.EmailSettingModel model = new Model.Email.EmailSettingModel();
            model.SendAccount = context.Request.Form["txtSendAccount"];
            model.SendName = context.Request.Form["txtSendName"];
            model.SendPwd = context.Request.Form["txtSendPwd"];
            model.SMPTServer = context.Request.Form["txtSMPTServer"];
            model.SMTPPort = context.Request.Form["txtSMTPPort"].ObjToInt(25) ;
            model.SmtpValidation = context.Request.Form["txtSmtpValidation"].ObjToInt(0);

            string code = "200", msg = "提交成功！", callbackaction = "";
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