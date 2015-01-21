/******************************************************************
* Create By:卢小阳
* Create Time:2013/4/21 22:18:57
* Update By:
 * ccj:去掉还款、冲单、冲帐、回瓶数
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using XingAo.NetWorks.VerifyPermissions.IModels;

namespace XingAo.NetWorks.VerifyPermissions.Enum
{
    /// <summary>
    /// 操作权限枚举
    /// </summary>
    public enum Operating
    {
        /// <summary>
        /// 添加
        /// </summary>
        [Description("添加")]
        Add = 0,
        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Edit = 1,
        /// <summary>
        /// 列表
        /// </summary>
        [Description("列表")]
        List = 2,
        /// <summary>
        /// 批量移动
        /// </summary>
        [Description("批量移动")]
        Move = 3,
        /// <summary>
        /// 删除（单个或多个）
        /// </summary>
        [Description("删除（单个或多个）")]
        Del = 4,
        /// <summary>
        /// 全部删除
        /// </summary>
        [Description("全部删除")]
        DelAll = 5,
        /// <summary>
        /// 已审核
        /// </summary>
        [Description("审核")]
        Audit = 6,
        /// <summary>
        /// 未审核
        /// </summary>
        [Description("取消审核")]
        UnAudit = 7,
        /// <summary>
        /// 可用
        /// </summary>
        [Description("置为可用")]
        Enable = 8,
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("置为禁用")]
        Disenable = 9,
        /// <summary>
        /// 导入
        /// </summary>
        [Description("导入")]
        Import = 10,
        /// <summary>
        /// 导出
        /// </summary>
        [Description("导出")]
        Export = 11,
        /// <summary>
        /// 查看详细
        /// </summary>
        [Description("查看详细")]
        ShowInfo = 12,
        /// <summary>
        /// 备份
        /// </summary>
        [Description("备份")]
        BackUp = 13,
        /// <summary>
        /// 还原
        /// </summary>
        [Description("还原")]
        Reduction = 14,
        /// <summary>
        /// 打印
        /// </summary>
        [Description("打印")]
        Print = 15,
        ///// <summary>
        ///// 还款
        ///// </summary>
        //[Description("还款")]
        //Repayment = 16,
        ///// <summary>
        ///// 冲单、冲帐
        ///// </summary>
        //[Description("冲单、冲帐")]
        //StrikeBalance = 17,
        ///// <summary>
        ///// 回瓶数
        ///// </summary>
        //[Description("回瓶数")]
        //BackBottle = 18,

        /// <summary>
        /// 特殊操作
        /// </summary>
        [Description("特殊操作")]
        OnlyLogin = 999
    }
}
