using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：XA_Organization的实体
    /// </summary>	
    [Table("XA_Organization")]
    public class Organization
    {
        private int _id;
        /// <summary>
        /// 内部自增标识组织架构表
        /// </summary>	
        [Key, Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _orgid;
        /// <summary>
        /// 组织编号
        /// </summary>	
        [Column("OrgCode")]
        public string OrgCode
        {
            get { return _orgid; }
            set { _orgid = value; }
        }


        private string _electid;
        /// <summary>
        /// 选举会议ID
        /// </summary>	
        [Column("ElectId")]
        public string ElectId
        {
            get { return _electid; }
            set { _electid = value; }
        }

        private string _orgname;
        /// <summary>
        /// 组织名
        /// </summary>	
        [Column("OrgName")]
        public string OrgName
        {
            get { return _orgname; }
            set { _orgname = value; }
        }


        private string _orgdescribe;
        /// <summary>
        /// OrgDescribe
        /// </summary>	
        [Column("OrgDescribe")]
        public string OrgDescribe
        {
            get { return _orgdescribe; }
            set { _orgdescribe = value; }
        }

        private DateTime _idatetime;
        /// <summary>
        /// 创建时间
        /// </summary>	
        [Column("IDateTime")]
        public DateTime IDateTime
        {
            get { return _idatetime; }
            set { _idatetime = value; }
        }

        private DateTime _edittime;
        /// <summary>
        /// 编辑时间
        /// </summary>	
        [Column("EditTime")]
        public DateTime EditTime
        {
            get { return _edittime; }
            set { _edittime = value; }
        }

        private string _editer;
        /// <summary>
        /// 编辑者
        /// </summary>	
        [Column("Editer")]
        public string Editer
        {
            get { return _editer; }
            set { _editer = value; }
        }

        private string _creater;
        /// <summary>
        /// 创建人
        /// </summary>	
        [Column("Creater")]
        public string Creater
        {
            get { return _creater; }
            set { _creater = value; }
        }      
    }
}
