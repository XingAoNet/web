using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：XA_OrganizationElect_Relation_Member的实体
    /// </summary>	
    [Table("XA_Organization_Relation_Member")]
    public class Organization_Relation_Member
    {
        private int _id;
        /// <summary>
        /// 内部自增标识Id
        /// </summary>	
        [Key, Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _OrgId;
        /// <summary>
        /// 组织成员
        /// </summary>	
        [Column("OrgId")]
        public string OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }

        private int _memberid;
        /// <summary>
        /// 会员ID
        /// </summary>	
        [Column("MemberId")]
        public int MemberId
        {
            get { return _memberid; }
            set { _memberid = value; }
        }

        private string _membername;
        /// <summary>
        /// 会员姓名
        /// </summary>	
        [Column("MemberName")]
        public string MemberName
        {
            get { return _membername; }
            set { _membername = value; }
        } 

    }
}
