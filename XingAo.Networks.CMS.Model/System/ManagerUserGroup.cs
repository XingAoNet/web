/*=================================
//  模块：XA_CMS_ManagerUserGroup实体
//  创建者：Lu
//  创建时间：2013-10-31
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
    ///表名：后台用户组表  的实体
    /// </summary>	
    [Table("XA_CMS_ManagerUserGroup")]
    public class ManagerUserGroup
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
        /// 后台用户组名称
        /// </summary>	
        [Column("GroupName")]
        [DisplayName("后台用户组名称")]
        public string GroupName
        {
            get;
            set;
        }


        /// <summary>
        /// 允许控制网站前台栏目
        /// </summary>	
        [Column("Navigation")]
        [DisplayName("允许控制网站前台栏目")]
        public string Navigation
        {
            get;
            set;
        }


        /// <summary>
        /// 允许操作后台菜单
        /// </summary>	
        [Column("SystemMenu")]
        [DisplayName("允许操作后台菜单")]
        public string SystemMenu
        {
            get;
            set;
        }
    }
}