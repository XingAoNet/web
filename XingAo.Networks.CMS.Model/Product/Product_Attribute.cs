/*=================================
//  模块：XA_Product_Attribute实体
//  创建者：Lu
//  创建时间：2014-4-14
//  描述：：商品属性信息，主要用于后台渲染编辑界面
//  生成模板来源：Networks.CMS.Model_V1.3.cmt
=================================*/
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model
{
	/// <summary>
    ///表名：商品属性信息，主要用于后台渲染编辑界面的实体
    /// </summary>	
    [Table("XA_Product_Attribute")]//数据库真实表名
    public partial class Product_Attribute
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
        /// 所属组id
        /// </summary>	
        [Column("GroupID")] 
        [DisplayName("所属组id")]
        public int GroupID
        {
            get;
            set;
        }
        /// <summary>
        /// AttrName
        /// </summary>	
        [Column("AttrName")] 
        [DisplayName("AttrName")]
        public string AttrName
        {
            get;
            set;
        }
        /// <summary>
        /// Descriptions
        /// </summary>	
        [Column("Descriptions")] 
        [DisplayName("Descriptions")]
        public string Descriptions
        {
            get;
            set;
        }
        /// <summary>
        /// 排序号，越大越前
        /// </summary>	
        [Column("OrderNum")] 
        [DisplayName("排序号，越大越前")]
        public int OrderNum
        {
            get;
            set;
        }

        /// <summary>
        /// 渲染控件类型、验证类型等等的json
        /// </summary>	
        [Column("ControlResendJson")] 
        [DisplayName("渲染控件类型、验证类型等等的json")]
        public string ControlResendJson
        {
            get;
            set;
        }

        /// <summary>
        /// 主表相关信息
        /// </summary>
        public virtual Product_AttributeGroup BaseProduct_AttributeGroup { get; set; }



    }

    /// <summary>
    /// 子表数据关联用
    /// </summary>
    public partial class Product_AttributeGroup
    {
        /// <summary>
        /// 子表相关数据
        /// </summary>
        public virtual ICollection<Product_Attribute> Product_AttributeList { get; set; }
    }

}


namespace XingAo.Networks.CMS.Model.Mappings//所有映射
{
    /// <summary>
    /// 实体映射表
    /// </summary>
    [Export("Product_AttributeMapping")]
    public partial class Product_AttributeMapping : MappingBase<Model.Product_Attribute>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Product_AttributeMapping()
        {
            //实体映射表名
            this.ToTable("XA_Product_Attribute");
            //表间关系映射
            this.HasRequired(m => m.BaseProduct_AttributeGroup).WithMany(m => m.Product_AttributeList).HasForeignKey(t => t.GroupID);

        }
    }
}