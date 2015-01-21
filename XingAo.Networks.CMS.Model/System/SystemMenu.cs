using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    ///表名：XA_CMS_SystemMenu的实体
    /// </summary>	
    [Table("XA_CMS_SystemMenu")]
    public class SystemMenu
    {
        private int _id;
        /// <summary>
        /// 内部自增标识系统菜单
        /// </summary>	
        [Key,  Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("编号")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _menuid;
        /// <summary>
        /// MenuID
        /// </summary>	
        [Column("MenuID")]
        public string MenuID
        {
            get { return _menuid; }
            set { _menuid = value; }
        }

        private string _navname;
        /// <summary>
        /// 菜单名
        /// </summary>	
        [Column("NavName")]
        public string NavName
        {
            get { return _navname; }
            set { _navname = value; }
        }

        private string _url;
        /// <summary>
        /// 链接地址
        /// </summary>	
        [Column("Url")]
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _target;
        /// <summary>
        /// 打开对象navTab,diag
        /// </summary>	
        [Column("Target")]
        public string Target
        {
            get { return _target; }
            set { _target = value; }
        }

        private string _rel;
        /// <summary>
        /// 新窗口标识
        /// </summary>	
        [Column("Rel")]
        public string Rel
        {
            get { return _rel; }
            set { _rel = value; }
        }

        private int _ordernum;
        /// <summary>
        /// 菜单排序号
        /// </summary>	
        [Column("OrderNum")]
        public int OrderNum
        {
            get { return _ordernum; }
            set { _ordernum = value; }
        }


        private int? _PageType;
        /// <summary>
        /// 0为菜单1操作页2一般执行页
        /// </summary>	
        [Column("PageType")]
        public int? PageType
        {
            get { return _PageType; }
            set { _PageType = value; }
        }

        private int? _IsViewMenu;
        /// <summary>
        /// 是否显示在菜单
        /// </summary>	
        [Column("IsViewMenu")]
        public int? IsViewMenu
        {
            get { return _IsViewMenu; }
            set { _IsViewMenu = value; }
        }

        /// <summary>
        /// 操作项目
        /// </summary>	
        [Column("Operation")]
        public string Operation
        {
            get;
            set;
        }

        private string _parentmenuid;
        /// <summary>
        /// 上一级菜单ID
        /// </summary>	
        [Column("ParentMenuID")]
        public string ParentMenuID
        {
            get { return _parentmenuid; }
            set { _parentmenuid = value; }
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
        //public virtual SystemMenu Menu { get; set; }

        //public virtual ICollection<SystemMenu> ChildMenus { get; set; }
    }
}