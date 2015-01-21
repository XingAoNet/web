using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.SysConfigs.ManagerUser//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_ManagerUser";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.ManagerUser model;
                if (id > 0)
                    model = uk.FindSigne<Model.ManagerUser>(p => p.ID == id);
                else
                {
                    model = new Model.ManagerUser();
                    model.ErrTimes = 0;
                    model.LastErrTime = DateTime.Now;
                    model.LastLogin = DateTime.Now;
                }
                model.CanUse=context.Request.Form["txtCanUse"].ObjToInt();
                model.GroupIDs = context.Request.Form["txtGroupIDs"];
                if(!string.IsNullOrEmpty(context.Request.Form["txtPwd"]))
                    model.Pwd  = context.Request.Form["txtPwd"].ToMD5Two();
                 model.RealName = context.Request.Form["txtRealName"];
                 model.UserName = context.Request.Form["txtUserName"];
                model.UserType = context.Request.Form["txtUserType"].ObjToInt();
                if (model.UserType == 0 || model.UserType == 1 && ("," + model.GroupIDs + ",").IndexOf(",1,") < 0)
                {
                    if (string.IsNullOrEmpty(model.GroupIDs))
                        model.GroupIDs = "1";
                    else
                        model.GroupIDs += ",1";
                }
                uk.Save(model, id);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.ManagerUser>(p => ID.Contains(p.ID.ToString()));

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