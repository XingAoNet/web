using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.WebUsers//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_10";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.WebUsers model;
                if (id > 0)
                    model = uk.FindSigne<Model.WebUsers>(p => p.ID == id);
                else
                {
                    model = new Model.WebUsers();
                    string userName = context.Request.Form["txtUserName"];
                    if (uk.FindByFunc<Model.WebUsers>(user => user.UserName == userName).Count() > 0)
                    {
                        code = "300"; msg = "该用户经被注册，请重新确认。";
                        context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
                        return;
                    }
                    else
                    {
                        model.UserName = userName.ClearHtml() ;
                    }

                }
                string pwd = context.Request.Form["txtPwd"].Trim().ToMD5Two();
                if (pwd.Count() > 0)
                {
                    model.Pwd = pwd;
                }
                model.Audit = context.Request.Form["txtAudit"].ObjToInt();
                model.CanUse = context.Request.Form["txtCanUse"].ObjToInt();
                string mobile = context.Request.Form["txtMobile"].ToString();
                if(uk.FindByFunc<Model.WebUsers>(user=>user.Mobile == mobile).Count()>0)
                {
                    code = "300"; msg = "该手机号码已经被注册，请重新确认。";
                    context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
                    return;
                }
                else
                {
                    model.Mobile = mobile;
                }
                string email = context.Request.Form["txtEmail"];
                if (uk.FindByFunc<Model.WebUsers>(user => user.Email == email).Count() > 0)
                {
                    code = "300"; msg = "该邮箱已经被注册，请重新确认。";
                    context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
                    return;
                }
                else
                {
                    model.Email = email;
                }
                model.Points = context.Request.Form["txtPoint"].ObjToLong();
                model.RealName = context.Request.Form["txtRealName"].ClearHtml();
                model.VipLevel = context.Request.Form["txtVipLevel"].ObjToInt();
                model.LastLoginTime = DateTime.Now;
                uk.Save(model, model.ID);
                string err = "";
                uk.Commit(out err);
                if (err != "")
                {
                    code = "300";
                    msg = err;
                }
                context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.WebUsers>(p => ID.Contains(p.ID.ToString()));

            }
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