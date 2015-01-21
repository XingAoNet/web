using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 数据库字段类型枚举
    /// </summary>
    public enum FieldTypeEnum
    {
        /// <summary>
        /// 整数
        /// </summary>
        [Description("整数")]
        Int,
        /// <summary>
        /// 最大4000的字符
        /// </summary>
        [Description("最大4000的字符")]
        nvarchar,
        /// <summary>
        /// 时间
        /// </summary>
        [Description("时间")]
        smalldatetime,
        /// <summary>
        /// 大整数
        /// </summary>
        [Description("大整数")]
        bigint,
        /// <summary>
        /// 浮点数
        /// </summary>
        [Description("浮点数")]
        Float,
        /// <summary>
        /// 金钱
        /// </summary>
        [Description("金钱")]
        money,
        /// <summary>
        /// 最大8000字符
        /// </summary>
        [Description("最大8000字符")]
        varchar,
        /// <summary>
        /// 超大字符
        /// </summary>
        [Description("超大字符")]
        ntext
    }
}
