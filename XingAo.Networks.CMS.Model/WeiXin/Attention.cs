/*=================================
//  模块：XA_Attention实体
//  创建者：zheng
//  创建时间：2013-11-27
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
    ///表名：关注回复的实体
    /// </summary>	
    [Table("XA_WeiXin_Attention")]
    public class Attention : IModel
    {

        private int _id;
        /// <summary>
        /// 关注时回复ID
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

        private string _keys;
        /// <summary>
        /// 关键字
        /// </summary>	
        [Column("Keys")]
        public string Keys
        {
            get { return _keys; }
            set { _keys = value; }
        }

        private int _keytype;
        /// <summary>
        /// 匹配类型
        /// </summary>	
        [Column("KeyType")]
        public int KeyType
        {
            get { return _keytype; }
            set { _keytype = value; }
        }

        private string _title;
        /// <summary>
        /// 标题
        /// </summary>	
        [Column("Title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private int _orderid;
        /// <summary>
        /// 排序号
        /// </summary>	
        [Column("OrderID")]
        public int OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        private int _parentid;
        /// <summary>
        /// 所属类别
        /// </summary>	
        [Column("ParentID")]
        public int ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }

        private string _pictueradress;
        /// <summary>
        /// 封面
        /// </summary>	
        [Column("PictuerAdress")]
        public string PictuerAdress
        {
            get { return _pictueradress; }
            set { _pictueradress = value; }
        }

        private string _otherurl;
        /// <summary>
        /// 其他链接
        /// </summary>	
        [Column("OtherURL")]
        public string OtherURL
        {
            get { return _otherurl; }
            set { _otherurl = value; }
        }

        private int _isshow;
        /// <summary>
        /// 是否显示
        /// </summary>	
        [Column("IsShow")]
        public int IsShow
        {
            get { return _isshow; }
            set { _isshow = value; }
        }        

        private string _abstract;
        /// <summary>
        /// 描述
        /// </summary>	
        [Column("Abstract")]
        public string Abstract
        {
            get { return _abstract; }
            set { _abstract = value; }
        }

        private int _type;
        /// <summary>
        /// 是否是图文
        /// </summary>	
        [Column("Type")]
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _detailedcontent;
        /// <summary>
        /// 详细内容
        /// </summary>	
        [Column("DetailedContent")]
        public string DetailedContent
        {
            get { return _detailedcontent; }
            set { _detailedcontent = value; }
        }
    }
}

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("AttentionMapping")]
    public class AttentionMapping : MappingBase<Model.Attention>
    {
        public AttentionMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_Attention");
        }
    }
}
