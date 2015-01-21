/*=================================
//  模块：XA_SMS_AutoSend实体
//  创建者：Lu
//  创建时间：2014-1-27
=================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：短信定时发送主表  的实体
    /// </summary>	
    [Table("XA_SMS_AutoSend")]
    public class SMS_AutoSend
    {
        /// <summary>
        /// 内部自增标识ID
        /// </summary>	
        [Key, Column("ID", Order = 1)]
        [DisplayName("编号")]
        public int ID
        {


            get;
            set;
        }


        /// <summary>
        /// 会员id
        /// </summary>	
        [Column("MembersID")]
        [DisplayName("会员id")]
        public int MembersID
        {
            get;
            set;
        }

/// <summary>
        /// 发送人名称
        /// </summary>	
        [Column("SendUserName")]
        [DisplayName("发送人名称")]
        public string SendUserName
        {
            get;
            set;
        }
        /// <summary>
        /// 定时发送时间 ,当SendType为循环发送类型时，此字段值在每次发送之后将会更新成下个周期要发送的时间 
        /// </summary>	
        [Column("SendTime")]
        [DisplayName("定时发送时间 ,当SendType为循环发送类型时，此字段值在每次发送之后将会更新成下个周期要发送的时间  ")]
        public DateTime SendTime
        {
            get;
            set;
        }


        /// <summary>
        /// 要发送的短信完整内容(包括签名)
        /// </summary>	
        [Column("SendMsg")]
        [DisplayName("要发送的短信完整内容(包括签名)")]
        public string SendMsg
        {
            get;
            set;
        }
        /// <summary>
        /// 当SendType=2即每周发送时，设在周几来发送0为周日
        /// </summary>	
        [Column("DayOfWeek")]
        [DisplayName("当SendType=2即每周发送时，设在周几来发送0为周日")]
        public int DayOfWeek
        {
            get;
            set;
        }
        /// <summary>
        /// 当SendType=3即每月发送时，定义在每个月的第几天来执行
        /// </summary>	
        [Column("MonthOfDay")]
        [DisplayName("当SendType=3即每月发送时，定义在每个月的第几天来执行")]
        public int MonthOfDay
        {
            get;
            set;
        } 
        /// <summary>
        /// 定时发送类型：0--一次性定时发送；1--每日定时发送;2--每周定时发送；3--每月定时发送
        /// </summary>	
        [Column("SendType")]
        [DisplayName("定时发送类型：0--一次性定时发送；1--每日定时发送;2--每周定时发送；3--每月定时发送")]
        public int SendType
        {
            get;
            set;
        }
        /// <summary>
        /// 最后一次发送时间(SendType=0时，发送后就删除此记录,其它类型的都只更新此字段)
        /// </summary>	
        [Column("LastSendTime")]
        [DisplayName("最后一次发送时间(SendType=0时，发送后就删除此记录,其它类型的都只更新此字段)")]
        public DateTime LastSendTime
        {
            get;
            set;
        }        
        /// <summary>
        /// 此定时发送任务下要发送的手机号码及姓名列表（此字段为多表关联用，单表操作时忽视此字段）
        /// </summary>        
        public virtual ICollection<SMS_AutoSendMobs> AutoSendMobs { get; set; }
    }
}














/*=================================
//  模块：XA_SMS_AutoSend 映射表名
//  创建者：Lu
//  创建时间：2014-1-27
=================================*/
namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("SMS_AutoSendMapping")]
    public class SMS_AutoSendMapping : MappingBase<SMS_AutoSend>
    {
        public SMS_AutoSendMapping()
        {
            //映射表名
            this.ToTable("XA_SMS_AutoSend");

        }
    }
}