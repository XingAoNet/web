using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using XingAo.Core;
using XingAo.Software.UserCenter.Model;

namespace XingAo.Software.UserCenter
{
    public interface IUserAdmin
    {
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userIdentity">用户编号</param>
        /// <returns>返回用户信息</returns>
        UserModel GetUser(string userIdentity);
        /// <summary>
        /// 锁定用户
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>true成功，false失败</returns>
        bool LockUser(string userId);
        /// <summary>
        /// 解锁用户
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>true成功，false失败</returns>
        bool UnLockUser(string userId);
        /// <summary>
        /// 修改用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        UserModel ChangeUserType(string userId, int userRole);
        /// <summary>
        /// 重置用户登录密码
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="password">用户密码</param>
        /// <returns></returns>
        UserModel ResetUserPassword(string userId, string password);
    }
}
