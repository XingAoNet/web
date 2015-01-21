/*=================================
//  模块：XA_CMS_DataShare_Log实体
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
    ///表名：数据共享接口调用日志（只保留3天数据）  的实体
    /// </summary>	
    [Table("XA_CMS_DataShare_Log")]
    public class DataShare_Log
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
        /// 调用的方法名
        /// </summary>	
        [Column("CallMethodName")]
        [DisplayName("调用的方法名")]
        public string CallMethodName
        {
            get;
            set;
        }


        /// <summary>
        /// 调用时使用的用户名
        /// </summary>	
        [Column("UserName")]
        [DisplayName("调用时使用的用户名")]
        public string UserName
        {
            get;
            set;
        }


        /// <summary>
        /// 调用时使用的授权令牌
        /// </summary>	
        [Column("AccessToken")]
        [DisplayName("调用时使用的授权令牌")]
        public string AccessToken
        {
            get;
            set;
        }


        /// <summary>
        /// 请求来源
        /// </summary>	
        [Column("Source")]
        [DisplayName("请求来源")]
        public string Source
        {
            get;
            set;
        }


        /// <summary>
        /// 客户端提交的所有参数(包括post与get)
        /// </summary>	
        [Column("ClientSendPars")]
        [DisplayName("客户端提交的所有参数(包括post与get)")]
        public string ClientSendPars
        {
            get;
            set;
        }


        /// <summary>
        /// 请求时间
        /// </summary>	
        [Column("CallTime")]
        [DisplayName("请求时间")]
        public DateTime CallTime
        {
            get;
            set;
        }


        /// <summary>
        /// 错误信息（空为调用成功）
        /// </summary>	
        [Column("ErrMsg")]
        [DisplayName("错误信息（空为调用成功）")]
        public string ErrMsg
        {
            get;
            set;
        }
    }
}