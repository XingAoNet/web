using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model
{
    public enum OrderStateEnum
    {
        /// <summary>
        /// 未付款=0
        /// </summary>
        [Description("未付款")]
        UnPay = 0,
        /// <summary>
        /// 已付款=1
        /// </summary>
        [Description("已付款")]
        Pay = 1,
        /// <summary>
        /// 已发货=2
        /// </summary>
        [Description("已发货")]
        Send = 2,
        /// <summary>
        /// 已收货=3
        /// </summary>
        [Description("已收货")]
        Received = 3,
        /// <summary>
        /// 已评价=4
        /// </summary>
        [Description("已评价")]
        Evaluate = 4,

        /// <summary>
        /// 申请取消订单=10
        /// </summary>
        [Description("申请取消订单")]
        ApplyCancelOrder = 10,
        /// <summary>
        /// 已取消订单=11
        /// </summary>
        [Description("已取消订单")]
        CancelOrder = 11,
        /// <summary>
        /// 申请退货=12
        /// </summary>
        [Description("申请退货")]
        ApplayBack = 12,
        /// <summary>
        /// 管理员同意退货=13
        /// </summary>
        [Description("已同意退货")]
        ApplayBackPass = 13
    }
}
