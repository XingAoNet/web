/*=================================
//  模块：XA_CMS_DataShare_Users实体
//  创建者：Lu
//  创建时间：2013-10-9
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
    ///表名：开放数据调用用户表  的实体
    /// </summary>	
    [Table("XA_CMS_DataShare_Users")]
    public class DataShare_Users
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
        /// 调用数据共享的用户名
        /// </summary>	
        [Column("UserName")]
        [DisplayName("调用数据共享的用户名")]
        public string UserName
        {
            get;
            set;
        }


        /// <summary>
        /// 公钥
        /// </summary>	
        [Column("Keys")]
        [DisplayName("公钥")]
        public string Keys
        {
            get;
            set;
        }


        /// <summary>
        /// 服务端私钥
        /// </summary>	
        [Column("PrivateKey")]
        [DisplayName("服务端私钥")]
        public string PrivateKey
        {
            get;
            set;
        }


        /// <summary>
        /// 允许调用的函数
        /// </summary>	
        [Column("AllowCall")]
        [DisplayName("允许调用的函数")]
        public string AllowCall
        {
            get;
            set;
        }
        
    }
}