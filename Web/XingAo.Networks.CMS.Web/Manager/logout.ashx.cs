using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
namespace XingAo.Networks.CMS.Web.Manager
{
    /// <summary>
    /// logout 的摘要说明
    /// </summary>
    public class logout : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpContext.Current.Response.Cookies.Remove("Manager");
            HttpContext.Current.Response.Cookies["Manager"].Expires = DateTime.Now.AddDays(-1);          
            context.Response.Write("<script>try{window.opener=null;}catch(e){}\n try{window.open('','_self');}catch(e){}\n window.close();window.location='/';</script>");
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