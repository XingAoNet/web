using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager//----------修改命名空间
{
    /// <summary>
    /// ChangePwd 的摘要说明
    /// </summary>
    public class ChangePwdDo : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_DataShareUser";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            Model.ManagerUserCookiesModel cookuser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
            if (cookuser == null || cookuser.UserID<=0)
            {
                code = "301";
                msg = "登录超时！";
            }
            else
            {
                UnitOfWork uk = new UnitOfWork();
                Model.ManagerUser Luser = uk.FindSigne<Model.ManagerUser>(p => p.ID == cookuser.UserID);
                if (context.Request.Form["oldPassword"].ToMD5Two() == Luser.Pwd)
                {
                    Luser.Pwd = context.Request.Form["newPassword"].ToMD5Two();
                    string err = "";
                    uk.Commit(out err);
                    if (err != "")
                    {
                        code = "300";
                        msg = err;
                        callbackaction = "";
                    }
                }
                else
                {
                    code = "300";
                    msg = "旧密码错误！";
                    callbackaction = "";
                }                                
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
