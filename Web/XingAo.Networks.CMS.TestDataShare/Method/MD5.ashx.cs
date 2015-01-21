using System;
using System.Web;
using XingAo.Core;

namespace XingAo.Networks.CMS.TestDataShare.Method
{
    /// <summary>
    /// MD5 的摘要说明
    /// </summary>
    public class MD5 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string par0 = context.Request.QueryString["par0"].ToLower();
            string par1 = context.Request.QueryString["par1"];
            string timespan = DateTime.UtcNow.Ticks.ToString();
            string Sign = (par0 + timespan + par1).ToMD5Two();
            context.Response.Write(Sign+"|"+timespan);
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