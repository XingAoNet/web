/*=================================
//  模块：XA_Product_OrderInfo实体
//  创建者：Lu
//  创建时间：2014-4-21
//  描述：：XA_Product_OrderInfo
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
    ///表名：XA_Product_OrderInfo的实体
    /// </summary>	
    [Table("XA_Product_OrderInfo")]//数据库真实表名
    public partial class Product_OrderInfo
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
        /// 主订单编码，对应XA_Product_OrderBase表内的ID
        /// </summary>	
        [Column("OrderBaseID")] 
        [DisplayName("主订单编码，对应XA_Product_OrderBase表内的ID")]
        public int OrderBaseID
        {
            get;
            set;
        }
        /// <summary>
        /// 商品id
        /// </summary>	
        [Column("ProductID")] 
        [DisplayName("商品id")]
        public int ProductID
        {
            get;
            set;
        }
        /// <summary>
        /// 商品名称
        /// </summary>	
        [Column("ProductName")] 
        [DisplayName("商品名称")]
        public string ProductName
        {
            get;
            set;
        }
        /// <summary>
        /// 单价
        /// </summary>	
        [Column("Price")] 
        [DisplayName("单价")]
        public decimal Price
        {
            get;
            set;
        }
        /// <summary>
        /// 购买数量
        /// </summary>	
        [Column("BuyCount")] 
        [DisplayName("购买数量")]
        public int BuyCount
        {
            get;
            set;
        }
        /// <summary>
        /// 是否已确认购买
        /// </summary>	
        [Column("IsConform")] 
        [DisplayName("是否已确认购买")]
        public int IsConform
        {
            get;
            set;
        }
        /// <summary>
        /// 购买此最大可使用多少积分来抵现金（100积分=1RMB）
        /// </summary>	
        [Column("ProductPayMaxPoint")]
        [DisplayName("购买此最大可使用多少积分来抵现金（100积分=1RMB）")]
        public int ProductPayMaxPoint
        {
            get;
            set;
        }
        /// <summary>
        /// 购买此商品可得多少积分
        /// </summary>	
        [Column("ProductGetPoint")] 
        [DisplayName("购买此商品可得多少积分")]
        public int ProductGetPoint
        {
            get;
            set;
        }
        
        /// <summary>
        /// 主表相关信息（当前订单详细上一层的订单信息，即主表数据）
        /// </summary>
        public virtual Product_OrderBase BaseProduct_OrderBase { get; set; }
        /// <summary>
        /// 主表相关信息（当前订单详细所关联的商品基本信息）
        /// </summary>
        public virtual Product_Base BaseProduct_Base { get; set; }
    }
    /// <summary>
    /// 子表数据关联用(此订单下的详细物品列表)
    /// </summary>
    public partial class Product_OrderBase
    {
        /// <summary>
        /// 子表相关数据
        /// </summary>
        public virtual ICollection<Model.Product_OrderInfo> Product_OrderInfoList { get; set; }
    }
    /// <summary>
    /// 子表数据关联(此商品下订单信息)
    /// </summary>
    public partial class Product_Base
    {
        /// <summary>
        /// 子表相关数据
        /// </summary>
        public virtual ICollection<Model.Product_OrderInfo> Product_BaseList { get; set; }
    }
}


namespace XingAo.Networks.CMS.Model.Mappings//所有映射
{
    /// <summary>
    /// 实体映射表
    /// </summary>
    [Export("Product_OrderInfoMapping")]
    public partial class Product_OrderInfoMapping : MappingBase<Model.Product_OrderInfo>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Product_OrderInfoMapping()
        {
            //实体映射表名
            this.ToTable("XA_Product_OrderInfo");
            //表间关系映射
            this.HasRequired(m => m.BaseProduct_OrderBase).WithMany(m => m.Product_OrderInfoList).HasForeignKey(t => t.OrderBaseID);
            //表间关系映射
            this.HasRequired(m => m.BaseProduct_Base).WithMany(m => m.Product_BaseList).HasForeignKey(t => t.ProductID);

        }
    }
}