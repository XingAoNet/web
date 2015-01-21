using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Networks.CMS.Template.Engine;

namespace XingAo.Networks.CMS.Web.Order
{
    public partial class PayResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Head.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Head");
            Foot.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Foot");
            ResultTxt.Text = Request.QueryString["msg"];
        }
    }
}