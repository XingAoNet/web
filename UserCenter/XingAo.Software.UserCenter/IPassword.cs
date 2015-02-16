using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using XingAo.Core;

namespace XingAo.Software.UserCenter
{
    public interface IPassword
    {
        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        /// <param name="userIdentity">用户名</param>
        /// <returns>0表示用户不存在</returns>
        Result CheckUserExist(string userIdentity);

        /// <summary>
        /// 发送找回密码短信
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="clientIP">客户端ip</param>
        /// <returns>0表示发送成功</returns>
        Result SendFindPwdMobile(string mobile, string clientIP);

        /// <summary>
        /// 验证找回密码短信
        /// </summary>
        /// <param name="validateCode">验证码</param>
        /// <returns>0表示验证成功</returns>
        Result ValidateFindPwdMobile(string validateCode);

        /// <summary>
        /// 重置登录密码
        /// </summary>
        /// <param name="newPassword"></param>
        /// <param name="clientIP"></param>
        /// <returns>0表示成功</returns>
        Result ResetPassword(string newPassword, string clientIP);

        /// <summary>
        /// 发送修改密码短信
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="clientIP">客户端ip</param>
        /// <returns>0表示成功</returns>
        Result SendModifyPwdMobile(string userId, string clientIP);

        /// <summary>
        /// 验证修改密码短信
        /// </summary>
        /// <param name="validateCode">验证码</param>
        /// <returns>0表示成功</returns>
        Result ValidateModifyPwdMobile(string validateCode);

        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="oldPwd">老密码</param>
        /// <param name="newPwd">新密码</param>
        /// <param name="clientIP">客户端ip</param>
        /// <returns>0表示成功</returns>
        Result ModifyPassword(string oldPwd, string newPwd, string clientIP);
    }
}
