using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XingAo.Software.UserCenter
{
    public interface IPassword : ITokenService
    {
        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userIdentity"></param>
        /// <returns></returns>
        Result CheckUserExist(string token, string userIdentity);

        /// <summary>
        /// 发送找回密码短信
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="clientIP"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result SendFindPwdMobile(string token, string mobile, string clientIP, Hashtable options);

        /// <summary>
        /// 验证找回密码短信
        /// </summary>
        /// <param name="token"></param>
        /// <param name="mobile"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result ValidateFindPwdMobile(string token, string mobile, Hashtable options);

        /// <summary>
        /// 重置登陆密码
        /// </summary>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result ResetPassword(string token, string newPassword, Hashtable options);

        /// <summary>
        /// 发送修改密码短信
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result SendModifyPwdMobile(string token, string userId, Hashtable options);

        /// <summary>
        /// 验证修改密码短信
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="validateCode"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result ValidateModifyPwdMobile(string token, string userId, string validateCode, Hashtable options);

        /// <summary>
        /// 修改登陆密码
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result ModifyPassword(string token, string userId, string oldPwd, string newPwd, Hashtable options);
    }
}
