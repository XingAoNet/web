/*=================================
//  模块：XA_CMS_CustomTableField实体
//  创建者：Lu
//  创建时间：2013-8-24
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
    ///表名：用户自定义表字段及生成表单相关参数配置表  的实体
    /// </summary>	
    [Table("XA_CMS_CustomTableField")]
    public class CustomTableField
    {
        /// <summary>
        /// 内部自增标识{用户自定义表对应字段}
        /// </summary>	
        [Key, Column("ID", Order = 1)]
        [DisplayName("编号")]
        public int ID
        {
            get;
            set;
        }


        /// <summary>
        /// CustomTable表中的ID(联级更新)
        /// </summary>	
        [Column("TID")]
        [DisplayName("CustomTable表中的ID(联级更新)")]
        public int TID
        {
            get;
            set;
        }


        /// <summary>
        /// 字段英文名
        /// </summary>	
        [Column("FieldName")]
        [DisplayName("字段英文名")]
        public string FieldName
        {
            get;
            set;
        }


        /// <summary>
        /// 字段中文名
        /// </summary>	
        [Column("ChineseName")]
        [DisplayName("字段中文名")]
        public string ChineseName
        {
            get;
            set;
        }


        /// <summary>
        /// 字段描述说明
        /// </summary>	
        [Column("Description")]
        [DisplayName("字段描述说明")]
        public string Description
        {
            get;
            set;
        }


        


        /// <summary>
        /// 字段数据类型【详细参照FieldTypeEnum枚举说明】
        /// </summary>	
        [Column("DataType")]
        [DisplayName("字段数据类型【详细参照FieldTypeEnum枚举说明】")]
        public string DataType
        {
            get;
            set;
        }


        /// <summary>
        /// 字段默认值
        /// </summary>	
        [Column("DefaultValue")]
        [DisplayName("字段默认值")]
        public string DefaultValue
        {
            get;
            set;
        }


        /// <summary>
        /// 是否主键？1是0否
        /// </summary>	
        [Column("IsPrimaryKey")]
        [DisplayName("是否主键？1是0否")]
        public int IsPrimaryKey
        {
            get;
            set;
        }


        /// <summary>
        /// 是否在后台编辑页面表单上显示此字段
        /// </summary>	
        [Column("ShowEditInForm")]
        [DisplayName("是否在后台编辑页面表单上显示此字段")]
        public int ShowEditInForm
        {
            get;
            set;
        }


        /// <summary>
        /// 在表单编辑界面上显示的顺序（越大越前）【只有ShowInForm=1时有效】
        /// </summary>	
        [Column("ShowFormEditIndex")]
        [DisplayName("在表单编辑界面上显示的顺序（越大越前）【只有ShowInForm=1时有效】")]
        public int ShowFormEditIndex
        {
            get;
            set;
        }


        /// <summary>
        /// 在后台编辑页面显示时的各种属性，包括名称、显示类型、验证类型等等，具体参数参照Model.EditFormControl
        /// </summary>	
        [Column("ShowFormEditParJson")]
        [DisplayName("在后台编辑页面显示时的各种属性，包括名称、显示类型、验证类型等等，具体参数参照Model.EditFormControl")]
        public string ShowFormEditParJson
        {
            get;
            set;
        }


        /// <summary>
        /// 是否在列表页显示此字段
        /// </summary>	
        [Column("ShowList")]
        [DisplayName("是否在列表页显示此字段")]
        public int ShowList
        {
            get;
            set;
        }


        /// <summary>
        /// 在列表中显示时的顺序（越大越靠前）
        /// </summary>	
        [Column("ShowListIndex")]
        [DisplayName("在列表中显示时的顺序（越大越靠前）")]
        public int ShowListIndex
        {
            get;
            set;
        }


        /// <summary>
        /// 在列表中显示时，各种属性json,具体参数参照Model.ListFormControl
        /// </summary>	
        [Column("ShowListParJson")]
        [DisplayName("在列表中显示时，各种属性json,具体参数参照Model.ListFormControl")]
        public string ShowListParJson
        {
            get;
            set;
        }

        /// <summary>
        /// 0--不在搜索项上显示 1--在普通搜索项上显示 2--在高级搜索项上显示 3--在普通与高级搜索项上同时显示
        /// </summary>	
        [Column("ShowInSearch")]
        [DisplayName("0--不在搜索项上显示 1--在普通搜索项上显示 2--在高级搜索项上显示 3--在普通与高级搜索项上同时显示")]
        public int ShowInSearch
        {
            get;
            set;
        }


        /// <summary>
        /// 在搜索项上的排序号，越大越靠前
        /// </summary>	
        [Column("ShowInSearchIndex")]
        [DisplayName("在搜索项上的排序号，越大越靠前")]
        public int ShowInSearchIndex
        {
            get;
            set;
        }


        /// <summary>
        /// 搜索项配置信息json，包括控件类型是以什么控件呈现等
        /// </summary>	
        [Column("ShowInSearchJson")]
        [DisplayName("搜索项配置信息json，包括控件类型是以什么控件呈现等")]
        public string ShowInSearchJson
        {
            get;
            set;
        }


        /// <summary>
        /// 是否为系统字段,1是0不是 系统字段不能被删除
        /// </summary>	
        [Column("IsSystemField")]
        [DisplayName("是否为系统字段,1是0不是 系统字段不能被删除")]
        public int IsSystemField
        {
            get;
            set;
        }  

        /// <summary>
        /// 字段所在表
        /// </summary>
        public virtual CustomTable CustTable { get; set; }
    }
}