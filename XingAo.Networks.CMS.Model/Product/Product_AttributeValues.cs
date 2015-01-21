/*=================================
//  模块：XA_Product_AttributeValues实体
//  创建者：Lu
//  创建时间：2014-4-14
//  描述：：商品其它属性提交的值
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
    ///表名：商品其它属性提交的值的实体
    /// </summary>	
	[Table("XA_Product_AttributeValues")]//数据库真实表名
	public partial class Product_AttributeValues
	{    
	      			/// <summary>
		/// 主键ID
        /// </summary>	
		[Key, Column("ID" ,Order = 1)]
        [DisplayName("编号")]        
        public int ID
        {
            get;set;
        }    
		  		/// <summary>
		/// 商品ID，对应XA_Product_Base表中的id,与XA_Product_Base表联级删除
        /// </summary>	
		[Column("ProductBaseID")] 
		[DisplayName("商品ID，对应XA_Product_Base表中的id,与XA_Product_Base表联级删除")]
        public int ProductBaseID
        {
            get;set;
        }        
				/// <summary>
		/// 属性名称
        /// </summary>	
		[Column("AttrName")] 
		[DisplayName("属性名称")]
        public string AttrName
        {
            get;set;
        }        
				/// <summary>
		/// 属性值
        /// </summary>	
		[Column("AttrValue")] 
		[DisplayName("属性值")]
        public string AttrValue
        {
            get;set;
        }        
				
		    /// <summary>
        /// 主表相关信息
        /// </summary>
        public virtual Product_Base BaseProduct_Base { get; set; }
   
       
       
}

    /// <summary>
    /// 子表数据关联用
    /// </summary>
    public partial class Product_Base
    {
        /// <summary>
        /// 子表相关数据
        /// </summary>
        public virtual ICollection<Product_AttributeValues> Product_AttributeValuesList { get; set; }
    }

}


namespace XingAo.Networks.CMS.Model.Mappings//所有映射
{
/// <summary>
        /// 实体映射表
        /// </summary>
    [Export("Product_AttributeValuesMapping")]
    public partial class Product_AttributeValuesMapping : MappingBase<Model.Product_AttributeValues>
    {
    /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Product_AttributeValuesMapping()
        {
        //实体映射表名
            this.ToTable("XA_Product_AttributeValues");
            //表间关系映射
            this.HasRequired(m => m.BaseProduct_Base).WithMany(m => m.Product_AttributeValuesList).HasForeignKey(t => t.ProductBaseID);

        }
    }
}