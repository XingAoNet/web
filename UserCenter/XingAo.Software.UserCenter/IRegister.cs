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
        /// <param name="identity"></param>
        /// <returns></returns>
        Result IsUserExist(string identity);

        /// <summary>
        /// 发送注册短信
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="clientIP"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result SendRegisterMobile(string mobile, string clientIP, Hashtable options);

        /// <summary>
        /// 验证注册短信
        /// </summary>
        /// <param name="token"></param>
        /// <param name="validateCode"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result ValidateRegisterMobile(string validateCode, Hashtable options);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Result Register(int registerType, string identity, string password, string clientIP, Hashtable options);
    }
}
