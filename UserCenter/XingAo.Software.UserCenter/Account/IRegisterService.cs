using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Software.UserCenter.Model;

namespace XingAo.Software.UserCenter.Account
{
    /// <summary>
    /// 用户注册服务
    /// </summary>
    public interface IRegisterService
    {
        /// <summary>
        /// 通过用户名注册用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>返回是否注册成功，true成功，false失败</returns>
        UserModel RegisterByUserName(string userName, string password);
        /// <summary>
        /// 通过手机号码注册用户
        /// </summary>
        /// <param name="mobile">手机号码</param>
        /// <param name="verifyCode">验证码</param>
        /// <returns></returns>
        UserModel RegisterByMobile(string mobile, string verifyCode);
        /// <summary>
        /// 通过邮箱注册用户
        /// </summary>
        /// <param name="email">邮箱地址</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        UserModel RegisterByEmail(string email, string password);
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="identity">用户名</param>
        /// <returns>0表示不存在</returns>
        bool IsUserExist(string identity);
        /// <summary>
        /// 发送注册短信
        /// </summary>
        /// <param name="mobile">手机号码，发送验证码类见：<see cref="XingAo.Core.VerifyCode.cs"/></param>
        /// <returns>返回发送结果，true发送成功，false发送失败</returns>
        bool SendRegisterMobile(string mobile);
        /// <summary>
        /// 验证注册短信
        /// </summary>
        /// <param name="validateCode">验证码</param>
        /// <returns>返回验证结果，true验证成功，false验证失败</returns>
        bool ValidateRegisterMobile(string validateCode);
    }
}
