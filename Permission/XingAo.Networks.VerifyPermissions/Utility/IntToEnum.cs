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

namespace XingAo.NetWorks.VerifyPermissions.Utility
{
    /// <summary>
    /// 整型转枚举
    /// </summary>
   public static class IntToEnum
    {
       /// <summary>
        /// 根据数字转成操作权限枚举
       /// </summary>
       /// <param name="number">值</param>
        /// <returns>操作权限枚举</returns>
       public static Operating GetOperatingEnumFromInt(int number)
       {
           return (Operating)Operating.ToObject(typeof(Operating), number);
       }
    }
}
