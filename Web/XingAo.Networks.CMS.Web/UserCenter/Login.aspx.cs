using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    /// <summary>
    /// 用户登录标签 form action处理页面
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserName = Request.Form["Login_User"];
            string pwd = Request.Form["Login_Password"].ToMD5Two();
            string code = Request.Form["Login_VCode"];
            if (Session == null || Session["V_Code"] == null || Session["V_Code"].ToString().ToLower() != code.ToLower())
            {
                MessageBox.ShowAndRedirect(this, "验证码错误");
            }
            else
            {
                UnitOfWork uk = new UnitOfWork();
                Model.WebUsers user = uk.FindSigne<Model.WebUsers>(p => p.UserName == UserName && p.Pwd == pwd);
                if (user != null && user.ID > 0)
                {
                    if (user.Audit == 0)
                    {
                        MessageBox.ShowAndRedirect(this, "用户处于未审核状态，请耐心等待管理员审核！");
                    }
                    else if (user.CanUse != 1)
                    {
                        MessageBox.ShowAndRedirect(this, "此用户已被管理员锁定，无法登录！");
                    }
                    else
                    {
                        Model.WebUserLoginModel cookies = new Model.WebUserLoginModel();
                        cookies.ID = user.ID;
                        cookies.RealName = user.RealName;
                        cookies.UserName = user.UserName;
                        cookies.VipLevel = user.VipLevel;
                        CookiesHelp.AddUsersCookies<Model.WebUserLoginModel>(CookiesHelp.CookiesTypeEnum.WebUser, cookies);
                        string url = string.IsNullOrEmpty(Request.QueryString["url"]) ? Request.UrlReferrer.ObjToStr() : Request.QueryString["url"];
                        if (string.IsNullOrEmpty(url))
                            url = "/UserCenter";
                        Response.Redirect(url);
                    }
                }
                else
                {
                    MessageBox.ShowAndRedirect(this, "用户不存在或密码错误，请重新输入！");
                }
            }
        }
    }
}