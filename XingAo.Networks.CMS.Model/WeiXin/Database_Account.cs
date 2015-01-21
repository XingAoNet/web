using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：微信账户表
    /// </summary>	
    [Table("XA_WeiXin_Account")]
    public class WeiXin_Account
    {
        private int _id;
        /// <summary>
        /// 内部自增标识微信账户表
        /// </summary>	
        [Key, Column("Id", Order = 1)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private int _IsUse;
        /// <summary>
        /// 被使用
        /// </summary>	
        [Column("IsUse")]
        public int IsUse
        {
            get { return _IsUse; }
            set { _IsUse = value; }
        }
        private string _accountname;
        /// <summary>
        /// 微信账号
        /// </summary>	
        [Column("AccountName")]
        public string AccountName
        {
            get { return _accountname; }
            set { _accountname = value; }
        }

        private string _accountpwd;
        /// <summary>
        /// 微信密码
        /// </summary>	
        [Column("AccountPwd")]
        public string AccountPwd
        {
            get { return _accountpwd; }
            set { _accountpwd = value; }
        }

        private string _token;
        /// <summary>
        /// 唯一值
        /// </summary>	
        [Column("Token")]
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        private string _MenuJson;
        /// <summary>
        /// 自定义菜单
        /// </summary>	
        [Column("MenuJson")]
        public string MenuJson
        {
            get { return _MenuJson; }
            set { _MenuJson = value; }
        }

        private string _appid;
        /// <summary>
        /// 应用标识
        /// </summary>	
        [Column("AppId")]
        public string AppId
        {
            get { return _appid; }
            set { _appid = value; }
        }

        private string _appsecret;
        /// <summary>
        /// AppSecret
        /// </summary>	
        [Column("AppSecret")]
        public string AppSecret
        {
            get { return _appsecret; }
            set { _appsecret = value; }
        }
        private string _wachatname;
        /// <summary>
        /// 微信用户名
        /// </summary>	
        [Column("WaChatName")]
        public string WaChatName
        {
            get { return _wachatname; }
            set { _wachatname = value; }
        }

        private string _sourceid;
        /// <summary>
        /// 原始公众号ID
        /// </summary>	
        [Column("SourceId")]
        public string SourceId
        {
            get { return _sourceid; }
            set { _sourceid = value; }
        }

        private string _wachatpwd;
        /// <summary>
        /// 微信密码
        /// </summary>	
        [Column("WaChatPwd")]
        public string WaChatPwd
        {
            get { return _wachatpwd; }
            set { _wachatpwd = value; }
        }

        private string _wachatnumber;
        /// <summary>
        /// 微信号
        /// </summary>	
        [Column("WaChatNumber")]
        public string WaChatNumber
        {
            get { return _wachatnumber; }
            set { _wachatnumber = value; }
        }

        private string _wachatheader;
        /// <summary>
        /// 头像
        /// </summary>	
        [Column("WaChatHeader")]
        public string WaChatHeader
        {
            get { return _wachatheader; }
            set { _wachatheader = value; }
        }

        private string _qrcode;
        /// <summary>
        /// 二维码地址
        /// </summary>	
        [Column("QRCode")]
        public string QRCode
        {
            get { return _qrcode; }
            set { _qrcode = value; }
        }

        private string _province;
        /// <summary>
        /// 省份
        /// </summary>	
        [Column("Province")]
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        private string _city;
        /// <summary>
        /// 市
        /// </summary>	
        [Column("City")]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _area;
        /// <summary>
        /// 区
        /// </summary>	
        [Column("Area")]
        public string Area
        {
            get { return _area; }
            set { _area = value; }
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

        private string _e_mail;
        /// <summary>
        /// 邮件
        /// </summary>	
        [Column("E_mail")]
        public string E_mail
        {
            get { return _e_mail; }
            set { _e_mail = value; }
        }

        private string _fennumber;
        /// <summary>
        /// 粉数
        /// </summary>	
        [Column("FenNumber")]
        public string FenNumber
        {
            get { return _fennumber; }
            set { _fennumber = value; }
        }

        private int _usertype;
        /// <summary>
        /// 微信类型
        /// </summary>	
        [Column("UserType")]
        public int UserType
        {
            get { return _usertype; }
            set { _usertype = value; }
        }

        private int _isdel;
        /// <summary>
        /// 是否删除
        /// </summary>	
        [Column("IsDel")]
        public int IsDel
        {
            get { return _isdel; }
            set { _isdel = value; }
        }

        private int? _AccountType;
        /// <summary>
        /// 账号类型
        /// </summary>	
        [Column("AccountType")]
        public int? AccountType
        {
            get { return _AccountType; }
            set { _AccountType = value; }
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
