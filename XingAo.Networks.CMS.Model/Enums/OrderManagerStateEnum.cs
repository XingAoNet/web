using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 订单中的 管理员状态
    /// </summary>
    public enum OrderManagerStateEnum
    {
        /// <summary>
        /// 未设置=0
        /// </summary>
        [Description("未设置")]
        UnSet=0,
        /// <summary>
        /// 管理员置为无效订单=1
        /// </summary>
        [Description("管理员置为无效订单")]
        UnEnable = 1,
        /// <summary>
        /// 管理员置为订单操作中=2
        /// </summary>
        [Description("管理员置为订单操作中")]
        Doing = 2,
        /// <summary>
        /// 管理员置为已完成订单=3
        /// </summary>
        [Description("管理员置为已完成订单")]
        Finshed = 3
    }
}
