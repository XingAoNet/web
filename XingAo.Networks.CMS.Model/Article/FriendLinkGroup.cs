/*=================================
//  模块：XA_CMS_FriendLinkGroup实体
//  创建者：Lu
//  创建时间：2013-10-16
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
    ///表名：友情链接分组表  的实体
    /// </summary>	
    [Table("XA_CMS_FriendLinkGroup")]
    public class FriendLinkGroup
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
        /// GroupName
        /// </summary>	
        [Column("GroupName")]
        [DisplayName("GroupName")]
        public string GroupName
        {
            get;
            set;
        }
        /// <summary>
        /// 此组下面的所有友情链接数据
        /// </summary>
        public virtual ICollection<FriendLink> FriendLinkList { get; set; }
    }
}