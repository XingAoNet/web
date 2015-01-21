/*=================================
//  模块：XA_CMS_DataShare_AccessToken实体
//  创建者：Lu
//  创建时间：2013-11-16
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
    ///表名：授权令牌表（只保留15分钟的数据）  的实体
    /// </summary>	
    [Table("XA_CMS_DataShare_AccessToken")]
    public class DataShare_AccessToken
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
        /// XA_CMS_DataShare_Users表的id
        /// </summary>	
        [Column("UserID")]
        [DisplayName("XA_CMS_DataShare_Users表的id")]
        public int UserID
        {
            get;
            set;
        }


        /// <summary>
        /// 开始时间
        /// </summary>	
        [Column("StartTime")]
        [DisplayName("开始时间")]
        public DateTime StartTime
        {
            get;
            set;
        }


        /// <summary>
        /// 有效期截止时间
        /// </summary>	
        [Column("EndTime")]
        [DisplayName("有效期截止时间")]
        public DateTime EndTime
        {
            get;
            set;
        }


        /// <summary>
        /// 授权令牌
        /// </summary>	
        [Column("AccessToken")]
        [DisplayName("授权令牌")]
        public string AccessToken
        {
            get;
            set;
        }


        /// <summary>
        /// 请求刷新AccessToken的令牌
        /// </summary>	
        [Column("RefreshToken")]
        [DisplayName("请求刷新AccessToken的令牌")]
        public string RefreshToken
        {
            get;
            set;
        }       
    }
}