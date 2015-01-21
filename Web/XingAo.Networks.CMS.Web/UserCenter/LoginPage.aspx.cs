using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Networks.CMS.Template.Engine;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Head.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Head");
            Foot.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Foot");
            string url = Request.QueryString["url"];
            if (string.IsNullOrEmpty(url))
                url = Request.UrlReferrer.ObjToStr();
            if (string.IsNullOrEmpty(url))
                url = "/";
            this.form1.Action = "/UserCenter/Login?url="+Server.UrlEncode(url);
            this.form1.Method = "post";
            this.form1.Enctype = "application/x-www-form-urlencoded";
            this.form1.ViewStateMode = ViewStateMode.Disabled;
        }
    }
}