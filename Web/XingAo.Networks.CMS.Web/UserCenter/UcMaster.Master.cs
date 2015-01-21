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
    public partial class UcMaster : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Model.WebUserLoginModel LoginUser { get; set; }
        protected override void OnInit(EventArgs e)
        {
            Model.WebUserLoginModel loginuser = null;
            Head.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Head");
            Foot.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Foot");
            if (CookiesHelp.IsLogin<Model.WebUserLoginModel>(CookiesHelp.CookiesTypeEnum.WebUser, out loginuser))
            {
                LoginUser = loginuser;
                base.OnInit(e);
            }
            else
            {
                Response.Clear();
                Response.Write("<script tyle=\"text/javascript\">alert('未登录或登录超时！');window.location='/UserCenter/UnLogin?url=" + System.Web.HttpContext.Current.Server.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "'</script>");
                Response.End();
                return;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Head.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Head");
            Foot.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Foot");
        }
    }
}