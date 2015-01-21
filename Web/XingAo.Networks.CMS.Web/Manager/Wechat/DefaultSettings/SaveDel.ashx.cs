using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.DefaultSettings//----------修改命名空间
{
    /// <summary>
    /// SaveDel1 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_DefaultSettings";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            string code = "200", msg = "提交成功！", callbackaction = "";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.DefaultSettings mode;
                mode = uk.FindAll<Model.DefaultSettings>().Where(p => p.WGuid == "").FirstOrDefault();
                if (mode == null)
                {
 
                    mode = new Model.DefaultSettings();
                    mode.IDateTime = DateTime.Now;
                    mode.Creater = "";
                    mode.WGuid = "";
                }
                mode.Title = context.Request.Form["txtTitle"];
                mode.PictuerAdress = context.Request.Form["txtHeader"];
                mode.Abstract = context.Request.Form["txtAbstract"];
                mode.IsShow = context.Request.Form["IsShow"].ObjToInt();
                mode.DetailedContent = context.Request.Form["txtContent"];
                mode.Url = context.Request.Form["txtUrl"];
                mode.EditTime = DateTime.Now;
                mode.Editer = "";
                uk.Save(mode, mode.ID);
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