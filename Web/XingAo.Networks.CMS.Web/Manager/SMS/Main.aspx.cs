using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Sms
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                List<Model.MemberGroups> list=uk.FindAll<Model.MemberGroups>().OrderBy(c=>c.OrderNum).ToList();
                acclist.DataSource = list;
                acclist.DataBind();
            }
        }
    }
}