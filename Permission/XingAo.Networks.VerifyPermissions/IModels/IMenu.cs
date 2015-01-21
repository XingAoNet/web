using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.NetWorks.VerifyPermissions.IModels
{
   /// <summary>
   ///  权限菜单接口
   /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 菜单ID（与Code至少要有一个是唯一）
        /// </summary>
        int ID { get; set; }
        /// <summary>
        /// 菜单编号（与ID至少要有一个是唯一）
        /// </summary>
        string Code { get; set; }
        /// <summary>
        /// 权限信息
        /// </summary>
       IList<IOperatingInfo> OperatingInfo { get; set; }

    }
}
