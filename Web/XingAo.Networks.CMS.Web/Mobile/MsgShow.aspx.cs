using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using XingAo.Core.Data;
using XingAo.Core;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Mobiles
{
    public partial class MsgShow : MobileTemplatePage
    {
        protected string title { get; set; }
        protected Model.ImageMaterial model { get; set; }
        protected string url { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string wguid = string.Empty;
                title = "错误提示";
                int Id = Request.QueryString["Id"].ObjToInt(0);
                if (Id > 0)
                {
                    model = new UnitOfWork().FindSigne<Model.ImageMaterial>(c => c.ID == Id);
                    if (model != null)
                    {
                        title = model.Title;
                        wguid = model.WGuid;
                    }
                    //Model.WeiXin_Account wb = new UnitOfWork().FindAll<Model.WeiXin_Account>().FirstOrDefault();
                    //if (wb != null)
                    //{
                    //    MobileHelp1.setTel = wb.Tel;
                    //    MobileHelp1.color = wb.TitleColor;
                    //}
                   // MobileHelp1.wxid = wguid; 
                    if (Request.UrlReferrer != null)
                    {
                        Uri backurl = Request.UrlReferrer;
                        url = backurl.ToString();
                    }
                    if (url == "")
                        url = new Model.SiteConfig().SiteUrl + "/mobile/website/?wxid=" + wxid;
                }
            }
        }
    }
}