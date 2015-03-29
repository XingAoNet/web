using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Software.UserCenter.Model
{
    /// <summary>
    /// 用户菜单
    /// </summary>
    [Table("XingAo_UserCenter_Menu")]
    public partial class Menu
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        [Column("UId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("菜单编号")]
        public int Id { get; set; }

        /// <summary>
        /// 用户编号（外键）
        /// </summary>
        [Column("UserId")]
        [DisplayName("用户编号（外键）")]
        public int UserId { get; set; }

        /// <summary>
        /// 菜单名
        /// </summary>
        [Column("Name")]
        [DisplayName("菜单名")]
        public string Name { get; set; }

        /// <summary>
        /// 菜单指向链接
        /// </summary>
        [Column("Url")]
        [DisplayName("菜单指向链接")]
        public string Url { get; set; }

        /// <summary>
        /// 主表相关信息（用户注册信息表）
        /// </summary>
        public virtual User Users { get; set; }
    }

    public partial class User
    {
        /// <summary>
        /// 用户菜单列表
        /// </summary>
        public virtual ICollection<Menu> MenuList { get; set; }
    }
}

namespace XingAo.Software.UserCenter.Model.Mappings
{
    /// <summary>
    /// 实体映射表
    /// </summary>
    [Export("XingAo_UserCenter_Menu")]
    public partial class MenuMapping : MappingBase<Menu>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public MenuMapping()
        {
            //实体映射表名
            this.ToTable("XingAo_UserCenter_Menu");
            //表间关系映射
            this.HasRequired(m => m.Users).WithMany(m => m.MenuList).HasForeignKey(t => t.UserId);
        }
    }
}
