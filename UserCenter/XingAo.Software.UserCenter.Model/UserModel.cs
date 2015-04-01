using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Software.UserCenter.Model
{
    /// <summary>
    /// 用户注册信息
    /// </summary>
    [Table("XA_UserCenter_User")]
    public partial class UserModel
    {
        /// <summary>
        /// 用户编号，用于用户唯一表示
        /// </summary>
        [Column("UId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Column("UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column("Password")]
        public string Password { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [Column("RealName")]
        public string RealName { get; set; }
        /// <summary>
        /// 性别，0--保密，1--男，2--女
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 电子邮箱（必须填写，用于邮箱验证）
        /// </summary>
        [Column("Email")]
        public string Email { get; set; }
        /// <summary>
        /// 手机号码（必须填写，用于发送短信验证），格式为+86 1XXXXXXXXXX或 1XXXXXXXXXX(X为十位数字）
        /// </summary>
        [Column("Phone")]
        public string Phone { get; set; }
        /// <summary>
        /// 用户注册时间
        /// </summary>
        [Column("RegisterTime")]
        public DateTime RegisterTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Column("LastLoginTime")]
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 帐号是否可用（1--可用，0--禁用）
        /// </summary>
        [Column("Enable")]
        public int Enable { get; set; }
        /// <summary>
        /// 审核状态：0--未审核 1--审核通过
        /// </summary>	
        [Column("Audit")]
        public int Audit { get; set; }
        /// <summary>
        /// 帐号是否被删除:0--未删除 1--已删除
        /// </summary>
        [Column("IsDel")]
        public int IsDel { get; set; }
        /// <summary>
        /// 用户等级
        /// </summary>
        [Column("Level")]
        public int Level { get; set; }
        /// <summary>
        /// 用户积分
        /// </summary>
        [Column("Point")]
        public int Point { get; set; }
        /// <summary>
        /// 用户组编号(外键）
        /// </summary>
        [Column("GroupId")]
        public int GroupId { get; set; }
        /// <summary>
        /// 用户组
        /// </summary>
        public virtual GroupModel Group { get; set; }
        /// <summary>
        /// 用户角色编号（外键）
        /// </summary>
        [Column("RoleId")]
        public int RoleId { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public virtual RoleModel Role { get; set; }
    }

    public partial class GroupModel
    {
        /// <summary>
        /// 用户注册信息列表
        /// </summary>
        public virtual ICollection<UserModel> Users { get; set; }
    }

    public partial class RoleModel
    {
        /// <summary>
        /// 用户注册信息列表
        /// </summary>
        public virtual ICollection<UserModel> Users { get; set; }
    }
}

namespace XingAo.Software.UserCenter.Model//所有映射
{
    /// <summary>
    /// 实体映射表
    /// </summary>
    [Export("XA_UserCenter_User")]
    public partial class UserListMapping : MappingBase<UserModel>
    {
        /// <summary>
        /// 实体映射表名及表间关系
        /// </summary>
        public UserListMapping()
        {
            //实体映射表名
            this.ToTable("XA_UserCenter_User");
            //表间关系映射
            this.HasRequired(m => m.Group).WithMany(m => m.Users).HasForeignKey(t => t.GroupId);
            this.HasRequired(m => m.Role).WithMany(m => m.Users).HasForeignKey(t => t.RoleId);
        }
    }
}