using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
//using XingAo.Networks.Core.Data;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.DataShare
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var where = QueryBuilder.Create<Model.DataShare>()
                   .Like(c => c.MethodName, keyString);
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
                UnitOfWork uk = new UnitOfWork();              
                
                int r = 0;
                var data = uk.LoadWhereLambda<Model.DataShare>(where.Expression,p=>p.OrderByDescending(c=>c.ID), PageNum, PageSize, out r);

                TotalCount = r;//绑定前必须给总记录数赋值
                Rep_List.DataSource = data.ToList();
                Rep_List.DataBind();

            }
        }
        public string GetMethodType(string t)
        {
            switch (t.ObjToInt())
            {
                case 1:
                    return "数据列表";
                    case 2:
                    return "取单条数据";
                    case 3:
                    return "更新数据";
                    case 4:
                    return "删除数据";
                default:
                    return "未知";
            }
        }
    }
}