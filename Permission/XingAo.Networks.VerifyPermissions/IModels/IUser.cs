using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XingAo.NetWorks.VerifyPermissions.IModels
{
    /// <summary>
    /// 用户实体类接口
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名")]
         string UserName { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Description("用户ID")]
         int UserID { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        [Description("用户编码")]
         string UserCode { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [Description("用户密码")]
         string Password { get; set; }
        /// <summary>
        /// 帐号是否可用（true可以，false 禁用）
        /// </summary>
        [Description("帐号是否可用")]
         bool Enable { get; set; }
        /// <summary>
        /// 帐号是否被删除
        /// </summary>
        [Description("帐号是否被删除")]
         bool IsDel { get; set; }
        /// <summary>
        /// 当前用户下所拥有的权限菜单
        /// </summary>
        IList<IMenu> MenuList{get;set;}
    }
}
