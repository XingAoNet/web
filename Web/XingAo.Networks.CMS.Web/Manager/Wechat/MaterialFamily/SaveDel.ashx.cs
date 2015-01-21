using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Manager.Common;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.MaterialFamily//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_MaterialFamily";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.MaterialFamily mode;
                if (id > 0)
                    mode = uk.FindSigne<Model.MaterialFamily>(p => p.ID == id);
                else
                {
                    mode = new Model.MaterialFamily();
                    mode.Creater = "";
                    mode.IDateTime = DateTime.Now;
                    mode.WGuid = "";
                }
                mode.Name = context.Request.Form["txtName"];
                mode.OrderID = context.Request.Form["txtOrderID"].ObjToInt();
                mode.ParentID = context.Request.Form["txtParentID"].ObjToInt();
                mode.Describe = context.Request.Form["txtDescribe"];
                mode.Editer = "";
                mode.EditTime = DateTime.Now;
                SessionHelper.RemoveMaterialFamilyByWGuid("");
                uk.Save(mode, mode.ID);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.MaterialFamily>(p => ID.Contains(p.ID.ToString()));
                SessionHelper.RemoveMaterialFamilyByWGuid("");

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
