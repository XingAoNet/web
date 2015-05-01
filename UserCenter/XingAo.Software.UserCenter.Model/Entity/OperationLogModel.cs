using System;
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
    [DBSource("XingAo_UserCenter")]
    [Table("XingAo_UserCenter_OperationLog")]
    public partial class OperationLogModel
    {
        /// <summary>
        /// 操作编号
        /// </summary>
        [Key,Column("UId", Order = 1)]
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
        public virtual UserModel User { get; set; }
    }
    /// <summary>
    /// 用户信息
    /// </summary>
    public partial class UserModel
    {
        /// <summary>
        /// 用户操作日志
        /// </summary>
        public virtual ICollection<OperationLogModel> OperationLogList { get; set; }
    }
}
namespace XingAo.Software.UserCenter.Model.Mappings
{
    [Export("OperationLogMapping")]
    public partial class OperationLogMapping : MappingBase<OperationLogModel>
    {
        public OperationLogMapping()
        {
            this.ToTable("XingAo_UserCenter_OperationLog");
            this.HasRequired(m => m.User).WithMany(m => m.OperationLogList).HasForeignKey(t => t.UserId);
        }
    }
}