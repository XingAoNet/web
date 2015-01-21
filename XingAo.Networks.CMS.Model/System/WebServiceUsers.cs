/*=================================
//  模块：XA_CMS_WebServiceUsers实体
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
    ///表名：允许调用服务的用户列表  的实体
    /// </summary>	
    [Table("XA_CMS_WebServiceUsers")]
    public class WebServiceUsers
    {       
        /// <summary>
        /// 内部自增标识{允许调用webservice的用户}
        /// </summary>	
        [Key, Column("ID", Order = 1)]
        [DisplayName("编号")]
        public int ID
        {
            get;
            set;
        }


        /// <summary>
        /// 帐号
        /// </summary>	
        [Column("AppKey")]
        [DisplayName("帐号")]
        public string AppKey
        {
            get;
            set;
        }


        /// <summary>
        /// 密钥(也就是ras加密中的公钥)
        /// </summary>	
        [Column("AppCode")]
        [DisplayName("密钥")]
        public string AppCode
        {
            get;
            set;
        }

        /// <summary>
        /// 服务端对应的私钥
        /// </summary>	
        [Column("ServerPrivateCode")]
        [DisplayName("服务端对应的私钥")]
        public string ServerPrivateCode
        {
            get;
            set;
        }
        /// <summary>
        /// 允许调用哪些服务
        /// </summary>	
        [Column("AuthorityStr")]
        [DisplayName("允许调用哪些服务")]
        public string AuthorityStr
        {
            get;
            set;
        }


        /// <summary>
        /// 是否为系统自用还是外部系统来调用的
        /// </summary>	
        [Column("IsSystem")]
        [DisplayName("是否为系统自用还是外部系统来调用的")]
        public int IsSystem
        {
            get;
            set;
        }


        /// <summary>
        /// 最后登录时间（可能会有一定误差，具体看缓冲时间有多长）
        /// </summary>	
        [Column("LastLoginTime")]
        [DisplayName("最后登录时间（可能会有一定误差，具体看缓冲时间有多长）")]
        public DateTime LastLoginTime
        {
            get;
            set;
        }


        /// <summary>
        /// 允许调用的ip或域名（多个以|间隔，域名带http）
        /// </summary>	
        [Column("AllowHostOrIp")]
        [DisplayName("允许调用的ip或域名（多个以|间隔，域名带http）")]
        public string AllowHostOrIp
        {
            get;
            set;
        }
    }
}