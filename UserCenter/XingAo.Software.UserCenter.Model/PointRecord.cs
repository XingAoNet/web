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
    /// 用户积分流水记录
    /// </summary>
    [Table("XingAo_UserCenter_PointRecord")]
    public partial class PointRecord
    {
        /// <summary>
        /// 主键ID
        /// </summary>	
        [Key, Column("ID", Order = 1)]
        [DisplayName("编号")]
        public int ID { get; set; }
        /// <summary>
        /// 影响积分的名称，比如：兑换xxx、签到得xxx分、注册时系统赠送等之类的描述
        /// </summary>	
        [Column("Usage")]
        [DisplayName("影响积分的名称，比如：兑换xxx、签到得xxx分、注册时系统赠送等之类的描述")]
        public string Usage { get; set; }
        /// <summary>
        /// 此条数据操作前，当前用户有多少积分
        /// </summary>	
        [Column("BeforePoint")]
        [DisplayName("此条数据操作前，当前用户有多少积分")]
        public long BeforePoint { get; set; }
        /// <summary>
        /// 当前操作增加或减少多少积分（注意：减少为负数）
        /// </summary>	
        [Column("Point")]
        [DisplayName("当前操作增加或减少多少积分（注意：减少为负数）")]
        public long? Point { get; set; }
        /// <summary>
        /// 在此条数据操作完成后，用户还有多少积分
        /// </summary>	
        [Column("AfterPoint")]
        [DisplayName("在此条数据操作完成后，用户还有多少积分")]
        public long AfterPoint { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>	
        [Column("UserID")]
        [DisplayName("用户编号")]
        public int UserID { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>	
        [Column("CreateTime")]
        [DisplayName("操作时间")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否审核通过，0--未处理 1--通过 2--拒绝(征对兑换之类需要审核的情况，如果无需审核的，请在数据操作时直接提交成通过状态即可)
        /// </summary>	
        [Column("IsAudit")]
        [DisplayName("是否审核通过，0--未处理 1--通过 2--拒绝(征对兑换之类需要审核的情况，如果无需审核的，请在数据操作时直接提交成通过状态即可)")]
        public int IsAudit { get; set; }
        /// <summary>
        /// 审核人id(征对兑换之类需要审核的情况，如果无需审核的，此字段值为用户自己的id)
        /// </summary>	
        [Column("AuditUserID")]
        [DisplayName("审核人编号(征对兑换之类需要审核的情况，如果无需审核的，此字段值为用户自己的id)")]
        public int AuditUserID { get; set; }
        /// <summary>
        /// 审核通过时间
        /// </summary>	
        [Column("AuditTime")]
        [DisplayName("审核通过时间")]
        public DateTime AuditTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>	
        [Column("Descriptions")]
        [DisplayName("备注")]
        public string Descriptions { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual User User { get; set; }
    }

    public partial class User
    {
        /// <summary>
        /// 用户积分流水记录列表
        /// </summary>
        public virtual ICollection<PointRecord> PointRecordList { get; set; }
    }
}

namespace XingAo.Software.UserCenter.Model.Mappings
{
    [Export("XingAo_UserCenter_PointRecord")]
    public partial class PointRecordMapping : MappingBase<Model.PointRecord>
    {
        public PointRecordMapping()
        {
            this.ToTable("XingAo_UserCenter_PointRecord");
            this.HasRequired(m => m.User).WithMany(m => m.PointRecordList).HasForeignKey(t => t.UserID);
            //当用户时审核人时，关联审核信息（建议用管理员ID）
            //this.HasRequired(m => m.User).WithMany(m => m.PointRecordList).HasForeignKey(t => t.AuditUserID);
        }
    }
}