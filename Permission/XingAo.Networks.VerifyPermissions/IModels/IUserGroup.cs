using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using XingAo.NetWorks.VerifyPermissions.Models;

namespace XingAo.NetWorks.VerifyPermissions.IModels
{
    /// <summary>
    /// 用户组实体类接口
    /// </summary>
    public interface IUserGroup
    {
        /// <summary>
        /// 用户组ID
        /// </summary>
        [Description("用户组ID")]
         int GroupID { get; set; }
        /// <summary>
        /// 用户组名称
        /// </summary>
        [Description("用户组名称")]
         string GroupName { get; set; }
        ///// <summary>
        ///// 菜单权限
        ///// </summary>
        //[Description("菜单权限")]
        //IMenu MenuPermissions { get; set; }
        ///// <summary>
        ///// 操作权限
        ///// </summary>
        //[Description("操作权限")]
        //IOperatingInfo OperatingPermissions { get; set; }


        ///// <summary>
        ///// 菜单与操作  权限集合
        ///// </summary>
        //List<MenuOperating> MenuOperation { get; set; }
        /// <summary>
        /// 用户组编码
        /// </summary>
        [Description("用户组编码")]
         string GroupCode { get; set; }
        
    }
}
