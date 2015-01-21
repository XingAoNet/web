/*=================================
//  模块：XA_CMS_SysLabels实体
//  创建者：Lu
//  创建时间：2013-10-11
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
    ///表名：系统标签库  的实体
    /// </summary>	
    [Table("XA_CMS_SysLabels")]
    public class SysLabels
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
        /// 标签名称
        /// </summary>	
        [Column("LabelName")]
        [DisplayName("标签名称")]
        public string LabelName
        {
            get;
            set;
        }

//NameSpace	nvarchar(50)	Checked
//NameSpaceClass	nvarchar(150)	Checked
//Method	nvarchar(50)	Checked
//Parameters	nvarchar(550)	Checked
        /// <summary>
        /// 根命名空间
        /// </summary>	
        [Column("NameSpace")]
        [DisplayName("根命名空间")]
        public string NameSpace
        {
            get;
            set;
        }
        /// <summary>
        /// 完整的命名空间及类名
        /// </summary>	
        [Column("NameSpaceClass")]
        [DisplayName("完整的命名空间及类名")]
        public string NameSpaceClass
        {
            get;
            set;
        }
        /// <summary>
        /// 调用方法的名称
        /// </summary>	
        [Column("Method")]
        [DisplayName("调用方法的名称")]
        public string Method
        {
            get;
            set;
        }
        /// <summary>
        /// 方法所带的参数，多个参数以英文逗号间隔，无参数则保持为空
        /// </summary>	
        [Column("Parameters")]
        [DisplayName("方法所带的参数")]
        public string Parameters
        {
            get;
            set;
        }
    }
}
