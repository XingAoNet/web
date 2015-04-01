using System;

namespace XingAo.Software.UserCenter.Model
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public partial class RoleModel
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 是否系统角色
        /// </summary>
        public bool IsSystem { get; set; }
    }
}
