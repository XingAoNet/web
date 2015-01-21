using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Common
{
    public class BaseMemberPage : System.Web.UI.Page
    {
        public string wxid
        {
            get
            {
                return "";
            }
        }

        protected override void OnInit(EventArgs e)
        {
            //Model.ManagerUserCookiesModel user = SessionHelper.ManagerMember;
            //if (user == null || user.UserID <= 0)
            //{
            //    Response.Clear();
            //    Response.Write("{\"statusCode\":\"301\",\"message\":\"\u4f1a\u8bdd\u8d85\u65f6\uff0c\u8bf7\u91cd\u65b0\u767b\u5f55\u3002\",\"navTabId\":\"\",	\"callbackType\":\"\",	\"forwardUrl\":\"/Wechat/mLogin\"}");
            //    Response.End();
            //}
            //base.OnInit(e);
        }
     
    }
}