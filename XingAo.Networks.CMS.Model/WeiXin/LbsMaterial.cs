/*=================================
//  模块：XA_LbsMaterial实体
//  创建者：zheng
//  创建时间：2013-11-28
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
    ///表名：Lbs回复的实体
    /// </summary>	
    [Table("XA_WeiXin_MaterialLbs")]
    public class LbsMaterial : IModel
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
        
        private string _lbsguid;
        /// <summary>
        /// LBSGuid
        /// </summary>	
        [Column("LBSGuid")]
        public string LBSGuid
        {
            get { return _lbsguid; }
            set { _lbsguid = value; }
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

        private string _pictureadrress;
        /// <summary>
        /// 封面图片
        /// </summary>	
        [Column("PictureAdrress")]
        public string PictureAdrress
        {
            get { return _pictureadrress; }
            set { _pictureadrress = value; }
        }

        private string _telphone;
        /// <summary>
        /// 电话
        /// </summary>	
        [Column("TelPhone")]
        public string TelPhone
        {
            get { return _telphone; }
            set { _telphone = value; }
        }

        private string _abstract;
        /// <summary>
        /// 简介
        /// </summary>	
        [Column("Abstract")]
        public string Abstract
        {
            get { return _abstract; }
            set { _abstract = value; }
        }

        private double _latitude;
        /// <summary>
        /// 维度Y
        /// </summary>	
        [Column("Latitude")]
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        private double _longitude;
        /// <summary>
        /// 经度X
        /// </summary>	
        [Column("Longitude")]
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
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
        /// 详细页介绍
        /// </summary>	
        [Column("DetailedContent")]
        public string DetailedContent
        {
            get { return _detailedcontent; }
            set { _detailedcontent = value; }
        }

        private string _url;
        /// <summary>
        /// 链接
        /// </summary>	
        [Column("URL")]
        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }
    }
}

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("LbsMaterialMapping")]
    public class LbsMaterialMapping : MappingBase<Model.LbsMaterial>
    {
        public LbsMaterialMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_MaterialLbs");
        }
    }
}

