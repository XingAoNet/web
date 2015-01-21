/*=================================
//  模块：XA_CMS_DataShare_ParameterConfig实体
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
    ///表名：开放数据参数配置表  的实体
    /// </summary>	
    [Table("XA_CMS_DataShare_ParameterConfig")]
    public class DataShare_ParameterConfig
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
        /// DataShare表内的ID
        /// </summary>	
        [Column("DataShareID")]
        [DisplayName("DataShare表内的ID")]
        public int DataShareID
        {
            get;
            set;
        }


        /// <summary>
        /// 参数名称
        /// </summary>	
        [Column("ParameterName")]
        [DisplayName("参数名称")]
        public string ParameterName
        {
            get;
            set;
        }


        /// <summary>
        /// 参数所对应的字段
        /// </summary>	
        [Column("FieldName")]
        [DisplayName("参数所对应的字段")]
        public string FieldName
        {
            get;
            set;
        }


        /// <summary>
        /// 1--值为空时仍然要加上查询条件，0--值为空时忽略此条件
        /// </summary>	
        [Column("AllowEmpty")]
        [DisplayName("1--值为空时仍然要加上查询条件，0--值为空时忽略此条件")]
        public int AllowEmpty
        {
            get;
            set;
        }


        /// <summary>
        /// 操作符，如in({0}) ={0} like '%{0}%' ＞{0} ＜{0}等等
        /// </summary>	
        [Column("Operators")]
        [DisplayName("操作符，如in({0}) ={0} like '%{0}%' >{0} <{0}等等")]
        public string Operators
        {
            get;
            set;
        }
        /// <summary>
        /// post过来值的类型：int datetime string等
        /// </summary>	
        [Column("DataType")]
        [DisplayName("post过来值的类型：int datetime string等")]
        public string DataType
        {
            get;
            set;
        }
        /// <summary>
        /// 到DataShare表中找与此DataShareID关联的数据（此字段为多表关联用，单表操作时忽视此字段）
        /// </summary>        
        public virtual DataShare DataShareModel { get; set; }
    }
}