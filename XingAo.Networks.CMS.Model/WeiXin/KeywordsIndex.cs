/*=================================
//  模块：XA_KeywordsIndex实体
//  创建者：Lu
//  创建时间：2013-12-2
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
    ///表名：关键字自动回复索引表  的实体
    /// </summary>	
    [Table("XA_WeiXin_KeywordsIndex")]
    public class KeywordsIndex
    {
        /// <summary>
        /// 内部自增标识ID
        /// </summary>	
        [Key, Column("ID", Order = 1)]
        [DisplayName("编号")]
        public int ID
        {
            get;
            set;
        }


        /// <summary>
        /// 微信Guid
        /// </summary>	
        [Column("WGuid")]
        [DisplayName("微信Guid")]
        public string WGuid
        {
            get;
            set;
        }


        /// <summary>
        /// 关键字
        /// </summary>	
        [Column("KeyWords")]
        [DisplayName("关键字")]
        public string KeyWords
        {
            get;
            set;
        }


        /// <summary>
        /// 表名(数据存放于哪个表中)
        /// </summary>	
        [Column("TableName")]
        [DisplayName("表名(数据存放于哪个表中)")]
        public string TableName
        {
            get;
            set;
        }

        /// <summary>
        /// 主键值（即哪一行数据）
        /// </summary>	
        [Column("PrimaryValue")]
        [DisplayName("主键值（即哪一行数据）")]
        public string PrimaryValue
        {
            get;
            set;
        }
    }
}














/*=================================
//  模块：XA_KeywordsIndex 映射表名
//  创建者：Lu
//  创建时间：2013-12-2
=================================*/

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("KeywordsIndexMapping")]
    public class KeywordsIndexMapping : MappingBase<KeywordsIndex>
    {
        public KeywordsIndexMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_KeywordsIndex");
            //this.HasRequired(m => m.Group).WithMany(m => m.Class).HasForeignKey(t => t.GroupId);

        }
    }
}
