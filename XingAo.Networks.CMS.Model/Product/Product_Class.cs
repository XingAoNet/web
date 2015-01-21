/*=================================
//  模块：XA_Product_Class实体
//  创建者：Lu
//  创建时间：2014-4-14
//  描述：：商品类别表
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
    ///表名：商品类别表的实体
    /// </summary>	
    [Table("XA_Product_Class")]//数据库真实表名
    public partial class Product_Class
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
        /// 类别名称
        /// </summary>	
        [Column("ClassName")] 
        [DisplayName("类别名称")]
        public string ClassName
        {
            get;
            set;
        }
        /// <summary>
        /// 类别编码
        /// </summary>	
        [Column("ClassCode")] 
        [DisplayName("类别编码")]
        public string ClassCode
        {
            get;
            set;
        }
        /// <summary>
        /// 使用图片来显示分类时的图片地址,空为不使用图片（只使用文本）
        /// </summary>	
        [Column("Pic")] 
        [DisplayName("使用图片来显示分类时的图片地址,空为不使用图片（只使用文本）")]
        public string Pic
        {
            get;
            set;
        }
        /// <summary>
        /// 使用图片来显示分类时的移植移上去时图片地址,空为不使用图片（只使用文本）
        /// </summary>	
        [Column("PicHover")] 
        [DisplayName("使用图片来显示分类时的移植移上去时图片地址,空为不使用图片（只使用文本）")]
        public string PicHover
        {
            get;
            set;
        }
        /// <summary>
        /// 商品默认价格（在添加新商品时，商品价格默认按此值填写，但用户可在编辑自行修改成另一个价格）
        /// </summary>	
        [Column("DefaultPrice")] 
        [DisplayName("商品默认价格（在添加新商品时，商品价格默认按此值填写，但用户可在编辑自行修改成另一个价格）")]
        public decimal? DefaultPrice
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
    [Export("Product_ClassMapping")]
    public partial class Product_ClassMapping : MappingBase<Model.Product_Class>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Product_ClassMapping()
        {
            //实体映射表名
            this.ToTable("XA_Product_Class");
            //表间关系映射

        }
    }
}