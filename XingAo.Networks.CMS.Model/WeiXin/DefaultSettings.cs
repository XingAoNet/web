/*=================================
//  模块：XA_DefaultSettings实体
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
    ///表名：默认设置的实体
    /// </summary>	
    [Table("XA_WeiXin_DefaultSettings")]
    public class DefaultSettings : IModel
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
    }
}

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("DefaultSettingsMapping")]
    public class DefaultSettingsMapping : MappingBase<Model.DefaultSettings>
    {
        public DefaultSettingsMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_DefaultSettings");
        }
    }
}