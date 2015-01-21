using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.Common
{
    public class BaseEditPage : System.Web.UI.Page
    {
        private string action = "1";
        /// <summary>
        /// 提交操作项
        /// </summary>
        public string Action {
            get {return action; }
            set { action = value; } 
        }

        public string navTab
        {
            get;
            set;
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            Model.ManagerUserCookiesModel user = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
            if (user == null ||user.UserID<=0)
            {
                Response.Clear();
                Response.Write("{\"statusCode\":\"301\",\"message\":\"\u4f1a\u8bdd\u8d85\u65f6\uff0c\u8bf7\u91cd\u65b0\u767b\u5f55\u3002\",\"navTabId\":\"\",	\"callbackType\":\"\",	\"forwardUrl\":\"\"}");
                Response.End();
            }
            if (Request.QueryString.AllKeys.Count() == 0)
                Page.Form.Action = Request.GetPath() + "/SaveDel.ashx?action=" + Action + (string.IsNullOrEmpty(navTab) ? "" : "&navTab=" + navTab);
            else
            {
                string path = Request.GetPath() + "/SaveDel.ashx?action=" + Action + (string.IsNullOrEmpty(navTab) ? "" : "&navTab=" + navTab);
                foreach (string key in Request.QueryString.AllKeys)
                {
                    path += "&"+key+"="+Request.QueryString[key];
                }
                Page.Form.Action = path;
            }
            //string dir = Request.GetPath();
            //ClientScript
            //MessageBox.ResponseScript(this, "var window.UEDITOR_HOME_URL ='"+dir.Substring(0,dir.LastIndexOf("/")+1)+"';");
        }
    }
}