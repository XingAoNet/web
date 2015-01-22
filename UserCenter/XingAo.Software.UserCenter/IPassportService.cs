using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XingAo.Software.UserCenter
{
    public interface IPassportService
    {
        /// <summary>
        /// 登陆get请求
        /// </summary>
        /// <param name="clientIP"></param>
        /// <returns></returns>
        Result ValidateRequest(string clientIP, Hashtable options);

        /// <summary>
        /// 登陆post请求
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="password"></param>
        /// <param name="token"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result Login(string identity, string password, string token, Hashtable options);

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
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Result Register(User user, string clientIP, string validateCode, Hashtable options);

        /// <summary>
        /// 发送找回密码短信
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="clientIP"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result SendFindPwdMobile(string mobile, string clientIP, Hashtable options);
    }
}
