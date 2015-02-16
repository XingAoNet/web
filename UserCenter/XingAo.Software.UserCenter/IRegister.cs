using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using XingAo.Core;

namespace XingAo.Software.UserCenter
{
    public interface IRegister
    {
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="identity">用户名</param>
        /// <returns>0表示不存在</returns>
        Result IsUserExist(string identity);

        /// <summary>
        /// 发送注册短信
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="clientIP">客户端ip</param>
        /// <returns>0表示成功</returns>
        Result SendRegisterMobile(string mobile, string clientIP);

        /// <summary>
        /// 验证注册短信
        /// </summary>
        /// <param name="validateCode">验证码</param>
        /// <returns>0表示成功</returns>
        Result ValidateRegisterMobile(string validateCode);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="userType">用户类型</param>
        /// <param name="password">密码</param>
        /// <param name="clientIP">客户端ip</param>
        /// <returns>0表示成功</returns>
        Result Register(int userType, string password, string clientIP);
    }
}
