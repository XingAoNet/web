using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.BigWheel
{
    public partial class ShowPrize : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                string bguid = Request.QueryString["bguid"];

                Model.BigWheel model = new UnitOfWork().FindSigne<Model.BigWheel>(p => p.BGuid == bguid);
                if (model != null)
                {
                    //TdHead = model.PerContent;
                    //ColNum = TdHead.Trim(',').Split(',').Length;
                    var mywhere = QueryBuilder.Create<Model.BWWinPrize>().Like(c => c.Editer, keyString);
                    mywhere = mywhere.Equals(c => c.BGuid, bguid);
                    int r = 0;
                    var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.OrderByDescending(c => c.ID), PageNum, PageSize, out r);
                    TotalCount = r;//绑定前必须给总记录数赋值
                    var datas = data.Select(c => new { c.ID, c.Editer, c.Prize, c.IDateTime }).ToList();
                    Prize_List.DataSource = datas;
                    Prize_List.DataBind();
                }
            }
        }
    }
}