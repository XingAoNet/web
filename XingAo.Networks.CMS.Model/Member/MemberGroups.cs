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
    [Table("XA_Members_Groups")]
    public class MemberGroups
    {
        private int _id;
        /// <summary>
        /// 内部自增标识用户权限
        /// </summary>	
        [Column("Id", Order = 1)]
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
        [Column("OrderNum", Order = 1)]
        public int OrderNum
        {
            get { return _OrderNum; }
            set { _OrderNum = value; }
        }
        private string _groupid;
        /// <summary>
        /// 所属会员组编号
        /// </summary>	
        [Key, Column("GroupId")]
        public string GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

        private string _groupname;
        /// <summary>
        /// 组名
        /// </summary>	
        [Column("GroupName")]
        public string GroupName
        {
            get { return _groupname; }
            set { _groupname = value; }
        }

        private string _groupdescribe;
        /// <summary>
        /// 组描述
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

        public virtual ICollection<Model.Members> Members { get; set; }
    }
}
