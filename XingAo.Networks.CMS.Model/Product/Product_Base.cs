/*=================================
//  模块：XA_Product_Base实体
//  创建者：Lu
//  创建时间：2014-4-14
//  描述：：商品基础信息表(删除时自动删除属性值，即XA_Product_AttributeValues表的数据)
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
    /// 表名：商品基础信息表(删除时自动删除属性值，即XA_Product_AttributeValues表的数据)的实体
    /// </summary>	
    [Table("XA_Product_Base")]//数据库真实表名
    public partial class Product_Base
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
        /// 商品名称
        /// </summary>	
        [Column("ProductName")] 
        [DisplayName("ProductName")]
        public string ProductName
        {
            get;
            set;
        }
        /// <summary>
        /// 商品图片列表，请用程序控制只能上传5张，多张图片以,间隔
        /// </summary>	
        [Column("PicList")] 
        [DisplayName("商品图片列表，请用程序控制只能上传5张，多张图片以,间隔")]
        public string PicList
        {
            get;
            set;
        }
        /// <summary>
        /// 商品显示价格
        /// </summary>	
        [Column("Price")] 
        [DisplayName("商品显示价格")]
        public decimal Price
        {
            get;
            set;
        }
        /// <summary>
        /// 商品实际销售价格
        /// </summary>	
        [Column("RealPrice")] 
        [DisplayName("商品实际销售价格")]
        public decimal RealPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 商品所属类别id列表，多个id以英文【注意为方便数据查询，存入数据库时两头都带逗号，如,2,5,请程序在处理时去掉两头逗号】,间隔(对应于XA_Product_Class表中的id)
        /// </summary>	
        [Column("ProductClassIDs")] 
        [DisplayName("商品所属类别id列表，多个id以英文,间隔(对应于XA_Product_Class表中的id)")]
        public string ProductClassIDs
        {
            get;
            set;
        }
        /// <summary>
        /// 商品编码
        /// </summary>	
        [Column("ProductNumber")] 
        [DisplayName("商品编码")]
        public string ProductNumber
        {
            get;
            set;
        }
        /// <summary>
        /// 商品库存剩余数量(即还有多少个可以卖)
        /// </summary>	
        [Column("TotalCount")] 
        [DisplayName("商品库存剩余数量(即还有多少个可以卖)")]
        public int TotalCount
        {
            get;
            set;
        }
        /// <summary>
        /// 已卖出多少件
        /// </summary>	
        [Column("SellCount")] 
        [DisplayName("已卖出多少件")]
        public int SellCount
        {
            get;
            set;
        }
        /// <summary>
        /// 商品状态：0--未上架，1--上架出售中，2--库存不足而强制下架
        /// </summary>	
        [Column("State")] 
        [DisplayName("商品状态：0--未上架，1--上架出售中，2--库存不足而强制下架")]
        public int State
        {
            get;
            set;
        }
        /// <summary>
        /// 商品动态属性分组ID（与XA_Product_AttributeGroup表中的ID对应，从而确定此商品更多特有的属性）
        /// </summary>	
        [Column("AttributeGroupID")] 
        [DisplayName("商品动态属性分组ID（与XA_Product_AttributeGroup表中的ID对应，从而确定此商品更多特有的属性）")]
        public int AttributeGroupID
        {
            get;
            set;
        }
        /// <summary>
        /// 购买此商品可得多少积分
        /// </summary>	
        [Column("GetPoint")] 
        [DisplayName("购买此商品可得多少积分")]
        public int GetPoint
        {
            get;
            set;
        }
        /// <summary>
        /// 使用积分支付时，最大允许支付多少积分(100个积分兑1RMB)
        /// </summary>	
        [Column("MaxPayPoint")] 
        [DisplayName("使用积分支付时，最大允许支付多少积分(100个积分兑1RMB)")]
        public int MaxPayPoint
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
    [Export("Product_BaseMapping")]
    public partial class Product_BaseMapping : MappingBase<Model.Product_Base>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Product_BaseMapping()
        {
            //实体映射表名
            this.ToTable("XA_Product_Base");
            //表间关系映射

        }
    }
}