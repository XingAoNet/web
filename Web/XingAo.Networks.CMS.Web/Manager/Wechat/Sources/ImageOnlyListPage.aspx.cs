using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Manager.Wechat.CustomMenu;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Sources
{
    public partial class ImageOnlyListPage : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               //this.Form.Action = "/Wechat/Sources/ImageOnlyListPage?wxid=" + wxid + "&Source=" + Request.QueryString["Source"];
                List<Model.MaterialFamily> data = new UnitOfWork().FindAll<Model.MaterialFamily>().Where(c => c.WGuid == "").ToList();

                Rep_List.DataSource = data;
                Rep_List.DataBind();     
            }
        }
    }
}