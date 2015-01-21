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
using XingAo.NetWorks.VerifyPermissions.IModels;

namespace XingAo.NetWorks.VerifyPermissions.Models
{
    /// <summary>
    /// 菜单-权限实体类
    /// </summary>
    public class MenuOperating
    {
        /// <summary>
        /// 菜单-权限实体类 构造
        /// </summary>
        /// <param name="menu">菜单</param>
        public MenuOperating(IMenu menu)
        {
            Menu = menu;
        }
        /// <summary>
        /// 菜单信息
        /// </summary>
        public IMenu Menu { get; set; }
        
    }
}
