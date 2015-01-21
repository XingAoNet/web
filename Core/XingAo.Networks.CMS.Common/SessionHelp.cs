using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace XingAo.Networks.CMS.Common
{
    public class SessionHelp
    {
        public static string SessionName = "WeGuid";

        ///// <summary>
        ///// 登陆用户信息
        ///// </summary>
        //public static string UserInfo
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[SessionName] == null)
        //            return null;
        //        else
        //            return HttpContext.Current.Session[SessionName].ToString();
        //    }
        //}
        ///// <summary>
        ///// 验证当前用户是否登录
        ///// </summary>
        ///// <returns></returns>
        //public static bool IsLogin()
        //{
        //    return !(HttpContext.Current.Session[SessionName] == null);
        //}

        public static void SaveSessionUser(string user)
        {
            HttpContext.Current.Session[SessionName] = user;
        }

        ///// <summary>
        ///// 登录状态的用户name
        ///// </summary>
        //public static string UserName
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[SessionName] == null)
        //            return string.Empty;
        //        else
        //            return HttpContext.Current.Session[SessionName].ToString();
        //    }
        //}
    }
}
