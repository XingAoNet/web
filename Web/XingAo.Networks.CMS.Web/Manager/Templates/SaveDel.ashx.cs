using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Templates//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState 
    {
        readonly string navTabId = "navTab_Templates";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["ID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();           
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.Templates mode = new Model.Templates();
                mode.ID = context.Request.Form["txtID"].ObjToInt(0);
                mode.TemplateName = context.Request.Form["txtTemplateName"];
                mode.TemplateEName = context.Request.Form["txtTemplateEName"];
                mode.TemplateHtml = context.Request.Form["txtTemplateHtml"];
                mode.TemplateDescription = context.Request.Form["txtTemplateDescription"];
                mode.TemplateType = int.Parse(context.Request.Form["txtTemplateType"]);
                mode.TemplateGroupId = context.Request.Form["TemplateGroup"].ObjToInt(0);

                uk.Save<Model.Templates>(mode, mode.ID);
                
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                //----------在些添加服务相关操作
                Dictionary<string, string> par = new Dictionary<string, string>();
                string IDS = context.Request.Form["ids"];
                uk.Remove<Model.Templates>(p => IDS.Split(',').Contains(p.ID.ToString()));
            }
            string err = "";
            uk.Commit(out err);
            if (err!="")
            {
                code = "300";
                msg = err;
            }
            DataCache.RemoveCache(DataCache.DataCacheType.TempLate);
            DataCache.RemoveCache(DataCache.DataCacheType.AllLabels);
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
