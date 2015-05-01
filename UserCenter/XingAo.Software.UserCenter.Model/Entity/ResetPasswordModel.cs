using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Software.UserCenter.Model
{
    /// <summary>
    /// 用户密码重置申请表(只保留30分钟的数据)
    /// </summary>
    [DBSource("XingAo_UserCenter")]
    [Table("XingAo_UserCenter_ResetPwd")]
    public partial class ResetPasswordModel
    {
        /// <summary>
        /// 重置编号
        /// </summary>
        [Key,Column("UId")]
        [DisplayName("重置编号")]
        public int Id { get; set; }
        /// <summary>
        /// 申请的唯一标志，程序将根据此值来决定对应的用户是否可以直接打开页面就修改密码
        /// </summary>
        [Column("Code")]
        [DisplayName("申请的唯一标志，程序将根据此值来决定对应的用户是否可以直接打开页面就修改密码")]
        public string Code { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        [Column("UserId")]
        [DisplayName("用户编号")]
        public int UserId { get; set; }
        /// <summary>
        /// 创建时间（30分钟后数据将被清除）
        /// </summary>
        [Column("CreateTime")]
        [DisplayName("创建时间")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 重置类型（0-手机动态密码重置，1-邮箱地址重置）
        /// </summary>
        [Column("Type")]
        [DisplayName("重置类型（0-手机动态密码重置，1-邮箱地址重置）")]
        public int Type { get; set; }
        /// <summary>
        /// 客户端IP（用于验证同一个用户）
        /// </summary>
        [Column("ClientIP")]
        [DisplayName("客户端IP（用于验证同一个用户）")]
        public string ClientIP { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual UserModel User { get; set; }
    }

    public partial class UserModel
    {
        /// <summary>
        /// <para>用户密码重置申请表(只保留30分钟的数据)；</para>
        /// <para>当用户点击多次重置密码时，获取最后一条数据</para>
        /// </summary>
        public virtual ICollection<ResetPasswordModel> ResetPasswordList { get; set; }
    }
}
namespace XingAo.Software.UserCenter.Model.Mappings
{
    [Export("ResetPasswordMapping")]
    public partial class ResetPasswordMapping : MappingBase<ResetPasswordModel>
    {
        public ResetPasswordMapping()
        {
            this.ToTable("XingAo_UserCenter_ResetPwd");
            this.HasRequired(m => m.User).WithMany(m => m.ResetPasswordList).HasForeignKey(t => t.UserId);
        }
    }
}
