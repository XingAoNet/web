using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.Navigation
{
    /// <summary>
    /// GetNavigationEName 的摘要说明
    /// </summary>
    public class GetNavigationEName : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(StringOption.GetChineseFirstPingYing(context.Request["Name"]).Replace(" ", "").Trim().Replace("_", "").Replace("-", "").Replace("/", "").Replace("\\", ""));

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
