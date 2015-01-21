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
using XingAo.NetWorks.VerifyPermissions.Enum;

namespace XingAo.NetWorks.VerifyPermissions.IModels
{
    /// <summary>
    /// 操作权限实体接口
    /// </summary>
    public interface IOperatingInfo
    {
        /// <summary>
        /// 具体操作
        /// </summary>
        Operating OperatingEnum { get; set; }
        /// <summary>
        /// 允许取多少毫秒内的数据（扩展属性）
        /// </summary>
        long AllowGetDataMilliseconds { get; set; }
    }
}
