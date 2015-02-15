using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Core;
using System.Collections;

namespace XingAo.Software.UserCenter
{
    public partial interface IPassword
    {
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
        Result ResetPasswordByAdmin(string userId, string password, string adminId, string adminName, string remark, Hashtable options);
    }
}
