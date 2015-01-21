using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Networks.CMS.Model;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.SMS.SMSTemplate//----------修改命名空间
{
    /// <summary>
    /// SaveDel1 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_SMSTemplate";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            DateTime now = DateTime.Now;
            UnitOfWork uk = new UnitOfWork();
            Dictionary<string, object> par = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                //----------在些添加服务相关操作
               // XA_SMS_Templates model = new XA_SMS_Templates();
                Model.XA_SMS_Templates model;
                if (id > 0)
                    model = uk.FindSigne<Model.XA_SMS_Templates>(p => p.ID == id);
                else
                {
                    model = new Model.XA_SMS_Templates();
                    model.AddTime = now;
                    model.IDateTime = now;
                }
                model.TemplatesName=context.Request.Form["txtTemplatesName"];
                model.TemplatesContent = context.Request.Form["txtTemplatesContent"];
                model.EditTime = now;
                uk.Save(model, model.ID);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.XA_SMS_Templates>(p => ID.Contains(p.ID.ToString()));  
            }
            string err = "";
            uk.Commit(out err);
            if (err != "")
            {
                code = "300";
                msg = err;
            }
            context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
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