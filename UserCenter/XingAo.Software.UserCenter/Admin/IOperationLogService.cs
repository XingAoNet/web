using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XingAo.Software.UserCenter
{
    public interface IOperationLogService
    {
        /// <summary>
        /// 分页查询操作日志
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        PagedOperationLog GetOperationLog(int pageSize, int pageIndex, Hashtable options);
    }
}
