using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Manager.Common;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.MaterialFamily
{
    public partial class Main : Common.BaseListPage
    {
        UnitOfWork uk = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rep_List.DataSource = SessionHelper.GetMaterialFamilyByWGuid(""); 
                Rep_List.DataBind();
            }
        }
    }
}