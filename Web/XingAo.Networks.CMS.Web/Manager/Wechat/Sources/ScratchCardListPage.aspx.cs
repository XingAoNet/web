using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Sources
{
    public partial class ScratchCardListPage : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var where = QueryBuilder.Create<Model.ScratchCard>().Like(c => c.Title, keyString).Equals(c => c.WGuid, "");
                int r = 0;
                UnitOfWork uk = new UnitOfWork();
                Rep_List.DataSource = uk.LoadWhereLambda(where.Expression, p => p.Where(c => c.IsDelete != 1).OrderByDescending(c => c.ID), PageNum, PageSize, out r).ToList();
                TotalCount = r;//绑定前必须给总记录数赋值
                Rep_List.DataBind();
            }
        }
    }
}