using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model.SMSModel
{
    /// <summary>
    /// 短信发送记录返回值实体
    /// </summary>
    public class LogModel
    {
        /// <summary>
        /// 日志列表
        /// </summary>
        public IEnumerable<Model.SMSModel.SendLog> DataList { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; set; }
    }
}
