/*=================================
//  模块：XA_CMS_CustomTable实体
//  创建者：Lu
//  创建时间：2013-8-13
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
    ///表名：用户自定义表  表名、中文名、描述等信息  的实体
    /// </summary>	
    [Table("XA_CMS_CustomTable")]
    public class CustomTable
    {
        /// <summary>
        /// 内部自增标识{用户自定义表}
        /// </summary>	
        [Key, Column("ID", Order = 1)]
        [DisplayName("编号")]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// 表名
        /// </summary>	
        [Column("TabName")]
        [DisplayName("表名")]
        public string TabName
        {
            get;
            set;
        }

        /// <summary>
        /// 表中文名称
        /// </summary>	
        [Column("ChineseName")]
        [DisplayName("表中文名称")]
        public string ChineseName
        {
            get;
            set;
        }

        /// <summary>
        /// 描述\说明
        /// </summary>	
        [Column("Description")]
        [DisplayName("描述说明")]
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 是否为系统表,1是0不是 系统表不能被删除
        /// </summary>	
        [Column("IsSystemTable")]
        [DisplayName("是否为系统表,1是0不是 系统表不能被删除")]
        public int IsSystemTable
        {
            get;
            set;
        }
        /// <summary>
        /// 表字段集合
        /// </summary>
        public virtual ICollection<CustomTableField> CustomTableFields { get; set; }
    }
}