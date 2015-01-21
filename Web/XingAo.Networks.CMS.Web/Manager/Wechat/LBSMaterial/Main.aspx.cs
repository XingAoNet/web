using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;
using XingAo.Networks.CMS.Model.DatabaseModel;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.LBSMaterial
{
    public partial class Main : Common.BaseListPage
    {
        UnitOfWork uk = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var mywhere = QueryBuilder.Create<Model.LbsMaterial>().Like(c => c.Title, keyString);
                //Expression<Func<XA_LbsMaterial, bool>> mywhere = a => 1 == 1;
                mywhere = mywhere.Equals(c => c.WGuid, "");
                int r = 0;
                var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.OrderByDescending(c => c.ID), PageNum, PageSize, out r);
                TotalCount = r;//绑定前必须给总记录数赋值
                var datas = data.Select(c => new { c.ID, c.Title, c.TelPhone, c.Longitude, c.Latitude, c.Address, c.IDateTime }).ToList();
                Rep_List.DataSource = datas;
                Rep_List.DataBind();
            }
        }
    }
}