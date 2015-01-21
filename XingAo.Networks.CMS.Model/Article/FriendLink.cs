/*=================================
//  模块：XA_CMS_FriendLink实体
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
    ///表名：XA_CMS_FriendLink（友情链接）  的实体
    /// </summary>	
    [Table("XA_CMS_FriendLink")]
    public class FriendLink
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
        /// 所属友情链接分组ID
        /// </summary>	
        [Column("GroupID")]
        [DisplayName("所属友情链接分组ID")]
        public int GroupID
        {
            get;
            set;
        }


        /// <summary>
        /// 标题名称
        /// </summary>	
        [Column("Title")]
        [DisplayName("标题名称")]
        public string Title
        {
            get;
            set;
        }


        /// <summary>
        /// 图片类友情链接的图片（如果为空则表示文字类）
        /// </summary>	
        [Column("Pic")]
        [DisplayName("图片类友情链接的图片（如果为空则表示文字类）")]
        public string Pic
        {
            get;
            set;
        }


        /// <summary>
        /// 链接地址
        /// </summary>	
        [Column("LinkUrl")]
        [DisplayName("链接地址")]
        public string LinkUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 当前友情链接数据所属分组信息
        /// </summary>
        public virtual FriendLinkGroup Groups { get; set; }
    }
}