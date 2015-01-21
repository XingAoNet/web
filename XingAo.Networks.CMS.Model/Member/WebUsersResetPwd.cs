/*=================================
//  模块：XA_CMS_WebUsersResetPwd实体
//  创建者：Lu
//  创建时间：2014-5-12
//  描述：用户密码重置申请表(只保留30分钟的数据)
//  生成模板来源：Networks.CMS.Model_V1.3.cmt
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
    ///表名：用户密码重置申请表(只保留30分钟的数据)的实体
    /// </summary>	
    [Table("XA_Member_ResetPwd")]//数据库真实表名
    public partial class WebUsersResetPwd
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
        /// 申请的唯一标志，程序将根据此值来决定对应的用户是否可以直接打开页面就修改密码
        /// </summary>	
        [Column("Code")] 
        [DisplayName("申请的唯一标志，程序将根据此值来决定对应的用户是否可以直接打开页面就修改密码")]
        public string Code
        {
            get;
            set;
        }
        /// <summary>
        /// 用户id
        /// </summary>	
        [Column("Uid")] 
        [DisplayName("用户id")]
        public int Uid
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间（30分钟后数据将被清除）
        /// </summary>	
        [Column("Addtime")] 
        [DisplayName("创建时间（30分钟后数据将被清除）")]
        public DateTime Addtime
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
    [Export("WebUsersResetPwdMapping")]
    public partial class WebUsersResetPwdMapping : MappingBase<Model.WebUsersResetPwd>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public WebUsersResetPwdMapping()
        {
            //实体映射表名
            this.ToTable("XA_Member_ResetPwd");
            //表间关系映射

        }
    }
}