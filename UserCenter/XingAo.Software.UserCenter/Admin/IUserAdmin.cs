using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XingAo.Software.UserCenter
{
    public interface IUserAdmin
    {
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userIdentity"></param>
        /// <returns></returns>
        User GetUser(string userIdentity);

        /// <summary>
        /// 锁定、解锁用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="adminId"></param>
        /// <param name="adminName"></param>
        /// <param name="remark"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result LockUser(bool islock, string userId, string adminId, string adminName, string remark, Hashtable options);

        /// <summary>
        /// 修改用户类型
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <param name="adminId"></param>
        /// <param name="adminName"></param>
        /// <param name="remark"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result ChangeUserType(string userId, int userType, string adminId, string adminName, string remark, Hashtable options);


        /// <summary>
        /// 重置用户登陆密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <param name="adminId"></param>
        /// <param name="adminName"></param>
        /// <param name="remark"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result ResetUserPassword(string userId, string password, string adminId, string adminName, string remark, Hashtable options);
    }
}
