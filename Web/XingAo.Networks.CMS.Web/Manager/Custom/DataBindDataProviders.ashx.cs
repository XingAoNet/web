using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using System.Data;

namespace XingAo.Networks.CMS.Web.Manager.Custom
{
    /// <summary>
    /// 数据绑定--数据提供者
    /// </summary>
    public class DataBindDataProviders : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.UrlReferrer.ObjToStr().IndexOf(context.Request.Url.Host) < 0)
                return;
            string[] pars = context.Request["par"].ClearHtml().ClearScripts().HtmlToCode().Split('|');
            string TabName = pars[0];
           
            UnitOfWork uk = new UnitOfWork();
            DataSet ds = uk.ExecSql("select " + pars[1] + "," + pars[2] + " from " + TabName, null);


            string jsgon = new Model.DatabaseModel.ServiceBackModel<Dictionary<string, object>>("", false, ds.Tables[0].ToList(), ds.Tables[0].Rows.Count, ds.Tables[0].Rows.Count).ToJSON();
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
