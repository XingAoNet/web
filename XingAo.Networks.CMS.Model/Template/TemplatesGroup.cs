using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：Members_Groups的实体
    /// </summary>	
    [Table("XA_CMS_TemplatesGroup")]
    public class TemplatesGroup
    {
        private int _id;
        /// <summary>
        /// 内部自增标识用户权限
        /// </summary>	
        [Key, Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _OrderNum;
        /// <summary>
        /// 排序号
        /// </summary>	
        [Column("OrderNum")]
        public int OrderNum
        {
            get { return _OrderNum; }
            set { _OrderNum = value; }
        }

        private string _groupname;
        /// <summary>
        ///模板分组名
        /// </summary>	
        [Column("GroupName")]
        public string GroupName
        {
            get { return _groupname; }
            set { _groupname = value; }
        }

        private string _groupdescribe;
        /// <summary>
        /// 模板分组描述
        /// </summary>	
        [Column("GroupDescribe")]
        public string GroupDescribe
        {
            get
            {
                return _groupdescribe;
            }
            set
            {
                _groupdescribe = value;
            }
        }
    }
}
