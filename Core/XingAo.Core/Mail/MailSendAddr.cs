
namespace XingAo.Core.Mail
{
    /// <summary>
    /// 邮件发送人地址信息
    /// </summary>
    public class MailSendAddr
    {
        /// <summary>
        /// 发件人名称(账号）
        /// </summary>
        public string SendName { get; set; }
        /// <summary>
        /// 发件人密码
        /// </summary>
        public string SendPwd { get; set; }
        /// <summary>
        /// 发送主机
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 是否SSL加密
        /// </summary>
        public bool EnableSsl { get; set; }
        /// <summary>
        /// 发件人描述信息（发件人昵称）
        /// </summary>
        public string DisplayName { get; set; }
    }
}
