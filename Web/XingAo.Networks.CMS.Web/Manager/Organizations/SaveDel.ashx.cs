using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
//using XingAo.Networks.CMS.Controller;

namespace XingAo.Networks.CMS.Web.Manager.Organizations//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_Organization";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "300", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            bool IsV = true;
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                string No = context.Request.Form["txtNo"];
                string ElectId = context.Request.Form["txtElectId"];
                #region 验证密码
                if (uk.FindBySpecification<Model.Organization>(p => p.Id != id && p.ElectId == ElectId && p.OrgCode == No).Count() > 0)
                {
                    callbackaction = "";
                    msg = "编号已存在！";
                    IsV = false;
                }

                #endregion

                if (IsV)
                {
                    Model.ManagerUserCookiesModel LogonUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
                    Model.Organization mode;
                    if (id > 0)
                        mode = uk.FindSigne<Model.Organization>(p => p.Id == id);
                    else
                    {
                        mode = new Model.Organization();
                        mode.ElectId = ElectId;
                        mode.IDateTime = DateTime.Now;
                        mode.Creater = LogonUser.RealName;
                    }
                    mode.OrgDescribe = context.Request.Form["txtDescription"];
                    mode.OrgCode = No;
                    mode.OrgName = context.Request.Form["txtName"];
                    mode.EditTime = DateTime.Now;
                    mode.Editer = LogonUser.RealName;
                    uk.Save(mode, mode.Id);
                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.Organization>(p => ID.Contains(p.Id.ToString()));

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