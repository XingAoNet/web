/*=================================
//  模块：XA_Product_OrderAddr实体
//  创建者：Lu
//  创建时间：2014-4-28
//  描述：收货址址表
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
    ///表名：收货址址表的实体
    /// </summary>	
    [Table("XA_Product_OrderAddr")]//数据库真实表名
    public partial class Product_OrderAddr
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
        /// 联系电话
        /// </summary>	
        [Column("Tel")] 
        [DisplayName("联系电话")]
        public string Tel
        {
            get;
            set;
        }
        /// <summary>
        /// 收货地址
        /// </summary>	
        [Column("Addr")] 
        [DisplayName("收货地址")]
        public string Addr
        {
            get;
            set;
        }
        /// <summary>
        /// 收货人姓名
        /// </summary>	
        [Column("Name")] 
        [DisplayName("收货人姓名")]
        public string Name
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
    /// 子表数据关联用
    /// </summary>
    public partial class WebUsers
    {
        /// <summary>
        /// 子表相关数据
        /// </summary>
        public virtual ICollection<Product_OrderAddr> Product_OrderAddrList { get; set; }
    }

}


namespace XingAo.Networks.CMS.Model.Mappings//所有映射
{
    /// <summary>
    /// 实体映射表
    /// </summary>
    [Export("Product_OrderAddrMapping")]
    public partial class Product_OrderAddrMapping : MappingBase<Model.Product_OrderAddr>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Product_OrderAddrMapping()
        {
            //实体映射表名
            this.ToTable("XA_Product_OrderAddr");
            //表间关系映射
            this.HasRequired(m => m.BaseWebUsers).WithMany(m => m.Product_OrderAddrList).HasForeignKey(t => t.UserID);

        }
    }
}