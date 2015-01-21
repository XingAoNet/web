/*=================================
//  模块：XA_CMS_AdvertisingGroup实体
//  创建者：Lu
//  创建时间：2013-10-19
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
    ///表名：广告分组  的实体
    /// </summary>	
    [Table("XA_CMS_AdvertisingGroup")]
    public class AdvertisingGroup
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
        /// 分组名称
        /// </summary>	
        [Column("GroupName")]
        [DisplayName("分组名称")]
        public string GroupName
        {
            get;
            set;
        }
        /// <summary>
        /// 此组下面的所有友情链接数据
        /// </summary>
        public virtual ICollection<Advertising> AdvertisingList { get; set; }
    }
}