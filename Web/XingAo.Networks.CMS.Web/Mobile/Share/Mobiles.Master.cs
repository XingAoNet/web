using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Mobile.Share
{
    public partial class Mobiles : System.Web.UI.MasterPage
    {
        public string wxid { get; set; }
        public string setTel { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               string wxid= Request.QueryString["wxid"].ObjToStr();
               //Model.WeiWebsite model=WeiXinSite.GetSiteInfo(wxid);
               //if (model != null)
               //{
               //    setTel = model.Tel;
               //    wxid = model.WGuid;
               //}
            }
        }
    }
}