/*=================================
//  模块：XA_CustomMenu实体
//  创建者：zheng
//  创建时间：2013-11-27
=================================*/
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：自定义菜单的实体
    /// </summary>	
    [Table("XA_WeiXin_CustomMenu")]
    public class CustomMenu : IModel
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

        private int _selfid;
        /// <summary>
        /// 自身ID
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
        /// 菜单名
        /// </summary>	
        [Column("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _keys;
        /// <summary>
        /// 关键字或地址
        /// </summary>	
        [Column("Keys")]
        public string Keys
        {
            get { return _keys; }
            set { _keys = value; }
        }



        private string _KeysText;
        /// <summary>
        /// 关键字或地址
        /// </summary>	
        [Column("KeysText")]
        public string KeysText
        {
            get { return _KeysText; }
            set { _KeysText = value; }
        }

        private string _MenuType;
        /// <summary>
        /// 菜单类型
        /// </summary>	
        [Column("MenuType")]
        public string MenuType
        {
            get { return _MenuType; }
            set { _MenuType = value; }
        }

        private string _Source;
        /// <summary>
        /// 按钮数据源
        /// </summary>	
        [Column("Source")]
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }


        private int _canuse;
        /// <summary>
        /// 是否启用
        /// </summary>	
        [Column("CanUse")]
        public int CanUse
        {
            get { return _canuse; }
            set { _canuse = value; }
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
    }
}

