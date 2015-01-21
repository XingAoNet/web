using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using XingAo.Networks.CMS.Model;
using XingAo.Networks.CMS.Model.Enums;
//using XingAo.Networks.CMS.Controller;

namespace XingAo.Networks.CMS.Web.Manager
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            LiInfpo.Text = "";
            if (Session["V_Code"] == null)
            {
                LiInfpo.Text = "验证码过期";
                return;
            }
            string codeTxt = Request.Form["code"];
            if (string.IsNullOrEmpty(codeTxt))
            {
                LiInfpo.Text = "验证码不能为空";
                return;
            }
            if (codeTxt.ToLower() != this.Session["V_Code"].ToString().ToLower())
            {
                LiInfpo.Text = "验证码错误";
                return;
            }

            string username = Request.Form["username"];
            string password = Request.Form["password"].Trim().ToMD5Two();
            UnitOfWork uk = new UnitOfWork();
            Model.ManagerUser user= uk.FindSigne<Model.ManagerUser>(p => p.UserName == username );
            {
                if (user != null)
                {
                    if (user.ErrTimes > 2)
                    {
                        TimeSpan err=new TimeSpan(user.LastErrTime.Ticks);
                        TimeSpan now=new TimeSpan(DateTime.Now.Ticks);

                        if (now.Subtract(err).TotalMinutes <= 30)
                        {
                           LiInfpo.Text = "由于此用户密码输入连续错误3次，此帐户已被禁止登录30分钟！";
                           return;
                        }
                    }
                    if (user.Pwd == password)
                    {
                        if (user.CanUse == 0)
                        {
                            LiInfpo.Text = "由于此用户已被管理员禁用！";
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
                            if (cookies.NavIDList.IndexOf(group.SystemMenu.ToString() + ",") < 0)                         
                                cookies.MenuIDList += group.SystemMenu + ",";
                        }
                        cookies.UserID = user.ID;
                        cookies.RealName = user.RealName;
                        cookies.UserType = UserTypeEnum.swichUserType(user.UserType);
                        cookies.LoginTime = user.LastLogin.ToString("yyyy-MM-dd HH:mm:ss");
                        cookies.LoginNum = user.LoginNum;
                        CookiesHelp.RemoveCookies<ManagerUserCookiesModel>(XingAo.Core.CookiesHelp.CookiesTypeEnum.Manager);
                        CookiesHelp.AddUsersCookies<Model.ManagerUserCookiesModel>(cookies);
                        //跳转主页面
                        Response.Redirect("Main.aspx");
                    }
                    else
                    {
                        user.ErrTimes++;
                        user.LastErrTime = DateTime.Now;
                        uk.Save(user,user.ID);
                        uk.Commit();
                        LiInfpo.Text = "用户名或密码错误！";
                        return;
                    }
                }
                else
                {
                    LiInfpo.Text = "用户名或密码错误！";
                    return;
                }
            }
        }
    }
}
