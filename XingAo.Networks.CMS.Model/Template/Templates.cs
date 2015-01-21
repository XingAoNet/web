/*=================================
//  模块：XA_CMS_Templates实体
//  创建者：Lu
//  创建时间：2013-9-24
=================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：模板  的实体
    /// </summary>	
    [Table("XA_CMS_Templates")]
    public class Templates
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
        /// 模板名称
        /// </summary>	
        [Column("TemplateName")]
        [DisplayName("模板名称")]
        public string TemplateName
        {
            get;
            set;
        }

        /// <summary>
        /// 模板英文名称
        /// </summary>	
        [Column("TemplateEName")]
        [DisplayName("模板英文名称")]
        public string TemplateEName
        {
            get;
            set;
        }

        /// <summary>
        /// 模板描述说明
        /// </summary>	
        [Column("TemplateDescription")]
        [DisplayName("模板描述说明")]
        public string TemplateDescription
        {
            get;
            set;
        }


         /// <summary>
        /// 模板分组ID
        /// </summary>	
        [Column("TemplateGroupId")]
        [DisplayName("TemplateGroupId")]
        public int? TemplateGroupId
        {
            get;
            set;
        }

        /// <summary>
        /// 模板内容
        /// </summary>	
        [Column("TemplateHtml")]
        [DisplayName("模板内容")]
        public string TemplateHtml
        {
            get;
            set;
        }


        /// <summary>
        /// 模板类型0--公共模块 1--首页模板 2--列表页模板 3--详细页模板
        /// </summary>	
        [Column("TemplateType")]
        [DisplayName("模板类型0--公共模块 1--首页模板 2--列表页模板 3--详细页模板")]
        public int TemplateType
        {
            get;
            set;
        }
    }
}