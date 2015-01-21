/*=================================
//  模块：XA_TextMaterial实体
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
    ///表名：文本回复的实体
    /// </summary>	
    [Table("XA_WeiXin_MaterialText")]
    public class TextMaterial : IModel
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

        private string _tguid;
        /// <summary>
        /// 文本回复Guid
        /// </summary>	
        [Column("TGuid")]
        public string TGuid
        {
            get { return _tguid; }
            set { _tguid = value; }
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

        private string _replycontent;
        /// <summary>
        /// 回复内容
        /// </summary>	
        [Column("ReplyContent")]
        public string ReplyContent
        {
            get { return _replycontent; }
            set { _replycontent = value; }
        }
    }
}

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("TextMaterialMapping")]
    public class TextMaterialMapping : MappingBase<Model.TextMaterial>
    {
        public TextMaterialMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_MaterialText");
        }
    }
}

