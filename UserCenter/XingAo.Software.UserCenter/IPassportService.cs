using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XingAo.Software.UserCenter
{
    /// <summary>
    /// 通行证服务，提供查询用户信息接口
    /// </summary>
    public interface IPassportService
    {
        /// <summary>
        /// 获取当前用户id
        /// </summary>
        /// <returns></returns>
        string GetCurrentUserId();

        /// <summary>
        /// 获取当前用户登录名
        /// </summary>
        /// <returns></returns>
        string GetCurrentUserIdentity();

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IUser GetUser(string userId);
    }
}
