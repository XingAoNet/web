using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace XingAo.Networks.WeChat
{
    public class LoginInfo
    {
        /// <summary>
        /// 登录后得到的令牌
        /// </summary> 
        public  string Token { get; set; }
        /// <summary>
        /// 登录后得到的cookie
        /// </summary>
        public  CookieContainer LoginCookie { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public  DateTime CreateDate { get; set; }
    }
}
