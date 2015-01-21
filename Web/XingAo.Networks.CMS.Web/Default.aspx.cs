using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Networks.CMS.Template.Engine;
using System.Text;
using System.Text.RegularExpressions;

namespace XingAo.Networks.CMS.Web
{
    /// <summary>
    /// 首页、列表页、详细内容页  页面内容展现程序
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