/******************************************************************
* Create By:卢小阳
* Create Time:2013/4/21 22:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.NetWorks.VerifyPermissions.Enum
{
    /// <summary>
    /// 错误类型枚举
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// 参数错误
        /// </summary>
        ParamsErr=1000,
        /// <summary>
        /// 未设置用户权限错误（即未调用过UserPermission.SetUserOperating）
        /// </summary>
        NullMenuOperatingErr=3000
    }
}
