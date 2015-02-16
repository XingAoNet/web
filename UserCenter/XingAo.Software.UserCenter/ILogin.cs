using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using XingAo.Core;

namespace XingAo.Software.UserCenter
{
    public interface ILogin
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="identity">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="clientIP">ip</param>
        /// <returns>0表示登录成功</returns>
        Result Login(string identity, string password, string clientIP);
    }
}
