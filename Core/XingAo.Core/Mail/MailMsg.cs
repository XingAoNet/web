using System.Text;
using System.Net.Mail;

namespace XingAo.Core.Mail
{
    /// <summary>
    /// 邮件发送信息
    /// </summary>
    public class MailMsg
    {
        public MailMsg() { }

        public MailMsg(
            string subject, string body, MailPriority priority,
            Encoding encoding, bool isBodyHtml)
        {
            this.Subject = subject;
            this.Body = body;
            this.Priority = priority;
            this.Encoding = encoding;
            this.IsBodyHtml = isBodyHtml;
        }
        
        /// <summary>
        /// 编码方式
        /// </summary>
        private Encoding _encoding = Encoding.UTF8;
        public Encoding Encoding { get { return _encoding; } set { _encoding = value; } }
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 邮件等级
        /// </summary>
        private MailPriority _priority = MailPriority.Normal;
        public MailPriority Priority { get { return _priority; } set { _priority = value; } }
        /// <summary>
        /// 邮件内容是否允许HTML
        /// </summary>
        public bool IsBodyHtml { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 邮件超时时间
        /// </summary>
        private int _timeOut = 1000;
        public int TimeOut { get { return _timeOut; } set { _timeOut = value; } }
    }
}
