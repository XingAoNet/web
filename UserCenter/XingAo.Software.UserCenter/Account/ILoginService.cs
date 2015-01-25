/******************************************************************
 * 文件名 : ILogin.cs
 * 数据表 : no
 * 创建者 : 陈成杰
 * 发布日期 : 2015/1/24 22:43:50
 * 文件描述 : 用户登录登出服务
 * 
 * 修改记录
 * R1:
 *  修改作者 ： 
 *  修改日期 ：
 *  修改内容 ：
 *      
 * R2:
 *  修改作者 ：
 *  修改日期 ：
 *  修改内容 ：
 *  
 ******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Software.UserCenter.Account
{
    /// <summary>
    /// 用户登录登出服务
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>是否登录成功，true成功，false失败</returns>
        public bool Login(IUser user);
        /// <summary>
        /// 用户登出
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>是否登出成功，true成功，false失败</returns>
        public bool Logout(IUser user);
        /// <summary>
        /// 判断用户是否已经登录
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>是否已经登录，true已登录，false未登录</returns>
        public bool IsLogin(IUser user);
    }
}
