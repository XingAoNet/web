using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model.Enums
{
    /// <summary>
    /// 广告显示方式，0--普通 1-固定浮动式 2-全屏飘浮式
    /// </summary>
    public enum AdShowTypeEnum
    {
        [Description("普通")]
        Numaral = 0,
        [Description("固定浮动式")]
        guding = 1,
        [Description("全屏飘浮式")]
        quanping = 2
    }
}
