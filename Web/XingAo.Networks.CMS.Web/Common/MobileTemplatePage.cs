using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace XingAo.Networks.CMS.Web.Common
{
    public class MobileTemplatePage:Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (Request.Browser.Id != "MicroMessenger")
            {
                //Response.Write("请使用微信访问本网址.");
                //Response.End();
            }
            base.OnInit(e);
        }
        public string wxid
        {
            get
            {
                return Request.QueryString["wxid"];
            }
        }

        public string SiteTel
        {
            get;
            set;
        }
    }
}