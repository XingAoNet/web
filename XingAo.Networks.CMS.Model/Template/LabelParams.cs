using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：XA_CMS_Label_Params的实体
    /// </summary>	
    [Table("XA_CMS_Label_Params")]
    public class LabelParams
    {
        private int _id;
        /// <summary>
        /// 内部自增标识Id
        /// </summary>	
        [Key, Column("Id", Order = 1)]
        [DisplayName("编号")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _LableId;
        /// <summary>
        /// {标签表}
        /// </summary>	
        [Column("LableId")]
        public string LableId
        {
            get { return _LableId; }
            set { _LableId = value; }
        }

        private string _paramname;
        /// <summary>
        /// ParamName
        /// </summary>	
        [Column("ParamName")]
        public string ParamName
        {
            get { return _paramname; }
            set { _paramname = value; }
        }

        private string _defaultvalue;
        /// <summary>
        /// DefaultValue
        /// </summary>	
        [Column("DefaultValue")]
        public string DefaultValue
        {
            get { return _defaultvalue; }
            set { _defaultvalue = value; }
        }

        private string _paramdescription;
        /// <summary>
        /// ParamDescription
        /// </summary>	
        [Column("ParamDescription")]
        public string ParamDescription
        {
            get { return _paramdescription; }
            set { _paramdescription = value; }
        }
        public virtual Labels Label { get; set; }
    }
}
