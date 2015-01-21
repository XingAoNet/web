using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.SMS.SMSTemplate
{
    public partial class MainListPage : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                int r = 0;
                var mywhere = QueryBuilder.Create<Model.XA_SMS_Templates>();
                var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.OrderByDescending(c => c.ID), PageNum, PageSize, out r);
                TotalCount = r;//绑定前必须给总记录数赋值
                var datas = data.Select(c => new
                {
                    c.ID,
                    IDateTime = c.IDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    AddTime = c.AddTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    EditTime = c.EditTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    TempContents = c.TemplatesContent.Length > 20 ?
                    c.TemplatesContent.Substring(0, 20) :
                    c.TemplatesContent,
                    TempContent = c.TemplatesContent,
                    c.TemplatesName
                }).ToList();
                Rep_List.DataSource = datas;
                Rep_List.DataBind();
                //Rep_List.DataSource = SessionHelper.GetMaterialFamilyByWGuid(wxid);
                //Rep_List.DataBind();
            }
        }
    }
}