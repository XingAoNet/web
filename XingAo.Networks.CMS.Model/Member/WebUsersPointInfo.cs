/*=================================
//  模块：XA_CMS_WebUsersPointInfo实体
//  创建者：Lu
//  创建时间：2014-4-22
//  描述：：用户积分流水记录表
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
    ///表名：用户积分流水记录表的实体
    /// </summary>	
    [Table("XA_Member_PointInfo")]//数据库真实表名
    public partial class WebUsersPointInfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>	
        [Key, Column("ID", Order = 1)]
        [DisplayName("编号")]
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 影响积分的名称，比如：兑换xxx、签到得xxx分、注册时系统赠送等之类的描述
        /// </summary>	
        [Column("Title")] 
        [DisplayName("影响积分的名称，比如：兑换xxx、签到得xxx分、注册时系统赠送等之类的描述")]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 此条数据操作前，当前用户有多少积分
        /// </summary>	
        [Column("BeforePoint")] 
        [DisplayName("此条数据操作前，当前用户有多少积分")]
        public long BeforePoint
        {
            get;
            set;
        }
        /// <summary>
        /// 当前操作增加或减少多少积分（注意：减少为负数）
        /// </summary>	
        [Column("Point")] 
        [DisplayName("当前操作增加或减少多少积分（注意：减少为负数）")]
        public long? Point
        {
            get;
            set;
        }
        /// <summary>
        /// 在此条数据操作完成后，用户还有多少积分
        /// </summary>	
        [Column("AfterPoint")] 
        [DisplayName("在此条数据操作完成后，用户还有多少积分")]
        public long AfterPoint
        {
            get;
            set;
        }
        /// <summary>
        /// 用户id
        /// </summary>	
        [Column("UserID")] 
        [DisplayName("用户id")]
        public int UserID
        {
            get;
            set;
        }
        /// <summary>
        /// 操作时间
        /// </summary>	
        [Column("CreateTime")] 
        [DisplayName("操作时间")]
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 是否审核通过，0--未处理 1--通过 2--拒绝(征对兑换之类需要审核的情况，如果无需审核的，请在数据操作时直接提交成通过状态即可)
        /// </summary>	
        [Column("IsPass")] 
        [DisplayName("是否审核通过，0--未处理 1--通过 2--拒绝(征对兑换之类需要审核的情况，如果无需审核的，请在数据操作时直接提交成通过状态即可)")]
        public int IsPass
        {
            get;
            set;
        }
        /// <summary>
        /// 审核人id(征对兑换之类需要审核的情况，如果无需审核的，此字段值为用户自己的id)
        /// </summary>	
        [Column("AuditUserID")] 
        [DisplayName("审核人id(征对兑换之类需要审核的情况，如果无需审核的，此字段值为用户自己的id)")]
        public int AuditUserID
        {
            get;
            set;
        }
        /// <summary>
        /// 审核通过时间
        /// </summary>	
        [Column("AuditTime")] 
        [DisplayName("审核通过时间")]
        public DateTime AuditTime
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>	
        [Column("Descriptions")] 
        [DisplayName("备注")]
        public string Descriptions
        {
            get;
            set;
        }
        /// <summary>
        /// 主表相关信息
        /// </summary>
        public virtual WebUsers BaseWebUsers { get; set; }



    }

    /// <summary>
    /// 子表数据关联用(用户积分明细列表)
    /// </summary>
    public partial class WebUsers
    {
        /// <summary>
        /// 子表相关数据
        /// </summary>
        public virtual ICollection<WebUsersPointInfo> WebUsersPointInfoList { get; set; }
    }

}


namespace XingAo.Networks.CMS.Model.Mappings//所有映射
{
    /// <summary>
    /// 实体映射表
    /// </summary>
    [Export("WebUsersPointInfoMapping")]
    public partial class CMS_WebUsersPointInfoMapping : MappingBase<Model.WebUsersPointInfo>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public CMS_WebUsersPointInfoMapping()
        {
            //实体映射表名
            this.ToTable("XA_Member_PointInfo");
            //表间关系映射
            this.HasRequired(m => m.BaseWebUsers).WithMany(m => m.WebUsersPointInfoList).HasForeignKey(t => t.UserID);

        }
    }
}