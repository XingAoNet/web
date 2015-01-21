using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Members
{
    public partial class LookForMember : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rep_List.DataSource = new UnitOfWork().FindAll<Model.MemberGroups>().OrderBy(c => c.Id).ToList();
                Rep_List.DataBind();
            }
        }
    }
}