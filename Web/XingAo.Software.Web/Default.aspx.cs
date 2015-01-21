using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Networks.CMS.Template.Engine;

namespace XingAo.Software.Web
{
    /// <summary>
    /// 前台默认首页,模板页面都是通过该页面映射；
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(TemplateEngine.GetPageHtml());
            Response.End();
        }
    }
}