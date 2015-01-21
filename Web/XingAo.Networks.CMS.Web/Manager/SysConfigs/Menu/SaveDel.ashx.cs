
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;


namespace XingAo.Networks.CMS.Web.Manager.SysConfigs.Menu//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "CacheManager_SysConfigsMenu";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.SystemMenu model;
                if (id > 0)
                    model = uk.FindSigne<Model.SystemMenu>(p => p.Id == id);
                else
                {
                    model = new Model.SystemMenu();
                }
                model.ParentMenuID = context.Request.Form["drParentMenu"];
                model.NavName = context.Request.Form["txtName"];
                model.MenuID = context.Request.Form["txtEnglishName"];
                model.Url = context.Request.Form["txtUrl"];
                model.Rel = context.Request.Form["txtRel"];
                model.Operation = context.Request.Form["OptionsNum"];
                model.OrderNum = context.Request.Form["txtOrder"].ObjToInt(0);
                model.Target = context.Request.Form["txtTarget"];
                model.IsViewMenu = context.Request.Form["IsViewMenu"].ObjToInt(0);
                uk.Save(model, id);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.SystemMenu>(p => ID.Contains(p.Id.ToString()));
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
