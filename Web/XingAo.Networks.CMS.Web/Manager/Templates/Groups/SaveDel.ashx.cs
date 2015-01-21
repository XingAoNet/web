using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;


namespace XingAo.Networks.CMS.Web.Manager.Templates.Groups//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "Nav_TemplateGroup";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "300", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            bool IsV = true;
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                string groupName = context.Request.Form["txtTGroupName"];
                if (uk.FindBySpecification<Model.TemplatesGroup>(p => p.Id != id && p.GroupName == groupName).Count() > 0)
                {
                    callbackaction = "";
                    msg = "组名已存在！";
                    IsV = false;
                }

                Model.TemplatesGroup mode;
                if (id > 0)
                    mode = uk.FindSigne<Model.TemplatesGroup>(p => p.Id == id);
                else
                {
                    mode = new Model.TemplatesGroup();
                }
                mode.GroupName = groupName;
                mode.GroupDescribe = context.Request.Form["txtDescription"];
                mode.OrderNum = context.Request.Form["txtOrder"].ObjToInt(999);
                uk.Save(mode, id);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] IDs = context.Request.Form["ids"].Split(',');
                foreach (Model.TemplatesGroup g in uk.FindByFunc<Model.TemplatesGroup>(c => IDs.Contains(c.Id.ToString())).ToList())
                {
                    uk.Remove(g, false);
                }


            }
            string err = "";
            if (IsV)
            {
                if (uk.Commit(out err) > 0)
                    code = "200";
                else
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