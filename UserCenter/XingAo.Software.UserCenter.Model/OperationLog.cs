﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Software.UserCenter.Model
{
    /// <summary>
    /// 用户操作日志
    /// </summary>
    [Table("XingAo_UserCenter_OperationLog")]
    public partial class OperationLog
    {
        /// <summary>
        /// 操作编号
        /// </summary>
        [Column("UId")]
        [DisplayName("操作编号")]
        public int Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        [Column("UserId")]
        [DisplayName("用户编号")]
        public int UserId { get; set; }
        /// <summary>
        /// 操作类型(可根据配置读取类型）
        /// </summary>
        [Column("Type")]
        [DisplayName("操作类型(可根据配置读取类型）")]
        public int Type { get; set; }
        /// <summary>
        /// 操作IP地址
        /// </summary>
        [Column("IP")]
        [DisplayName("操作IP地址")]
        public string IP { get; set; }
        /// <summary>
        /// 操作日志信息
        /// </summary>
        [Column("Info")]
        [DisplayName("操作信息")]
        public string Info { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        [Column("CreateTime")]
        [DisplayName("操作时间")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual User User { get; set; }
    }
    /// <summary>
    /// 用户信息
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 用户操作日志
        /// </summary>
        public virtual ICollection<OperationLog> OperationLogList { get; set; }
    }
}
namespace XingAo.Software.UserCenter.Model.Mappings
{
    [Export("XingAo_UserCenter_OperationLog")]
    public partial class OperationLogMapping : MappingBase<OperationLog>
    {
        public OperationLogMapping()
        {
            this.ToTable("XingAo_UserCenter_OperationLog");
            this.HasRequired(m => m.User).WithMany(m => m.OperationLogList).HasForeignKey(t => t.UserId);
        }
    }
}