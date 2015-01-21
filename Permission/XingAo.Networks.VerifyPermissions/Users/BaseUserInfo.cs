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

namespace XingAo.NetWork.VerifyPermissions.Users
{
    /// <summary>
    /// 用户信息抽象类
    /// </summary>
    public abstract class BaseUserInfo 
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Description("用户ID")]
        public int UserID { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        [Description("用户编码")]
        public string UserCode { get; set; }        
        /// <summary>
        /// 用户组ID
        /// </summary>
        [Description("用户组ID")]
        public int GroupID { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [Description("用户真实姓名")]
        public string RealName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [Description("用户密码")]
        public string Password { get; set; }
        /// <summary>
        /// 帐号是否可用（true可以，false 禁用）
        /// </summary>
        [Description("帐号是否可用")]
        public bool Enable { get; set; }
        /// <summary>
        /// 帐号是否被删除
        /// </summary>
        [Description("帐号是否被删除")]
        public bool IsDel { get; set; }
    }
}
