using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Networks.CMS.Common;
using System.Linq.Expressions;
using XingAo.Networks.CMS.DbHelper;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Articles
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var where = QueryBuilder.Create<Model.WeiXin_Article>()
                  .Like(c => c.Title, keyString);

                UnitOfWork uk = new UnitOfWork();
                int totalCount = 0;
                Rep_List.DataSource = uk.LoadWhereLambda<Model.WeiXin_Article>(where.Expression, p => p.OrderByDescending(c => c.Id), PageNum, PageSize, out totalCount).ToList();
                Rep_List.DataBind();

                this.TotalCount = totalCount;

            }
        }
    }
}