/*=================================
//  模块：XA_Product_OrderBase实体
//  创建者：Lu
//  创建时间：2014-4-21
//  描述：：XA_Product_OrderBase
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
    ///表名：XA_Product_OrderBase的实体
    /// </summary>	
    [Table("XA_Product_OrderBase")]//数据库真实表名
    public partial class Product_OrderBase
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
        /// 订单编号
        /// </summary>	
        [Column("OrderCode")] 
        [DisplayName("订单编号")]
        public string OrderCode
        {
            get;
            set;
        }
        /// <summary>
        /// 订单状态（详细请参考OrderStateEnum，强烈建议使用枚举）
        /// </summary>	
        [Column("State")] 
        [DisplayName("订单状态（详细请参考OrderStateEnum）")]
        public int State
        {
            get;
            set;
        }
        /// <summary>
        /// 用户自己是否删除此订单：0未删除 1已删除
        /// </summary>	
        [Column("UserDel")] 
        [DisplayName("用户自己是否删除此订单：0未删除 1已删除")]
        public int UserDel
        {
            get;
            set;
        }
        /// <summary>
        /// 订单创建时间
        /// </summary>	
        [Column("CreateTime")] 
        [DisplayName("订单创建时间")]
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 订单状态最后一次修改时间
        /// </summary>	
        [Column("LastStateTime")] 
        [DisplayName("订单状态最后一次修改时间")]
        public DateTime? LastStateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 管理员订单状态：（详细请参考OrderManagerStateEnum）
        /// </summary>	
        [Column("ManagerState")] 
        [DisplayName("管理员订单状态：（详细请参考OrderManagerStateEnum）")]
        public int ManagerState
        {
            get;
            set;
        }
        /// <summary>
        /// 订单创建者
        /// </summary>	
        [Column("CreateUserID")] 
        [DisplayName("订单创建者")]
        public int CreateUserID
        {
            get;
            set;
        }
        /// <summary>
        /// 管理员订单状态最后一次修改者id（管理员id）
        /// </summary>	
        [Column("ChangeManagerStateUserID")] 
        [DisplayName("管理员订单状态最后一次修改者id（管理员id）")]
        public int? ChangeManagerStateUserID
        {
            get;
            set;
        }
        /// <summary>
        /// 打折后的总价(只在确定购买时更新，未确认前为不正确的价格)
        /// </summary>	
        [Column("RebateTotalPrice")] 
        [DisplayName("打折后的总价(只在确定购买时更新，未确认前为不正确的价格)")]
        public decimal RebateTotalPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 打折前总价(只在确定购买时更新，未确认前为不正确的价格)
        /// </summary>	
        [Column("TotalPrice")] 
        [DisplayName("打折前总价(只在确定购买时更新，未确认前为不正确的价格)")]
        public decimal TotalPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 折扣备注说明
        /// </summary>	
        [Column("RebateDescription")] 
        [DisplayName("折扣备注说明")]
        public string RebateDescription
        {
            get;
            set;
        }
        /// <summary>
        /// 收货人信息表（XA_Product_OrderAddr）id
        /// </summary>
        [Column("ReciceInfoID")] 
        [DisplayName("折扣备注说明")]
        public int ReciceInfoID
        {
            get;
            set;
        }
        
        /// <summary>
        /// 主表相关信息（此订单的关联用户信息）
        /// </summary>
        public virtual WebUsers BaseWebUsers { get; set; }
    }
    /// <summary>
    /// 子表数据关联用
    /// </summary>
    public partial class WebUsers
    {
        /// <summary>
        /// 子表相关数据(此用户下的订单主表信息)
        /// </summary>
        public virtual ICollection<Product_OrderBase> Product_OrderBaseList { get; set; }
    }

}


namespace XingAo.Networks.CMS.Model.Mappings//所有映射
{
    /// <summary>
    /// 实体映射表
    /// </summary>
    [Export("Product_OrderBaseMapping")]
    public partial class Product_OrderBaseMapping : MappingBase<Model.Product_OrderBase>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Product_OrderBaseMapping()
        {
            //实体映射表名
            this.ToTable("XA_Product_OrderBase");
            this.ToTable("XA_Product_OrderBase");
            //表间关系映射
            this.HasRequired(m => m.BaseWebUsers).WithMany(m => m.Product_OrderBaseList).HasForeignKey(t => t.CreateUserID);

        }
    }
}