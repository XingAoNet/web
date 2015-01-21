/*=================================
//  模块：XA_CMS_DataShare实体
//  创建者：Lu
//  创建时间：2013-10-7
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
    ///表名：开放数据表  的实体
    /// </summary>	
    [Table("XA_CMS_DataShare")]
    public class DataShare
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
        /// 调用方法名称
        /// </summary>	
        [Column("MethodName")]
        [DisplayName("调用方法名称")]
        public string MethodName
        {
            get;
            set;
        }


        /// <summary>
        /// 要查询的表名
        /// </summary>	
        [Column("Tables")]
        [DisplayName("要查询的表名")]
        public string Tables
        {
            get;
            set;
        }


        /// <summary>
        /// 要查询的字段集
        /// </summary>	
        [Column("Fields")]
        [DisplayName("要查询的字段集")]
        public string Fields
        {
            get;
            set;
        }

        /// <summary>
        /// 要查询的条件（空为不设置条件）【注意：不用加where】
        /// </summary>	
        [Column("WhereStr")]
        [DisplayName("要查询的条件")]
        public string WhereStr
        {
            get;
            set;
        }
        /// <summary>
        /// 排序（空为默认以id倒序）【注意：不用加order by】
        /// </summary>	
        [Column("OrderBy")]
        [DisplayName("排序")]
        public string OrderBy
        {
            get;
            set;
        }

        /// <summary>
        /// 1--列表方法，2--取单条数据方法，3--更新（包括插入与修改）方法，4--删除
        /// </summary>	
        [Column("MethodType")]
        [DisplayName("1--列表方法，2--取单条数据方法，3--更新（包括插入与修改）方法，4--删除")]
        public int MethodType
        {
            get;
            set;
        }
        /// <summary>
        /// 描述说明或备注
        /// </summary>	
        [Column("Descriptions")]
        [DisplayName("描述说明或备注")]
        public string Descriptions
        {
            get;
            set;
        }
        /// <summary>
        /// 到DataShare_ParameterConfig表中找与此id关联的数据（此字段为多表关联用，单表操作时忽视此字段）
        /// </summary>        
        public virtual ICollection<DataShare_ParameterConfig> ParameterConfig
        {
            get;
            set;
        }
    }
}