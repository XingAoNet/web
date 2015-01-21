using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class WrittenPost : IHttpHandler
    {

        public void ProcessRequest(HttpContext hc)
        {
            hc.Response.ContentType = "text/plain";
            string Name = hc.Request.Form["TxtName"];
            string Tel = hc.Request.Form["TxtTel"];
            string Email = hc.Request.Form["TxtEmail"];
            string address = hc.Request.Form["Txtaddress"];
            string Content = hc.Request.Form["TxtContent"];
            string Title = hc.Request.Form["TxtTitle"];
            UnitOfWork uk = new UnitOfWork();
            Model.Written model = new Model.Written();
            model.Name = Name;
            model.Tel = Tel;
            model.Email = Email;
            model.address = address;
            model.TContent = Content;
            model.Title = Title;
            uk.Save(model, model.Id);
            string info=string.Empty;
            if (uk.Commit(out info) > 0)
            {
                info = "提交成功";
            }
            hc.Response.Write(info); 
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