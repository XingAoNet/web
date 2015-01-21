using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.AutoReply
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var where = QueryBuilder.Create<Model.WeiXin_Reply>()
                   .Like(c => c.Title, keyString);

                UnitOfWork uk = new UnitOfWork();
                int totalCount = 0;
                Rep_List.DataSource = uk.LoadWhereLambda<Model.WeiXin_Reply>(where.Expression, p => p.OrderByDescending(c => c.Id), PageNum, PageSize, out totalCount).ToList();
                Rep_List.DataBind();

                this.TotalCount = totalCount;
            }
        }
    }
}