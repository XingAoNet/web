using System.Collections.Generic;
using XingAo.Core;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel
{
    /// <summary>
    /// 用户状态标签
    /// </summary>
   public  class TopUserState
    {
       /// <summary>
       /// 取用户登录后或未登录时的相关html
       /// </summary>
       /// <returns></returns>
       public  string UserLogin()
       {
           Model.WebUserLoginModel user;
           string Template = "";
           List<object> par = new List<object>();
           if (CookiesHelp.IsLogin<Model.WebUserLoginModel>(CookiesHelp.CookiesTypeEnum.WebUser, out user))//已登录状态
           {
               Template = FileOption.ReadFile("/Templates/LabelFormatTemplates/TopUserLogined.htm");
               int index = Template.LastIndexOf("{注释线-");
               if (index > 0)
                   Template = Template.Substring(0, index);
               //{0}--用户名
               //{1}--真实姓名
               //{2}--用户中心链接地址
               //{3}--安全退出链接地址
               //{4}--修改密码链接地址
               par.Add(user.UserName);
               par.Add(user.RealName);
               par.Add("/UserCenter");
               par.Add("/UserCenter/Logout");
               par.Add("/UserCenter/EditPwd");
           }
           else//未登录
           {
               Template = FileOption.ReadFile("/Templates/LabelFormatTemplates/TopUserUnLogin.htm");
               int index = Template.LastIndexOf("{注释线-");
               if (index > 0)
                   Template = Template.Substring(0, index);
               //{0}--用户名文本框
               //{1}--密码输入框
               //{2}--验证码输入框
               //{3}--验证码图片
               //{4}--找回密码链接地址
               //{5}--注册链接地址
               //{6}--form提交时的处理页面url
               par.Add("<input type=\"text\" name=\"Login_User\" />");
               par.Add("<input type=\"password\" name=\"Login_Password\" />");
               par.Add("<input type=\"text\" name=\"Login_VCode\" id=\"Login_VCode\" />");
               par.Add("<img src=\"/ImageCode\" title=\"看不清？点击刷新\" alt=\"看不清？点击刷新\" style=\"cursor:pointer;\" onclick=\"this.src='/ImageCode?r='+new Date()\" id=\"ImageCode\" />");
               par.Add("/UserCenter/FindPwd");
               par.Add("/UserCenter/UserReg");
               par.Add("/UserCenter/Login?url="+System.Web.HttpContext.Current.Server.UrlEncode(System.Web.HttpContext.Current.Request.QueryString["url"]));
           }
           if (string.IsNullOrEmpty(Template))
               return "<div style=\"text-align:center; padding:10px; color:red\">用登录模板不存在或内容为空！</div>";
           else
           {
               return string.Format(Template,par.ToArray());
           }
       }
    }
}
