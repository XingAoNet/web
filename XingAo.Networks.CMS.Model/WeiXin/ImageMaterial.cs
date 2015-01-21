/*=================================
//  模块：XA_ImageMaterial实体
//  创建者：zheng
//  创建时间：2013-11-26
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
    ///表名：图文回复的实体
    /// </summary>	
    [Table("XA_WeiXin_MaterialImage")]
    public class ImageMaterial : IModel
    {

        private int _id;
        /// <summary>
        /// ID
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

        private string _imguid;
        /// <summary>
        /// 图文回复Guid
        /// </summary>	
        [Column("IMGuid")]
        public string IMGuid
        {
            get { return _imguid; }
            set { _imguid = value; }
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

        private string _Thumbnail;
        /// <summary>
        /// 封面缩略图
        /// </summary>	
        [Column("Thumbnail")]
        public string Thumbnail
        {
            get { return _Thumbnail; }
            set { _Thumbnail = value; }
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

        private int _isdelete;
        /// <summary>
        /// 是否删除
        /// </summary>	
        [Column("IsDelete")]
        public int IsDelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
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


        private string _Url;
        /// <summary>
        /// 其他链接地址
        /// </summary>	
        [Column("Url")]
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
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

        private int _isshowtime;
        /// <summary>
        /// 是否显示时间
        /// </summary>	
        [Column("IsShowTime")]
        public int IsShowTime
        {
            get { return _isshowtime; }
            set { _isshowtime = value; }
        }

        private int _praise;
        /// <summary>
        /// 赞
        /// </summary>	
        [Column("Praise")]
        public int Praise
        {
            get { return _praise; }
            set { _praise = value; }
        }

        public virtual MaterialFamily MaterialFamily { get; set; }
    }
}



namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("ImageMaterialMapping")]
    public class ImageMaterialMapping : MappingBase<Model.ImageMaterial>
    {
        public ImageMaterialMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_MaterialImage");
            this.HasRequired(m => m.MaterialFamily).WithMany(m => m.ImageMaterials).HasForeignKey(t => t.ParentID);
        }
    }
}