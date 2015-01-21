/*=================================
//  模块：XA_MaterialFamily实体
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
    ///表名：素材类别表的实体
    /// </summary>	
    [Table("XA_WeiXin_MaterialFamily")]
    public class MaterialFamily : IModel
    {

        private int _id;
        /// <summary>
        /// ID
        /// </summary>	
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _mfguid;
        /// <summary>
        /// 素材类别Guid
        /// </summary>	
        [Column("MFGuid")]
        public string MFGuid
        {
            get { return _mfguid; }
            set { _mfguid = value; }
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

        private int _selfid;
        /// <summary>
        /// 自身Id
        /// </summary>	
        [Column("SelfID")]
        public int SelfID
        {
            get { return _selfid; }
            set { _selfid = value; }
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
        /// 父窗体ID
        /// </summary>	
        [Column("ParentID")]
        public int ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }

        private string _name;
        /// <summary>
        /// 类别名
        /// </summary>	
        [Column("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _describe;
        /// <summary>
        /// 描述
        /// </summary>	
        [Column("Describe")]
        public string Describe
        {
            get { return _describe; }
            set { _describe = value; }
        }

        /// <summary>
        /// 深度
        /// </summary>
        [DisplayName("深度")]
        public int Deep
        {
            get;
            set;
        }


        public virtual ICollection<ImageMaterial> ImageMaterials { get; set; }
    }
}

namespace  XingAo.Networks.CMS.Model.Mappings
{
    [Export("MaterialFamilyMapping")]
    public class MaterialFamilyMapping : MappingBase<Model.MaterialFamily>
    {
        public MaterialFamilyMapping()
        {
            //映射表名
            this.ToTable("XA_WeiXin_MaterialFamily");
            this.Ignore(a => a.Deep);
          
        }
    }
}