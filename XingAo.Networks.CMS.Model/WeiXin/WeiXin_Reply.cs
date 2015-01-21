using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：XA_WeiXin_Reply的实体
    /// </summary>	
    [Table("XA_WeiXin_Reply")]
    public class WeiXin_Reply
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

        private string _title;
        /// <summary>
        /// 回复标题
        /// </summary>	
        [Column("Title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _replykey;
        /// <summary>
        /// 回复键值
        /// </summary>	
        [Column("ReplyKey")]
        public string ReplyKey
        {
            get { return _replykey; }
            set { _replykey = value; }
        }

        private string _picurl;
        /// <summary>
        /// 图片路径
        /// </summary>	
        [Column("PicUrl")]
        public string PicUrl
        {
            get { return _picurl; }
            set { _picurl = value; }
        }

        private string _url;
        /// <summary>
        /// 链接外部路径
        /// </summary>	
        [Column("Url")]
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _description;
        /// <summary>
        /// 描述
        /// </summary>	
        [Column("Description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _replycontent;
        /// <summary>
        /// 自动回复内容
        /// </summary>	
        [Column("ReplyContent")]
        public string ReplyContent
        {
            get { return _replycontent; }
            set { _replycontent = value; }
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
