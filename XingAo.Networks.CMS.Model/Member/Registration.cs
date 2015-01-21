/*=================================
//  模块：XA_Registration实体
//  创建者：zheng
//  创建时间：2013-11-29
=================================*/
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using XingAo.Core.Data;
using System.ComponentModel.Composition;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：报名表的实体
    /// </summary>	
    [Table("XA_WeiXin_Registration")]
    public class Registration : IModel
    {

        private int _id;
        /// <summary>
        /// 报名表ID
        /// </summary>	
        [Column("ID")]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        /// <summary>
        /// 姓名
        /// </summary>	
        [Column("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _aguid;
        /// <summary>
        /// 报名活动guid
        /// </summary>	
        [Column("AGuid")]
        public string AGuid
        {
            get { return _aguid; }
            set { _aguid = value; }
        }

        private string _telphone;
        /// <summary>
        /// 手机
        /// </summary>	
        [Column("Telphone")]
        public string Telphone
        {
            get { return _telphone; }
            set { _telphone = value; }
        }

        private string _address;
        /// <summary>
        /// 地址
        /// </summary>	
        [Column("Address")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _qq;
        /// <summary>
        /// QQ
        /// </summary>	
        [Column("QQ")]
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }

        private string _openid;
        /// <summary>
        /// 手机
        /// </summary>	
        [Column("OpenId")]
        public string OpenId
        {
            get { return _openid; }
            set { _openid = value; }
        }

        private string _e_mail;
        /// <summary>
        /// E_Mail
        /// </summary>	
        [Column("E_Mail")]
        public string E_Mail
        {
            get { return _e_mail; }
            set { _e_mail = value; }
        }
    }
}


namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("RegistrationMapping")]
    public class RegistrationMapping : MappingBase<Model.Registration>
    {
        public RegistrationMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_Registration");
        }
    }
}