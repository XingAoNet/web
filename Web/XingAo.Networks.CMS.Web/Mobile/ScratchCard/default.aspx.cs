using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Mobile.ScratchCard
{
    public partial class _default : MobileTemplatePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegList.DataSource = new UnitOfWork().FindByFunc<Model.ScratchCard>(c=>c.WGuid==this.wxid).Take(50);
                RegList.DataBind();
            }
        }
    }
}