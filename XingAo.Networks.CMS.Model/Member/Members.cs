using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：会员的实体
    /// </summary>	
    [Table("Members")]
    public class Members
    {
        private int _id;
        /// <summary>
        /// ID
        /// </summary>	
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _username;
        /// <summary>
        /// 会员名
        /// </summary>	
        [Column("UserName")]
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _mobile;
        /// <summary>
        /// 手机号码
        /// </summary>	
        [Column("mobile")]
        public string mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private string _weixinhao;
        /// <summary>
        /// 微信号
        /// </summary>	
        [Column("weixinhao")]
        public string weixinhao
        {
            get { return _weixinhao; }
            set { _weixinhao = value; }
        }

        private string _email;
        /// <summary>
        /// 邮箱地址
        /// </summary>	
        [Column("Email")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _tname;
        /// <summary>
        /// 真实姓名
        /// </summary>	
        [Column("TName")]
        public string TName
        {
            get { return _tname; }
            set { _tname = value; }
        }

        private string _groupid;
        /// <summary>
        /// 所属会员组
        /// </summary>	
        [Column("GroupId")]
        public string GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }  

    }
}
