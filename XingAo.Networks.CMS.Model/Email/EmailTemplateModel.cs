/******************************************************************
* Create By:陈成杰
* Create Time:2014-05-29 15:45:32
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
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
    ///表名：XA_Email_Template的实体
    /// </summary>	
    [Table("XA_Email_Template")]//数据库真实表名
    public partial class EmailTemplateModel
    {
        /// <summary>
        /// 邮箱模板管理
        /// </summary>	
        [Column("Id")] //数据库真实字段名
        [DisplayName("邮箱模板管理")]
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 模板名称
        /// </summary>	
        [Column("Name")] //数据库真实字段名
        [DisplayName("模板名称")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 模板标题
        /// </summary>
        [Column("Title")] //数据库真实字段名
        [DisplayName("模板标题")]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 模板内容
        /// </summary>	
        [Column("Info")] //数据库真实字段名
        [DisplayName("模板内容")]
        public string Info
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>	
        [Column("CreateTime")] //数据库真实字段名
        [DisplayName("创建时间")]
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 修改时间
        /// </summary>	
        [Column("ModifyTime")] //数据库真实字段名
        [DisplayName("修改时间")]
        public DateTime ModifyTime
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
    [Export("Email_TemplateMapping")]
    public partial class Email_TemplateMapping : MappingBase<Model.EmailTemplateModel>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public Email_TemplateMapping()
        {
            //实体映射表名
            this.ToTable("XA_Email_Template");
            //表间关系映射
        }
    }
}