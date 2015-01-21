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
    [Table("XA_CMS_Written")]
    public class Written
    {
        private int _id;
        /// <summary>
        /// 内部自增标识Id
        /// </summary>	
        [Key, Column("Id", Order = 1)]
        [DisplayName("编号")]
        public int Id
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

        private string _tel;
        /// <summary>
        /// 电话
        /// </summary>	
        [Column("Tel")]
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        private string _email;
        /// <summary>
        /// 邮件
        /// </summary>	
        [Column("Email")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _address;
        /// <summary>
        /// 地址
        /// </summary>	
        [Column("address")]
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _tcontent;
        /// <summary>
        /// 提交内容
        /// </summary>	
        [Column("TContent")]
        public string TContent
        {
            get { return _tcontent; }
            set { _tcontent = value; }
        }

        private string _title;
        /// <summary>
        /// 提交标题
        /// </summary>	
        [Column("Title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _rcontent;
        /// <summary>
        /// 回复内容
        /// </summary>	
        [Column("RContent")]
        public string RContent
        {
            get { return _rcontent; }
            set { _rcontent = value; }
        }

        private DateTime _idatatime;
        /// <summary>
        /// 提交时间
        /// </summary>	
        [Column("IDataTime")]
        public DateTime IDataTime
        {
            get { return _idatatime; }
            set { _idatatime = value; }
        }

        private DateTime _rdatatime;
        /// <summary>
        /// 回复时间
        /// </summary>	
        [Column("RDataTime")]
        public DateTime RDataTime
        {
            get { return _rdatatime; }
            set { _rdatatime = value; }
        }  
    }

    //[Export("WrittenMapping")]
    //public class WrittenMapping : MappingBase<Written>
    //{
    //    public WrittenMapping()
    //    {
    //        this.ToTable("XA_CMS_Written");

    //    }
    //}
}
