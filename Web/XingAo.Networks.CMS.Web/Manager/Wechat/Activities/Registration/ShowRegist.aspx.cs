using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.Registration
{
    public partial class ShowRegist : Common.BaseListPage
    {
        public string GetTdHead(string str,int tdType)
        {
            if (string.IsNullOrEmpty(str)) return "";
            StringBuilder trs = new StringBuilder();
            string[] tds = str.Trim(',').Split(',');
            string CellHtml = string.Empty;
            for (int c = 0; c < ColNum; c++)
            {
                CellHtml = c > tds.Length-1 ? "" : tds[c];
                if (tdType == 0)
                    trs.AppendLine("<th>" + CellHtml + "</th>");
                else
                    trs.AppendLine("<td>" + CellHtml + "</td>"); 
            }
            return trs.ToString();
        }

        int ColNum = 0;

        protected string TdHead { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                string aguid = Request.QueryString["aguid"];

                Model.Activities model = new UnitOfWork().FindSigne<Model.Activities>(p => p.AGuid == aguid);
                if (model != null)
                {
                    TdHead = model.PerContent.ObjToStr();
                    ColNum = TdHead.Trim(',').Split(',').Length;
                    var mywhere = QueryBuilder.Create<Model.Registration>().Like(c => c.Name, keyString);
                    mywhere = mywhere.Equals(c => c.AGuid, aguid);
                    int r = 0;
                    var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.OrderByDescending(c => c.ID), PageNum, PageSize, out r);
                    TotalCount = r;//绑定前必须给总记录数赋值
                    var datas = data.Select(c => new { c.ID, c.Name, c.Telphone, c.Address }).ToList();
                    Rep_List.DataSource = datas;
                    Rep_List.DataBind();
                }
            }
        }
    }
}