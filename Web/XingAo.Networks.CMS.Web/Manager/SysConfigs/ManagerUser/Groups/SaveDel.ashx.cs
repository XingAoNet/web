using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.SysConfigs.ManagerUser.Groups//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_ManagerUserGroup";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.ManagerUserGroup mode;
                if (id > 0)
                    mode = uk.FindSigne<Model.ManagerUserGroup>(p => p.ID == id);
                else
                {
                    mode = new Model.ManagerUserGroup();
                }
                mode.GroupName = context.Request.Form["txtGroupName"];
                mode.Navigation = context.Request.Form["checkbox2"];
                mode.SystemMenu = context.Request.Form["checkbox1"];
                uk.Save(mode, id);
                
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.ManagerUserGroup>(p => ID.Contains(p.ID.ToString()));

            }
            string err = "";
            uk.Commit(out err);
            if (err != "")
            {
                code = "300";
                msg = err;
            }
            else
            {
                #region 重新保存当前用户权限(为了避免重新登录)
                Model.ManagerUserCookiesModel luser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
                if (luser != null && luser.UserID > 0)
                {
                    Model.ManagerUser user = uk.FindSigne<Model.ManagerUser>(p => p.ID == luser.UserID);
                    {
                        if (user != null)
                        {
                            Model.ManagerUserCookiesModel cookies = new Model.ManagerUserCookiesModel();
                            cookies.NavIDList = cookies.MenuIDList = "";  
                            string[] GroupIDs = user.GroupIDs.Split(',');
                            foreach (var group in uk.FindByFunc<Model.ManagerUserGroup>(p => GroupIDs.Contains(p.ID.ToString())))
                            {
                                if (cookies.NavIDList.IndexOf(group.Navigation + ",") < 0)
                                    cookies.NavIDList += group.Navigation + ",";
                                if (cookies.NavIDList.IndexOf(group.SystemMenu + ",") < 0)
                                    cookies.MenuIDList += group.SystemMenu + ",";
                            }
                            cookies.UserID = user.ID;
                            cookies.RealName = user.RealName;
                            CookiesHelp.AddUsersCookies<Model.ManagerUserCookiesModel>(cookies);
                        }

                    }
                }
                #endregion
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