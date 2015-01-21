using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///采集参数表
    /// </summary>	
    [Table("XA_CMS_Collect_Pattern")]
    public class Collect_Pattern
    {
        private int _id;
        /// <summary>
        /// 内部自增标识采集详细参数设置表
        /// </summary>	
        [Key, Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _collectid;
        /// <summary>
        /// 关联采集项
        /// </summary>	
        [Column("CollectId")]
        public string CollectId
        {
            get { return _collectid; }
            set { _collectid = value; }
        }

        private string _paramname;
        /// <summary>
        /// 参数名
        /// </summary>	
        [Column("ParamName")]
        public string ParamName
        {
            get { return _paramname; }
            set { _paramname = value; }
        }

        private string _expression;
        /// <summary>
        /// 表达式
        /// </summary>	
        [Column("Expression")]
        public string Expression
        {
            get { return _expression; }
            set { _expression = value; }
        }

        private string _InsertField;
        /// <summary>
        /// 采集到对应字段
        /// </summary>	
        [Column("InsertField")]
        public string InsertField
        {
            get { return _InsertField; }
            set { _InsertField = value; }
        }

        private string _DefaultValue;
        /// <summary>
        /// 默认值
        /// </summary>	
        [Column("DefaultValue")]
        public string DefaultValue
        {
            get { return _DefaultValue; }
            set { _DefaultValue = value; }
        } 

        //[Required]
        public virtual Collect collect { get; set; }
    }
}
