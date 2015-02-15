using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Software.UserCenter
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class OperationLog
    {
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationDate { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string UserIdentity { get; set; }
        /// <summary>
        /// 管理员id
        /// </summary>
        public string AdminId { get; set; }
        /// <summary>
        /// 管理员名
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public int OperationType { get; set; }
        /// <summary>
        /// 操作名
        /// </summary>
        public string OperationName { get; set; }
        /// <summary>
        /// 操作ip
        /// </summary>
        public string OperationIP { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }

    /// <summary>
    /// 操作日志分页查询对象
    /// </summary>
    public class PagedOperationLog
    {
        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public OperationLog[] Logs { get; set; }
    }    
}
