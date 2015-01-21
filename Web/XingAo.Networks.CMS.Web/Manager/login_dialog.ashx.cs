using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using XingAo.Core;
using XingAo.Core.Data;
//using XingAo.Networks.CMS.Controller;
using XingAo.Networks.CMS.Model;
using XingAo.Networks.CMS.Model.Enums;

namespace XingAo.Networks.CMS.Web.Manager
{
    /// <summary>
    /// login_dialog1 的摘要说明
    /// </summary>
    public class login_dialog1 : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            string codeTxt =context.Request.Form["vcode"];

            if (codeTxt.ToLower() != context.Session["V_Code"].ObjToStr().ToLower() && codeTxt.Length > 0)
            {
                code = "300";
                msg = "验证码错误,请重新刷新验证码！";
                context.Session["V_Code"] = null;
            }
            else
            {
                string username =context.Request.Form["username"];
                string password = context.Request.Form["password"].Trim().ToMD5Two();
             
                UnitOfWork uk = new UnitOfWork();
                Model.ManagerUser user = uk.FindSigne<Model.ManagerUser>(p => p.UserName == username);
                {
                    if (user != null)
                    {
                        if (user.ErrTimes > 2)
                        {
                            TimeSpan err = new TimeSpan(user.LastErrTime.Ticks);
                            TimeSpan now = new TimeSpan(DateTime.Now.Ticks);

                            if (now.Subtract(err).TotalMinutes <= 30)
                            {
                                code = "300";
                                msg = "由于此用户密码输入连续错误3次，此帐户已被禁止登录30分钟！";
                                return;
                            }
                        }
                        if (user.Pwd == password)
                        {
                            if (user.CanUse == 0)
                            {
                                code = "300";
                                msg = "由于此用户已被管理员禁用！";
                                return;
                            }
                            Model.ManagerUserCookiesModel cookies = new ManagerUserCookiesModel();
                            cookies.NavIDList = cookies.MenuIDList = "";
                            user.LastLogin = DateTime.Now;
                            user.ErrTimes = 0;
                            user.LoginNum = user.LoginNum + 1;
                            uk.Save(user, user.ID);
                            uk.Commit();
                            
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
                            cookies.UserType = UserTypeEnum.swichUserType(user.UserType);
                            cookies.LoginTime = user.LastLogin.ToString("yyyy-MM-dd HH:mm:ss");
                            cookies.LoginNum = user.LoginNum;
                            CookiesHelp.AddUsersCookies<Model.ManagerUserCookiesModel>(cookies);
                            //跳转主页面
                            context.Response.Write("<script>window.parent.location='main.aspx';</script>");
                            context.Response.End();
                        }
                        else
                        {
                            user.ErrTimes++;
                            user.LastErrTime = DateTime.Now;
                            uk.Save(user, user.ID);
                            uk.Commit();
                            code = "300";
                            msg = "用户不存在或者密码错误！";
                        }
                    }
                    else
                    {
                        code = "300";
                        msg = "用户不存在或者密码错误！";
                    }
                }


            }
                       
            context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");          
            

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
