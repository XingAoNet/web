/*=================================
//  模块：XA_SMS_Templates实体
//  创建者：Zheng
//  创建时间：2014-4-9
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
    ///表名：XA_SMS_Templates的实体
    /// </summary>	
    [Table("XA_SMS_Templates")]
    public class XA_SMS_Templates
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
        /// IDateTime
        /// </summary>	
        [Column("IDateTime")]
        [DisplayName("IDateTime")]
        public DateTime IDateTime
        {
            get;
            set;
        }
        /// <summary>
        /// TemplatesName
        /// </summary>	
        [Column("TemplatesName")]
        [DisplayName("TemplatesName")]
        public string TemplatesName
        {
            get;
            set;
        }
        /// <summary>
        /// TemplatesContent
        /// </summary>	
        [Column("TemplatesContent")]
        [DisplayName("TemplatesContent")]
        public string TemplatesContent
        {
            get;
            set;
        }
        /// <summary>
        /// AddTime
        /// </summary>	
        [Column("AddTime")]
        [DisplayName("AddTime")]
        public DateTime AddTime
        {
            get;
            set;
        }
        /// <summary>
        /// EditTime
        /// </summary>	
        [Column("EditTime")]
        [DisplayName("EditTime")]
        public DateTime EditTime
        {
            get;
            set;
        }




        /// <summary>
        /// 主表相关信息
        /// </summary>
        // public virtual XA_SMS_Templates BaseXA_SMS_Templates { get; set; }

        /// <summary>
        /// 子表相关数据
        /// </summary>
        //public virtual ICollection<XA_SMS_Templates> XA_SMS_TemplatesList { get; set; }
    }
}