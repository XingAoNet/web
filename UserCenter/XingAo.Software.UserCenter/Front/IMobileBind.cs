using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XingAo.Software.UserCenter
{
    public interface IMobileBind : ITokenService
    {
        /// <summary>
        /// 发送当前用户手机短信
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result SendCurrentMobile(string token, string userId, Hashtable options);

        /// <summary>
        /// 验证当前用户手机短信
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="validateCode"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result ValidateCurrentMobile(string token, string userId, string validateCode, Hashtable options);

        /// <summary>
        /// 检查新手机号是否可用
        /// </summary>
        /// <param name="token"></param>
        /// <param name="mobile"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result CheckNewMobile(string token, string mobile, Hashtable options);

        /// <summary>
        /// 发送新手机短信
        /// </summary>
        /// <param name="token"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result SendNewMobile(string token, string userId, Hashtable options);

        /// <summary>
        /// 验证新手机短信
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="validateCode"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result ValidateNewMobile(string token, string userId, string validateCode, Hashtable options);
    }
}
