using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.WebUsers
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var where = QueryBuilder.Create<Model.WebUsers>()
                    .Like(c => c.UserName, keyString);

                /*
                 * 
                 * 
                 * 以下为高级搜索选项，请自行修改字段名称以及参数值
                 * 
                 * 
                 *
                
                if (!string.IsNullOrEmpty(ClassID) && ClassID != "0")
                    where = where.And(p => p.xxx = xxxx);
                if (!string.IsNullOrEmpty(StartDate))
                    where = where.And(p => p.xxx = xxxx);
                if (!string.IsNullOrEmpty(EndDate))
                    where = where.And(p => p.xxx = xxxx);
                if (!string.IsNullOrEmpty(SetTop) && SetTop != "0")
                    where = where.And(p => p.xxx = xxxx);
                if (!string.IsNullOrEmpty(Pass) && Pass != "0")
                    where = where.And(p => p.xxx = xxxx);
                 *
                 * 
                 * 
                 */
                int r = 0;
                UnitOfWork uk = new UnitOfWork();
                Rep_List.DataSource = uk.LoadWhereLambda<Model.WebUsers>(where.Expression, p => p.OrderByDescending(c => c.ID), PageNum, PageSize, out r).ToList();
                TotalCount = r;//绑定前必须给总记录数赋值
                Rep_List.DataBind();
            }
        }
    }
}