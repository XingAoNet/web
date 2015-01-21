/*=================================
//  模块：XA_SMS_AutoSendMobs实体
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
    ///表名：短信定时发送子表  的实体
    /// </summary>	
    [Table("XA_SMS_AutoSendMobs")]
    public class SMS_AutoSendMobs
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
        /// XA_SMS_AutoSend   内的主键ID
        /// </summary>	
        [Column("AID")]
        [DisplayName("XA_SMS_AutoSend   内的主键ID")]
        public int AID
        {
            get;
            set;
        }


        /// <summary>
        /// 姓名
        /// </summary>	
        [Column("Name")]
        [DisplayName("姓名")]
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// 手机号
        /// </summary>	
        [Column("Mob")]
        [DisplayName("手机号")]
        public string Mob
        {
            get;
            set;
        }
        /// <summary>
        /// 此发送号码对应的定时发送任务明细
        /// </summary>        
        public virtual SMS_AutoSend AutoSend { get; set; }
    }
}














/*=================================
//  模块：XA_SMS_AutoSendMobs 映射表名
//  创建者：Lu
//  创建时间：2014-1-27
=================================*/
namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("SMS_AutoSendMobsMapping")]
    public class SMS_AutoSendMobsMapping : MappingBase<SMS_AutoSendMobs>
    {
        public SMS_AutoSendMobsMapping()
        {
            //映射表名
            this.ToTable("XA_SMS_AutoSendMobs");
            this.HasRequired(m => m.AutoSend).WithMany(m => m.AutoSendMobs).HasForeignKey(t => t.AID);

        }
    }
}