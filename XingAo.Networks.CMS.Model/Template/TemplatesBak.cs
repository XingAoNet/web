/*=================================
//  模块：XA_CMS_TemplatesBak实体
//  创建者：Lu
//  创建时间：2013-9-28
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
    ///表名：模板备份表  的实体
    /// </summary>	
    [Table("XA_CMS_TemplatesBak")]
    public class TemplatesBak
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
        /// 备份名称
        /// </summary>	
        [Column("Title")]
        [DisplayName("备份名称")]
        public string Title
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


        /// <summary>
        /// 备份文件所在目录
        /// </summary>	
        [Column("DirName")]
        [DisplayName("备份文件所在目录")]
        public string DirName
        {
            get;
            set;
        }


        /// <summary>
        /// 创建时间
        /// </summary>	
        [Column("CreateTime")]
        [DisplayName("创建时间")]
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 最后更新时间
        /// </summary>	
        [Column("LastUpdateTime")]
        [DisplayName("最后更新时间")]
        public DateTime LastUpdateTime
        {
            get;
            set;
        }
    }

}
namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("TemplatesBakMapping")]
    public class TemplatesBakMapping : MappingBase<TemplatesBak>
    {
        public TemplatesBakMapping()
        {
            this.ToTable("XA_CMS_TemplatesBak");
        }
    }
}