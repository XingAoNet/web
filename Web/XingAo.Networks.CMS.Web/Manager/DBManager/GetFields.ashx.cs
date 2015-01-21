using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using System.Data;

namespace XingAo.Networks.CMS.Web.Manager.DBManager
{
    /// <summary>
    /// GetFields 的摘要说明
    /// </summary>
    public class GetFields : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Tid = context.Request.QueryString["TID"];
            string TName = context.Request.QueryString["TName"];
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(TName))//查询系统开放字段
            { }
            else//查询用户自定义表字段
            {

                Dictionary<string, object> par = new Dictionary<string, object>();
                par.Add("TableName", "XA_CMS_CustomTableField");
                par.Add("Fields", "ID,FieldName,ChineseName,Description");
                par.Add("Where", "[TID]="+Tid);
                par.Add("OrderBy", "");
                par.Add("PageSize", 99999);
                par.Add("CurrentPage", 1);
                //@TableName nvarchar(99),--表名
                //@Fields nvarchar(1000),--字段集,如果为空则取所有字段,每个字段用,间隔
                //@Where nvarchar(999),--条件,不加where 如果为空则不设置条件
                //@OrderBy nvarchar(99),--排序字符,不要写order by,如果为空则默认以id倒序排序
                //@PageSize int,
                //@CurrentPage int--从1开始
                DataSet ds= uk.ExecDataSetByPro("Pro_GetRecordByPage", par);
                context.Response.Write( ds.Tables[0].ToJSON());                  
               
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
