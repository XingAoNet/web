using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：XA_OrganizationElect的实体
    /// </summary>	
    [Table("XA_OrganizationElect")]
    public class OrganizationElect
    {
        private int _id;
        /// <summary>
        /// 内部自增标识组织选举表
        /// </summary>	
        [Key, Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

        private string _electname;
        /// <summary>
        /// ElectName
        /// </summary>	
        [Column("ElectName")]
        public string ElectName
        {
            get { return _electname; }
            set { _electname = value; }
        }

        private DateTime _electdate;
        /// <summary>
        /// ElectDate
        /// </summary>	
        [Column("ElectDate")]
        public DateTime ElectDate
        {
            get { return _electdate; }
            set { _electdate = value; }
        }

        private string _Electhost;
        /// <summary>
        /// 会议主持
        /// </summary>	
        [Column("Electhost")]
        public string Electhost
        {
            get { return _Electhost; }
            set { _Electhost = value; }
        }

        private string _electdescribe;
        /// <summary>
        /// 描述
        /// </summary>	
        [Column("ElectDescribe")]
        public string ElectDescribe
        {
            get { return _electdescribe; }
            set { _electdescribe = value; }
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
