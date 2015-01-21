/*=================================
//  模块：XA_CMS_ManagerUser实体
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
    ///表名：后台用户表  的实体
    /// </summary>	
    [Table("XA_CMS_ManagerUser")]
    public class ManagerUser
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
        /// 用户名
        /// </summary>	
        [Column("UserName")]
        [DisplayName("用户名")]
        public string UserName
        {
            get;
            set;
        }


        /// <summary>
        /// 密码
        /// </summary>	
        [Column("Pwd")]
        [DisplayName("密码")]
        public string Pwd
        {
            get;
            set;
        }


        /// <summary>
        /// 真实姓名
        /// </summary>	
        [Column("RealName")]
        [DisplayName("真实姓名")]
        public string RealName
        {
            get;
            set;
        }


        /// <summary>
        /// 最后一次登录成功时间
        /// </summary>	
        [Column("LastLogin")]
        [DisplayName("最后一次登录成功时间")]
        public DateTime LastLogin
        {
            get;
            set;
        }


        /// <summary>
        /// 尝试密码错误次数（超过3次将锁定30分钟）
        /// </summary>	
        [Column("ErrTimes")]
        [DisplayName("尝试密码错误次数（超过3次将锁定30分钟）")]
        public int ErrTimes
        {
            get;
            set;
        }


        /// <summary>
        /// 最后一次密码错误时间（超过3密码错误次将锁定30分钟）
        /// </summary>	
        [Column("LastErrTime")]
        [DisplayName("最后一次密码错误时间（超过3密码错误次将锁定30分钟）")]
        public DateTime LastErrTime
        {
            get;
            set;
        }


        /// <summary>
        /// 0不可用，1可用
        /// </summary>	
        [Column("CanUse")]
        [DisplayName("0不可用，1可用")]
        public int CanUse
        {
            get;
            set;
        }


        /// <summary>
        /// 用户类型：0超级管理员 1站点管理员 2普通后台用户
        /// </summary>	
        [Column("UserType")]
        [DisplayName("用户类型：0超级管理员 1站点管理员 2普通后台用户")]
        public int UserType
        {
            get;
            set;
        }


        /// <summary>
        /// 所属用户组，多个组以,间隔；
        /// </summary>	
        [Column("GroupIDs")]
        [DisplayName("所属用户组，多个组以,间隔；")]
        public string GroupIDs
        {
            get;
            set;
        }


        /// <summary>
        /// 登录次数
        /// </summary>	
        [Column("LoginNum")]
        [DisplayName("登录次数")]
        public int LoginNum
        {
            get;
            set;
        }
    }
}