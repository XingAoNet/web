using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XingAo.Core
{
    /// <summary>
    /// 接口返回对象
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 结果代码，约定返回0表示成功
        /// </summary>
        public int ResultNo { get; set; }
        /// <summary>
        /// 结果描述
        /// </summary>
        public string ResultDescription { get; set; }
        /// <summary>
        /// 结果其他数据
        /// </summary>
        public Hashtable ResultData { get; set; }
    }
}
