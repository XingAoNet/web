/*=================================
//  模块：XA_BWPerson实体
//  创建者：zheng
//  创建时间：2013-12-21
=================================*/
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：转盘客户信息表的实体
    /// </summary>	
    [Table("XA_WeiXin_BWPerson")]
    public class BWPerson : IModel
    {

        private int _id;
        /// <summary>
        /// 客户表Id
        /// </summary>	
        [Column("ID")]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _wguid;
        /// <summary>
        /// 微信Guid
        /// </summary>	
        [Column("WGuid")]
        public string WGuid
        {
            get { return _wguid; }
            set { _wguid = value; }
        }

        private string _bguid;
        /// <summary>
        /// 转盘活动Guid
        /// </summary>	
        [Column("BGuid")]
        public string BGuid
        {
            get { return _bguid; }
            set { _bguid = value; }
        }

        private string _openid;
        /// <summary>
        /// 客户OpenId
        /// </summary>	
        [Column("OPenId")]
        public string OPenId
        {
            get { return _openid; }
            set { _openid = value; }
        }

        private string _name;
        /// <summary>
        /// 客户姓名
        /// </summary>	
        [Column("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _mobile;
        /// <summary>
        /// 客户手机
        /// </summary>	
        [Column("Mobile")]
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private string _address;
        /// <summary>
        /// 家庭住址
        /// </summary>	
        [Column("Address")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _e_mail;
        /// <summary>
        /// 邮箱
        /// </summary>	
        [Column("E_Mail")]
        public string E_Mail
        {
            get { return _e_mail; }
            set { _e_mail = value; }
        }

        private string _othercount;
        /// <summary>
        /// 其他人员信息
        /// </summary>	
        [Column("OtherCount")]
        public string OtherCount
        {
            get { return _othercount; }
            set { _othercount = value; }
        }
    }
}


namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("BWPersonMapping")]
    public class BWPersonMapping : MappingBase<BWPerson>
    {
        public BWPersonMapping()
        {
            this.ToTable("XA_WeiXin_BWPerson");
        }
    }
}

