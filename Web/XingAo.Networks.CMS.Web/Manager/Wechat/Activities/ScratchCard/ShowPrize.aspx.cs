using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.ScratchCard
{
    public partial class ShowPrize : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                string sguid = Request.QueryString["sguid"];
                Model.ScratchCard model = new UnitOfWork().FindSigne<Model.ScratchCard>(p => p.SGuid == sguid);
                if (model != null)
                {
                    var mywhere = QueryBuilder.Create<Model.ScratchCard_PrizesLog>().Like(c => c.Editer, keyString);
                    mywhere = mywhere.Equals(c => c.ScratchCardGuid, sguid);
                    int r = 0;
                    var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.OrderByDescending(c => c.ID), PageNum, PageSize, out r);
                    TotalCount = r;//绑定前必须给总记录数赋值
                    var datas = data.Select(c => new { c.ID, c.Editer, c.GoodsName, c.IDateTime }).ToList();
                    Prize_List.DataSource = datas;
                    Prize_List.DataBind();
                }
            }
        }
    }
}