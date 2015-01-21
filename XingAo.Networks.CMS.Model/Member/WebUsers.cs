/*=================================
//  模块：XA_CMS_WebUsers实体
//  创建者：Lu
//  创建时间：2014-4-22
//  描述：：网站前台用户
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
    ///表名：网站前台用户的实体
    /// </summary>	
    [Table("XA_Member_WebUsers")]//数据库真实表名
    public partial class WebUsers
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
        /// 性别
        /// </summary>	
        [Column("Sex")]
        [DisplayName("性别")]
        public int Sex
        {
            get;
            set;
        }
        /// <summary>
        /// QQ号
        /// </summary>	
        [Column("QQ")]
        [DisplayName("QQ号")]
        public string QQ
        {
            get;
            set;
        }
        /// <summary>
        /// 现有积分点数
        /// </summary>	
        [Column("Points")] 
        [DisplayName("现有积分点数")]
        public long Points
        {
            get;
            set;
        }
        /// <summary>
        /// 会员级别
        /// </summary>	
        [Column("VipLevel")] 
        [DisplayName("会员级别")]
        public int VipLevel
        {
            get;
            set;
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>	
        [Column("Email")] 
        [DisplayName("电子邮箱")]
        public string Email
        {
            get;
            set;
        }
        /// <summary>
        /// 手机号码
        /// </summary>	
        [Column("Mobile")] 
        [DisplayName("手机号码")]
        public string Mobile
        {
            get;
            set;
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        [Column("RegisterTime")]
        [DisplayName("注册时间")]
        public DateTime RegisterTime
        {
            get;
            set;
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>	
        [Column("LastLoginTime")]
        [DisplayName("最后登录时间")]
        public DateTime LastLoginTime
        {
            get;
            set;
        }
        /// <summary>
        /// 是否可用，0--禁用 1--可用
        /// </summary>	
        [Column("CanUse")] 
        [DisplayName("是否可用，0--禁用 1--可用")]
        public int CanUse
        {
            get;
            set;
        }
        /// <summary>
        /// 审核状态：0--未审核 1--审核通过
        /// </summary>	
        [Column("Audit")] 
        [DisplayName("审核状态：0--未审核 1--审核通过")]
        public int Audit
        {
            get;
            set;
        }
        /// <summary>
        /// 地区设置:省
        /// </summary>	
        [Column("Province")]
        [DisplayName("地区设置:省")]
        public string Province
        {
            get;
            set;
        }
        /// <summary>
        /// 地区设置:市
        /// </summary>	
        [Column("City")]
        [DisplayName("地区设置:市")]
        public string City
        {
            get;
            set;
        }
        /// <summary>
        /// 地区设置:区
        /// </summary>	
        [Column("Area")]
        [DisplayName("地区设置:区")]
        public string Area
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
    [Export("WebUsersMapping")]
    public partial class WebUsersMapping : MappingBase<Model.WebUsers>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public WebUsersMapping()
        {
            //实体映射表名
            this.ToTable("XA_Member_WebUsers");
            //表间关系映射

        }
    }
}