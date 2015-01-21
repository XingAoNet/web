using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    public partial class UserPoint : System.Web.UI.Page
    {
        Model.WebUserLoginModel LoginUser;
        UnitOfWork uk = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser = ((UcMaster)Master).LoginUser;
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        private void ShowData()
        {
            int r = 0;
            GridView1.DataSource = uk.LoadWhereLambda<Model.WebUsersPointInfo>(p => p.UserID == LoginUser.ID, c => c.OrderByDescending(d => d.CreateTime).ThenByDescending(d => d.ID), AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out r);
            AspNetPager1.RecordCount = r;
            GridView1.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
           
            ShowData();
        }
    }
}