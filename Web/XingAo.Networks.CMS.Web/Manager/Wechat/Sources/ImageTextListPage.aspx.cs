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
    public partial class ImageTextListPage : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                var mywhere = QueryBuilder.Create<Model.ImageMaterial>().Like(c => c.Keys, keyString);
                mywhere = mywhere.Equals(p => p.WGuid, "");
                int r = 0;
                this.PageSize = 10;
                var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.Where(c => c.IsDelete != 1).OrderByDescending(c => c.ID), PageNum, PageSize, out r);
                TotalCount = r;//绑定前必须给总记录数赋值
                var datas = data.Select(c => new { c.Title, c.Keys, c.ID,c.IMGuid }).ToList();
                Rep_List.DataSource = datas;
                Rep_List.DataBind();
            }
        }
    }
}