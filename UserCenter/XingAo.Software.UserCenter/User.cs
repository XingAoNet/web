using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Software.UserCenter
{
    /// <summary>
    /// 客户端用户对象
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }
        
        /// <summary>
        /// 密码，md5密文
        /// </summary>
        //public string Password { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegDate { get; set; }

        /// <summary>
        /// 注册ip
        /// </summary>
        public string RegIP { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginDate { get; set; }
        /// <summary>
        /// 最后登录ip
        /// </summary>
        public string LastLoginIP { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 是否已认证
        /// </summary>
        public bool Authenticated { get; set; }
    }
}
