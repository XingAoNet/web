using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XingAo.Software.Web.Service.UserCenter.Accout
{
    /// <summary>
    /// 注册
    /// </summary>
    public class Register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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