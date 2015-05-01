/******************************************************************
 * 文件名 : ILoginService.cs
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
using XingAo.Software.UserCenter.Model;

namespace XingAo.Software.UserCenter.Account
{
    /// <summary>
    /// 用户登录登出服务
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// 通过账号密码登录
        /// </summary>
        /// <param name="userName">用户信息（用户名、手机号码、邮箱地址）</param>
        /// <param name="password">用户密码</param>
        /// <returns>返回用户注册后的信息，为空则登录失败</returns>
        UserModel LoginByUserName(string userInfo,string password);
        /// <summary>
        /// 通过手机号码登录
        /// </summary>
        /// <param name="Mobile">手机号码</param>
        /// <param name="validateCode">手机验证码</param>
        /// <returns>返回用户注册后的信息，为空则登录失败</returns>
        UserModel LoginByMobile(string Mobile, string validateCode);
        /// <summary>
        /// 用户登出
        /// </summary>
        /// <param name="user">编号</param>
        /// <returns>是否登出成功，true成功，false失败</returns>
        bool Logout(string identity);
        /// <summary>
        /// 判断用户是否已经登录
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>是否已经登录，true已登录，false未登录</returns>
        bool IsLogin(string identity);
    }
}
