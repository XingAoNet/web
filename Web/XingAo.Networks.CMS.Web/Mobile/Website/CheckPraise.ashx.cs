using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Mobile.Website
{
    /// <summary>
    /// CheckPraise 的摘要说明
    /// </summary>
    public class CheckPraise : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string msg = string.Empty;
            context.Response.ContentType = "text/plain";
            string key = context.Request.Form["keys"];
            string openid = context.Request.Form["openid"];
            SqlParameter[] parameters = {              
                         new SqlParameter("@keys",SqlDbType.VarChar,500)};
            parameters[0].Value = key;
            parameters[1].Value = openid;
            DataSet ds = MSSQLImp.RunProcedure("MobileCheckPraise", parameters);
            //uk.Commit(out err);
            //if (err == "")
            //{
            //    context.Response.Write("{\"code\":\"200\",\"msg\":\"提交成功\"}");
            //    context.Response.End();
            //}
            //else
            //{
            //    context.Response.Write("{\"code\":\"300\",\"msg\":\"本次提交数据异常:" + err + "\"}");
            //    context.Response.End();
            //}
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