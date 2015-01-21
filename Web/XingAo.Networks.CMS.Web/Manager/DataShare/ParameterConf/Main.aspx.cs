using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.DataShare.ParameterConf
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int DataShareID = Request["DataShareID"].ObjToInt();

                var where = QueryBuilder.Create<Model.DataShare_ParameterConfig>()
                   .Like(c => c.ParameterName, keyString);


                where = where.Equals(p => p.DataShareID, DataShareID);
                /*
                 * 
                 * 
                 * 以下为高级搜索选项，请自行修改字段名称以及参数值
                 * 
                 * 
                 * 
                //else
                //    if (!string.IsNullOrEmpty(SearchTitle))
                //        where += " and [Title] like '%" + SearchTitle + "%'";
                //if (!string.IsNullOrEmpty(ClassID) && ClassID != "0")
                //    where += " and [ClassId]=" + ClassID;
                //if (!string.IsNullOrEmpty(StartDate))
                //    where += " and [AddTime] >='" + StartDate + "'";
                //if (!string.IsNullOrEmpty(EndDate))
                //    where += " and [AddTime] <='" + EndDate + "'";
                //if (!string.IsNullOrEmpty(SetTop) && SetTop != "0")
                //    where += " and [settop] =" + SetTop;
                //if (!string.IsNullOrEmpty(Pass) && Pass != "0")
                //    where += " and [Pass] =" + Pass;
                 *
                 * 
                 * 
                 */
                int r = 0;
                var data = new UnitOfWork().LoadWhereLambda(where.Expression, p =>p.OrderByDescending(c=>c.ID), PageNum, PageSize, out r);
                TotalCount = r;//绑定前必须给总记录数赋值
                Rep_List.DataSource = data;
                Rep_List.DataBind();
            }
        }
    }
}