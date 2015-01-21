using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.DataShare.Users
{
    /// <summary>
    /// MakeKey 的摘要说明
    /// </summary>
    public class MakeKey : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            RSAEncrypt ras = new RSAEncrypt();
            context.Response.Write(ras.PublicKey.EncryptStr() + "^" + ras.PrivateKey);
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
