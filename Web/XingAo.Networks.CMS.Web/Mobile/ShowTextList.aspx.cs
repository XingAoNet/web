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
    public partial class ShowTextList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string wxid = Request.QueryString["wxid"];
            if (wxid !="")
            {
                UnitOfWork uk = new UnitOfWork();
                ListRp.DataSource = uk.FindByFunc<Model.TextMaterial>(c => c.WGuid == wxid);
                ListRp.DataBind();
            }
        }
    }
}