using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Sources
{
    public partial class BigWheelListPage : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Form.Action = "/Wechat/Sources/BigWheelListPage?wxid=" + "";
                var mywhere = QueryBuilder.Create<Model.BigWheel>().Like(c => c.Title, keyString);
                mywhere = mywhere.Equals(c => c.WGuid, "");
                int r = 0;
                var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.Where(c => c.IsDelete != 1).OrderByDescending(c => c.ID), PageNum, PageSize, out r);
                TotalCount = r;//绑定前必须给总记录数赋值

                var datas = data.Select(c => new { c.BGuid, c.ID, c.Keys, c.Title, c.StartTime, c.EndTime }).ToList();
                Rep_List.DataSource = datas;
                Rep_List.DataBind();
            }
        }
    }
}