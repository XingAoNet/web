using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Software.UserCenter.Model;

namespace XingAo.Software.UserCenter.Account
{
    /// <summary>
    /// 积分服务
    /// </summary>
    public interface IPointService
    {
        /// <summary>
        /// 添加积分
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>返回添加后的积分值</returns>
        int AddPoint(User user);
        /// <summary>
        /// 减少积分
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>返回减少后的积分值</returns>
        int ReducePoint(User user);
    }
}
