using System;
using System.ComponentModel.DataAnnotations;
using XingAo.Core.Data;

namespace XingAo.Software.UserCenter.Model
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [DBSource("XingAo_UserCenter")]
    [Table("XingAo_UserCenter_Role")]
    public partial class RoleModel
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Key,Column("UId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("Name")]
        [Display(Name = "角色名称")]
        public string Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime")]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        [Column("Type")]
        [Display(Name = "角色类型")]
        public int Type { get; set; }
        /// <summary>
        /// 是否系统角色
        /// </summary>
        [Column("IsSystem")]
        [Display(Name = "是否系统角色")]
        public bool IsSystem { get; set; }
    }
}
