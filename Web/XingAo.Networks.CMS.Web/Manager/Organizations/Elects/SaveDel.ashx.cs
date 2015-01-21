using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
//using XingAo.Networks.CMS.Controller;

namespace XingAo.Networks.CMS.Web.Manager.Organizations.Elects//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "Nav_Elect";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "300", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.ManagerUserCookiesModel LogonUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
                Model.OrganizationElect mode;
                if (id > 0)
                    mode = uk.FindSigne<Model.OrganizationElect>(p => p.Id == id);
                else
                {
                    mode = new Model.OrganizationElect();
                    mode.ElectId = System.Guid.NewGuid().ToString("N");
                    mode.IDateTime = DateTime.Now;
                    mode.Creater = LogonUser.RealName;
                }
                mode.ElectDate = Convert.ToDateTime(context.Request.Form["txtDate"]);
                mode.ElectDescribe = context.Request.Form["txtDescription"];
                mode.ElectName = context.Request.Form["txtName"];
                mode.Electhost = context.Request.Form["txthost"];
                mode.EditTime = DateTime.Now;
                mode.Editer = LogonUser.RealName;
                uk.Save(mode, mode.Id);

            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.OrganizationElect>(p => ID.Contains(p.Id.ToString()));

            }
            string err = "";

            if (uk.Commit(out err) > 0)
                code = "200";
            else
                msg = err;

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