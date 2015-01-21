using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Data;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.DBManager.Fields
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string where = " [TID]="+Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(keyString))
                    where += " and [FieldName] like '%" + base.keyString + "%' or [ChineseName] like '%" + base.keyString + "%'";
                /*
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
                 
                 */
                UnitOfWork uk = new UnitOfWork();
                Dictionary<string, object> par = new Dictionary<string, object>();
                par.Add("TableName", "XA_CMS_CustomTableField");
                par.Add("Fields", "");
                par.Add("Where", where);
                par.Add("OrderBy", "IsSystemField desc,ShowFormEditIndex desc,ShowListIndex desc,ID desc");
                par.Add("PageSize", PageSize);
                par.Add("CurrentPage", PageNum);
                //@TableName nvarchar(99),--表名
                //@Fields nvarchar(1000),--字段集,如果为空则取所有字段,每个字段用,间隔
                //@Where nvarchar(999),--条件,不加where 如果为空则不设置条件
                //@OrderBy nvarchar(99),--排序字符,不要写order by,如果为空则默认以id倒序排序
                //@PageSize int,
                //@CurrentPage int--从1开始
                DataSet ds=uk.GetProDataSet("Pro_GetRecordByPage", par);

              
                    TotalCount = ds.Tables[1].Rows[0][0].ObjToInt();//绑定前必须给总记录数赋值
                    Rep_List.DataSource = ds.Tables[0];
                    Rep_List.DataBind();
               
            }
        }
    }
}