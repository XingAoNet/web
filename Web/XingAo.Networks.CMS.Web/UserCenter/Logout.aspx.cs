using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CookiesHelp.RemoveCookies<Model.WebUserLoginModel>(CookiesHelp.CookiesTypeEnum.WebUser);
            Response.Redirect("/");
        }
    }
}