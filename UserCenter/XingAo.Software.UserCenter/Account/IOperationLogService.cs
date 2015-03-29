using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Software.UserCenter.Model;

namespace XingAo.Software.UserCenter.Account
{
    /// <summary>
    /// 操作日志服务
    /// </summary>
    interface IOperationLogService
    {
        /// <summary>
        /// 查询所有操作日志
        /// </summary>
        /// <returns></returns>
        ICollection<OperationLog> GetOperationLog();
        /// <summary>
        /// 根据用户编号查询操作日志
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ICollection<OperationLog> GetOperationLogByUserId(int userId);
        /// <summary>
        /// 根据最新的个数查询操作日志
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="topN"></param>
        /// <returns></returns>
        ICollection<OperationLog> GEtOperationLogByTop(int userId, int topN);
    }
}
