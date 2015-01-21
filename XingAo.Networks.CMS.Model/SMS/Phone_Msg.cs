using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：短信发送记录
    /// </summary>	
    [Table("XA_Phone_Msg")]
    public class Phone_Msg
    {
        private int _id;
        /// <summary>
        /// 内部自增标识Id
        /// </summary>	
        [Key, Column("Id", Order = 1)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _msginfo;
        /// <summary>
        /// 发送短信消息
        /// </summary>	
        [Column("MsgInfo")]
        public string MsgInfo
        {
            get { return _msginfo; }
            set { _msginfo = value; }
        }

        private string _username;
        /// <summary>
        /// 接受者姓名
        /// </summary>	
        [Column("UserName")]
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _mobiles;
        /// <summary>
        /// 接受者手机号码
        /// </summary>	
        [Column("Mobiles")]
        public string Mobiles
        {
            get { return _mobiles; }
            set { _mobiles = value; }
        }

        private DateTime _senddatetime;
        /// <summary>
        /// 发送时间
        /// </summary>	
        [Column("SendDateTime")]
        public DateTime SendDateTime
        {
            get { return _senddatetime; }
            set { _senddatetime = value; }
        }

        private string _sendresultmsg;
        /// <summary>
        /// 发送后返回结果
        /// </summary>	
        [Column("SendResultMsg")]
        public string SendResultMsg
        {
            get { return _sendresultmsg; }
            set { _sendresultmsg = value; }
        }

        private string _sendname;
        /// <summary>
        /// 发送人
        /// </summary>	
        [Column("SendName")]
        public string SendName
        {
            get { return _sendname; }
            set { _sendname = value; }
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
