using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using XingAo.Networks.CMS.Model;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Mobiles
{
    public partial class MsgList : MobileTemplatePage
    {
        public string title = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 string wguid=string.Empty;
                int ArticleChannelId = Request.QueryString["ChannelId"].ObjToInt(0);
                if (ArticleChannelId > 0)
                {
                    UnitOfWork uk = new UnitOfWork();
                    Model.MaterialFamily fam = uk.FindSigne<Model.MaterialFamily>(c => c.ID == ArticleChannelId);
                    if (fam != null)
                    {
                        title = fam.Name;
                        this.Title = title;
                        LiTitle.Text = title;
                        wguid=fam.WGuid;
                    }
                    //Model.WeiWebsite wb = uk.FindSigne<Model.WeiWebsite>(c => c.WGuid == wguid);
                    //if (wb != null)
                    //{
                    //    MobileHelp1.setTel = wb.Tel;                           
                    //}
                    //MobileHelp1.wxid = wguid;
                    ListRp.DataSource = uk.FindByFunc<Model.ImageMaterial>(c => c.ParentID == ArticleChannelId).OrderByDescending(c => c.OrderID);
                    ListRp.DataBind();
                }
            }
        }
    }
}