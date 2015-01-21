using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using System.Configuration;

namespace XingAo.Networks.CMS.Web.Manager.SysConfigs.SiteSetting//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_SiteConf";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string code = "200", msg = "提交成功！", callbackaction = "";

            Model.SiteConfig conf = new Model.SiteConfig();
            conf.Copyright = context.Request.Form["txtCopyright"];
            conf.Fax = context.Request.Form["txtFax"];
            conf.SiteName = context.Request.Form["txtSiteName"];
            conf.Tel = context.Request.Form["txtTel"];
            conf.SiteUrl = context.Request.Form["txtUrl"];
            conf.ZIP = context.Request.Form["txtZIP"];
            conf.Address = context.Request.Form["txtAddress"];
            conf.ServiceEmail = context.Request.Form["txtServiceEmail"];

            context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
          //  ConfigurationManager.AppSettings["EditTime"] = DateTime.Now.ToString();
            
            //ConfigOption.SetAppSetting("EditTime", DateTime.Now.ToString());
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