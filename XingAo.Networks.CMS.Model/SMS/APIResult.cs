using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model.SMSModel
{
    /// <summary>
    /// API调用结果实体类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class APIResult<T>
    {
        /// <summary>
        /// 是否调用错误
        /// </summary>
        public bool IsErr { get; set; }
        /// <summary>
        /// 服务器返回信息，包括正确与错误的信息
        /// </summary>
        public string ServerMsg { get; set; }
        /// <summary>
        /// 服务器返回的数据
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}
