using System;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Template.Engine;

namespace XingAo.Networks.CMS.Web
{
    public partial class Template : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRouteData data = new GetRouteData();
            string Template=data.GetRouteValue("Template");
            if (!string.IsNullOrEmpty(Template))
            {
                Response.Write(TemplateEngine.GetTemplateHtml(Template));
            }
            else
                Response.Write("参数错误");
        }
    }
}