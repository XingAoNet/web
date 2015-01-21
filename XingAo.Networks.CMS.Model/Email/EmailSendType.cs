/******************************************************************
* Create By:陈成杰
* Create Time:2014-06-02 00:31:44
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model.Email
{
    /// <summary>
    /// 邮件发送类型
    /// </summary>
    public enum EmailSendType
    {
        /// <summary>
        /// 自动发送（系统发送）
        /// </summary>
        [Description("系统发送")]
        AutoType =0,
        /// <summary>
        /// 手动发送（人工发送）
        /// </summary>
        [Description("手动发送")]
        ManualType = 1
    }
}
