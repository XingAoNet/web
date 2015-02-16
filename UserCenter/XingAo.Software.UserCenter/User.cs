using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Software.UserCenter
{
    /// <summary>
    /// 客户端用户对象
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 用户id
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// 用户状态
        /// 0表示正常
        /// -10表示挂起
        /// -100表示已删除
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        int UserType { get; set; }
        
        /// <summary>
        /// 密码，md5密文
        /// </summary>
        //public string Password { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        DateTime RegDate { get; set; }

        /// <summary>
        /// 注册ip
        /// </summary>
        string RegIP { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        DateTime LastLoginDate { get; set; }

        /// <summary>
        /// 最后登录ip
        /// </summary>
        string LastLoginIP { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// 可用积分
        /// </summary>
        int AvailableScore { get; set; }

        /// <summary>
        /// 用户等级
        /// </summary>
        int Level { get; set; }

        /// <summary>
        /// 是否已认证
        /// </summary>
        bool IsAuthenticated { get; set; }
    }
}
