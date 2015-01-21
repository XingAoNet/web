using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model.SMSModel
{
    public class SendLog
    {
        /// <summary>
        /// 主键Id
        /// </summary>	
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// API帐户ID
        /// </summary>	
        public int UID
        {
            get;
            set;
        }
        /// <summary>
        /// 发送短信消息
        /// </summary>	
        public string MsgInfo
        {
            get;
            set;
        }
        /// <summary>
        /// 接受者姓名
        /// </summary>	
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// 接受者手机号码
        /// </summary>	
        public string Mobiles
        {
            get;
            set;
        }
        /// <summary>
        /// 发送时间
        /// </summary>	
        public DateTime SendDateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 发送后返回结果
        /// </summary>	
        public string SendResultMsg
        {
            get;
            set;
        }
        /// <summary>
        /// 第三方接入时，请求过来的发送者名称
        /// </summary>	
        public string SendName
        {
            get;
            set;
        }
        /// <summary>
        /// 第三方接入时，请求过来的发送者ID
        /// </summary>	
        public int SendID
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime CreateDateTime
        {
            get;
            set;
        }
    }
}
