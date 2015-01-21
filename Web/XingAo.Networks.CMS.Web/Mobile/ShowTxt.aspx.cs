using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Mobile
{
    public partial class ShowTxt : System.Web.UI.Page
    {
        public string count = string.Empty;
        public string SiteTel = string.Empty;
        public string titlecolor = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Id = Request.QueryString["Id"].ObjToInt(0);
                if (Id > 0)
                {
                    UnitOfWork uk = new UnitOfWork();
                    string wxid = Request.QueryString["wxid"];
                    Model.TextMaterial Materials = uk.FindSigne<Model.TextMaterial>(c => c.ID == Id);
                   // Model.WeiWebsite website = uk.FindSigne<Model.WeiWebsite>(c => c.WGuid == wxid);
                    //if (website != null)
                    //{
                    //    SiteTel = website.Tel;
                    //    this.Title = website.Title;
                    //    titlecolor = website.TitleColor;
                    //}
                    //if (Materials != null)
                    //    count = Materials.ReplyContent;
                    //MobileHelp1.color = titlecolor;
                    //MobileHelp1.setTel = SiteTel;
                    //MobileHelp1.wxid = wxid;
                }
            }
        }
    }
}