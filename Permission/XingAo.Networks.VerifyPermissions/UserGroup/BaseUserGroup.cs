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
using System.ComponentModel;

namespace XingAo.NetWork.VerifyPermissions.UserGroup
{
    /// <summary>
    /// 用户组抽象类
    /// </summary>
    public abstract class BaseUserGroup
    {
        /// <summary>
        /// 用户组ID
        /// </summary>
        [Description("用户组ID")]
        public abstract int GroupID { get; set; }
        /// <summary>
        /// 用户组名称
        /// </summary>
        [Description("用户组名称")]
        public  string GroupName { get; set; }
        /// <summary>
        /// 所有权限
        /// </summary>
        [Description("所有权限")]
        public string Permissions { get; set; }
        /// <summary>
        /// 用户组编码
        /// </summary>
        [Description("用户组编码")]
        public int GroupCode { get; set; }

    }
}
