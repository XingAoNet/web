using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.NetWorks.VerifyPermissions.Enum;

namespace XingAo.NetWorks.VerifyPermissions.Models
{
    /// <summary>
    /// 错误实体类
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
        /// <summary>
        /// 错误类型
        /// </summary>
        public ErrorType ErrType { get; set; }
        /// <summary>
        /// 返回ErrorInfo中字段信息（包括：错误信息+错误号+错误类型）
        /// </summary>
        public override string ToString()
        {
            return ErrMsg + " 错误号：" + ((int)ErrType).ToString() + " 错误类型：" + ErrType.ToString();
        }
    }
}
