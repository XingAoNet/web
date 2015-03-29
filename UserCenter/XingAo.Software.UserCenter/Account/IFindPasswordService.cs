using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Software.UserCenter.Account
{
    /// <summary>
    /// 找回密码服务
    /// </summary>
    public interface IFindPasswordService
    {
        /// <summary>
        /// 发送找回密码短信
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="clientIP">客户端ip</param>
        /// <returns>ture表示发送成功</returns>
        bool SendFindPwdByMobile(string mobile, string clientIP);
        /// <summary>
        /// 验证找回密码短信
        /// </summary>
        /// <param name="validateCode">验证码</param>
        /// <returns>ture表示验证成功</returns>
        bool ValidateFindPwdByMobile(string validateCode);
        /// <summary>
        /// 重置登录密码
        /// </summary>
        /// <param name="newPassword"></param>
        /// <param name="clientIP"></param>
        /// <returns>ture表示成功</returns>
        bool ResetPassword(string newPassword, string clientIP);
        /// <summary>
        /// 发送修改密码短信
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="clientIP">客户端ip</param>
        /// <returns>ture表示成功</returns>
        bool SendModifyPwdByMobile(string userId, string clientIP);
        /// <summary>
        /// 验证修改密码短信
        /// </summary>
        /// <param name="validateCode">验证码</param>
        /// <returns>ture表示成功</returns>
        bool ValidateModifyPwdByMobile(string validateCode);
        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="oldPwd">老密码</param>
        /// <param name="newPwd">新密码</param>
        /// <param name="clientIP">客户端ip</param>
        /// <returns>ture表示成功</returns>
        bool ModifyPassword(string oldPwd, string newPwd, string clientIP);
    }
}
