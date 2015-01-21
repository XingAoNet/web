using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Manager.Wechat.CustomMenu;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Sources
{
    public partial class ActivitiesListPage : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Form.Action = "/Wechat/Sources/ActivitiesListPage?wxid=" + "";
                MaterialFamily.Edit.mflists(MaterialFamilyDr, "");

                var mywhere = QueryBuilder.Create<Model.Activities>().Like(c => c.Title, keyString);
                mywhere = mywhere.Equals(c => c.WGuid, "");
                int r = 0;
                var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.Where(c => c.IsDelete != 1).OrderByDescending(c => c.ID), PageNum, PageSize, out r);
                TotalCount = r;//绑定前必须给总记录数赋值

                var datas = data.Select(c => new { c.AGuid,c.ID, c.Keys, c.Title,  c.StartTime, c.EndTime, c.PersonNum }).ToList();
                Rep_List.DataSource = datas;
                Rep_List.DataBind();     
            }
        }
    }
}