using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Manager.Common;

namespace XingAo.Networks.CMS.Web.Manager.SysConfigs.ManagerUser.Groups
{
    public partial class SimpleMain : BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rep_List.DataSource = new UnitOfWork().FindAll<Model.ManagerUserGroup>().ToList();
                Rep_List.DataBind();
            }
        }
    }
}