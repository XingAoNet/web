using System.Collections.Generic;
using System.Linq;

namespace XingAo.Core.Mail
{
    /// <summary>
    /// 收件人信息
    /// </summary>
    public class MailReceiveAddr
    {
        /// <summary>
        /// 单个收件人地址
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// 多个收件人地址,当该值为空时，取To的值
        /// </summary>
        private string[] tos;
        public string[] Tos
        {
            get
            {
                if (tos == null || tos.Count() == 0)
                {
                    List<string> tmp = new List<string>();
                    tmp.Add(To);
                    tos = tmp.ToArray();
                }
                return tos;

            }
            set
            {
                if(value.Count()>0)
                    tos = value;
            }
        }
        /// <summary>
        /// 抄送人地址
        /// </summary>
        public string[] CC { get; set; }
        /// <summary>
        /// 密送人地址
        /// </summary>
        public string[] Bcc { get; set; }
    }
}
