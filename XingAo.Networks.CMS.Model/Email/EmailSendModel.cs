/*=================================
//  模块：XA_Email_Send实体
//  创建者：Lu
//  创建时间：2014-06-01
//  描述：：XA_Email_Send
//  生成模板来源：Networks.CMS.Model_V1.3.cmt
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
    ///表名：XA_Email_Send的实体
    /// </summary>	
    [Table("XA_Email_Send")]//数据库真实表名
    public partial class EmailSendModel
    {
        /// <summary>
        /// 邮件发送记录
        /// </summary>	
        [Column("Id")] //数据库真实字段名
        [DisplayName("邮件发送记录")]
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 发送标题
        /// </summary>	
        [Column("SendTitle")] //数据库真实字段名
        [DisplayName("发送标题")]
        public string SendTitle
        {
            get;
            set;
        }
        /// <summary>
        /// 发送内容
        /// </summary>	
        [Column("SendContent")] //数据库真实字段名
        [DisplayName("发送内容")]
        public string SendContent
        {
            get;
            set;
        }
        /// <summary>
        /// 发送时间
        /// </summary>	
        [Column("SendTime")] //数据库真实字段名
        [DisplayName("发送时间")]
        public DateTime SendTime
        {
            get;
            set;
        }
        /// <summary>
        /// 发送类型（系统发送为0，手动发送为1）
        /// </summary>	
        [Column("SendType")] //数据库真实字段名
        [DisplayName("发送类型（系统发送为0，手动发送为1）")]
        public int SendType
        {
            get;
            set;
        }
        /// <summary>
        /// 发送用户编号（当用户手动发送时，才会有值，可为空）
        /// </summary>	
        [Column("SendUserId")] //数据库真实字段名
        [DisplayName("发送用户编号（当用户手动发送时，才会有值，可为空）")]
        public int? SendUserId
        {
            get;
            set;
        }
        /// <summary>
        /// 发送邮箱地址
        /// </summary>	
        [Column("SendEmailAddr")] //数据库真实字段名
        [DisplayName("发送邮箱地址")]
        public string SendEmailAddr
        {
            get;
            set;
        }
        /// <summary>
        /// 接收邮箱地址
        /// </summary>	
        [Column("ReceiveEmailAddr")] //数据库真实字段名
        [DisplayName("接收邮箱地址")]
        public string ReceiveEmailAddr
        {
            get;
            set;
        }




    }

}


namespace XingAo.Networks.CMS.Model.Mappings//所有映射
{
    /// <summary>
    /// 实体映射表
    /// </summary>
    [Export("Email_SendMapping")]
    public partial class Email_SendMapping : MappingBase<Model.EmailSendModel>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Email_SendMapping()
        {
            //实体映射表名
            this.ToTable("XA_Email_Send");
            //表间关系映射

        }
    }
}