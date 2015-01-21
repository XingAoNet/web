using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
//using XingAo.Networks.CMS.Controller;

namespace XingAo.Networks.CMS.Web.Manager
{
    public partial class ChangePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Model.ManagerUserCookiesModel loginUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
                if (loginUser == null || loginUser.UserID<=0)
                {
                    Response.Clear();
                    Response.Write("{\"statusCode\":\"301\",\"message\":\"\u4f1a\u8bdd\u8d85\u65f6\uff0c\u8bf7\u91cd\u65b0\u767b\u5f55\u3002\",\"navTabId\":\"\",	\"callbackType\":\"\",	\"forwardUrl\":\"\"}");
                    Response.End();
                }
            }
        }
    }
}