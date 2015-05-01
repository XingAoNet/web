/*=================================
//  模块：XingAo_SysConfigs_EmailTemplate实体
//  创建者：ccj
//  创建时间：2015/4/23
//  描述：邮件模板
//  生成模板来源：Networks.CMS.Model_V1.4.cmt
=================================*/
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Software.ConfigCenter
{	
    /// <summary>
	///邮件模板
	/// </summary>	
    [DBSource("XingAo_SysConfigs")]
    [Table("XingAo_SysConfigs_EmailTemplate")]
    public partial class EmailTemplateModel
    {
        /// <summary>
        /// 主键邮件模板
        /// </summary>	
        [Key, Column("UId", Order = 1)]
        [Display(Name = "编号")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        [Column("Name")]
        [Display(Name = "模板名称")]
        public string Name { get; set; }
        /// <summary>
        /// 模板标题
        /// </summary>
        [Column("Title")]
        [Display(Name = "模板标题")]
        public string Title { get; set; }
        /// <summary>
        /// 内容（可以保存为XML或者JSON）
        /// </summary>
        [Column("Value")]
        [Display(Name = "模板内容")]
        public string Value { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [Column("Description")]
        [Display(Name = "说明")]
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime")]
        [Display(Name = "创建时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        [Column("CreateName")]
        [Display(Name = "创建人名称")]
        public string CreateName { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        [Column("CreateId")]
        [Display(Name = "创建人编号")]
        public int CreateId { get; set; }

    }
}
namespace XingAo.Software.ConfigCenter.Mappings
{
	/// <summary>
	/// 邮件模板的映射表
	/// </summary>
    [Export("SysConfigs_EmailTemplateMapping")]
    public partial class SysConfigs_EmailTemplateMapping : MappingBase<EmailTemplateModel>
    {
		/// <summary>
		/// 实体映射表名及表间关系
		/// </summary>
		public SysConfigs_EmailTemplateMapping()
		{
			this.ToTable("XingAo_SysConfigs_EmailTemplate");
			
        }
    }
}