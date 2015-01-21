using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model.SMSModel
{
    /// <summary>
    /// 定时发送主表数据实体类（不作数据增删改使用，只用于查询）
    /// </summary>
    public class SendListModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>	
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户ID
        /// </summary>	
        public int UID
        {
            get;
            set;
        }
        /// <summary>
        /// 第三方接入时，提交过来的发送者名称
        /// </summary>	
        public string SenderName
        {
            get;
            set;
        }
        /// <summary>
        /// 第三方接入时，发送者的ID
        /// </summary>	
        public int SenderID
        {
            get;
            set;
        }
        /// <summary>
        /// 定时发送时间 
        /// </summary>	
        public DateTime SendTime
        {
            get;
            set;
        }
        /// <summary>
        /// 要发送的短信完整内容(包括签名)
        /// </summary>	
        public string SendMsg
        {
            get;
            set;
        }
        /// <summary>	
        /// 要发送的短信内容签名
        /// </summary>	
        public string MsgSign
        {
            get;
            set;
        }
        /// <summary>
        /// 定时发送类型：0--一次性定时发送；1--每日定时发送;2--每周定时发送；3--每月定时发送
        /// </summary>	
        public int SendType
        {
            get;
            set;
        }
        /// <summary>
        /// 当SendType=2即每周发送时，设在周几来发送0为周日
        /// </summary>	
        public int DayOfWeek
        {
            get;
            set;
        }
        /// <summary>
        /// 当SendType=3即每月发送时，定义在每个月的第几天来执行
        /// </summary>
        public int MonthOfDay
        {
            get;
            set;
        }
        /// <summary>
        /// 最后一次发送时间(SendType=0时，发送后就删除此记录,其它类型的都只更新此字段)
        /// </summary>	
        public DateTime LastSendTime
        {
            get;
            set;
        }
    }
   
}
