/*=================================
//  模块：XA_Product_AttributeGroup实体
//  创建者：Lu
//  创建时间：2014-4-14
//  描述：：商品动态属性分组表(删除时会级联删除对应的属性配置信息,即XA_Product_Attribute表数据)
//  生成模板来源：Networks.CMS.Model_V1.3.cmt
=================================*/
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：商品动态属性分组表(删除时会级联删除对应的属性配置信息,即XA_Product_Attribute表数据)的实体
    /// </summary>	
    [Table("XA_Product_AttributeGroup")]//数据库真实表名
    public partial class Product_AttributeGroup
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
        /// GroupName
        /// </summary>	
        [Column("GroupName")]
        [DisplayName("GroupName")]
        public string GroupName
        {
            get;
            set;
        }
        /// <summary>
        /// 描述说明
        /// </summary>	
        [Column("Descriptions")]
        [DisplayName("描述说明")]
        public string Descriptions
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
    [Export("Product_AttributeGroupMapping")]
    public partial class Product_AttributeGroupMapping : MappingBase<Model.Product_AttributeGroup>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Product_AttributeGroupMapping()
        {
            //实体映射表名
            this.ToTable("XA_Product_AttributeGroup");
            //表间关系映射

        }
    }
}