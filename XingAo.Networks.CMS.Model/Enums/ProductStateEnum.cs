using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model.Enums
{
    /// <summary>
    /// 商品状态
    /// </summary>
    public enum ProductStateEnum
    {
        /// <summary>
        /// 未上架
        /// </summary>
        [Description("未上架")]
        UnPutaway = 0,
        /// <summary>
        /// 上架出售中
        /// </summary>
        [Description("上架出售中")]
        Putaway = 1,
        /// <summary>
        /// 库存不足而强制下架
        /// </summary>
        [Description("库存不足而强制下架")]
        SoldOut =2
    }
}
