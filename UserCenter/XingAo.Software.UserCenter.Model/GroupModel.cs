using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace XingAo.Software.UserCenter.Model
{
    /// <summary>
    /// 用户组信息
    /// </summary>
    [Table("XingAo_UserCenter_Group")]
    public partial class GroupModel
    {
        /// <summary>
        /// 用户组编号
        /// </summary>
        [Column("UId")]
        [DisplayName("用户组编号")]
        public int Id { get; set; }
        /// <summary>
        /// 用户组名称
        /// </summary>
        [Column("Name")]
        [DisplayName("用户组名称")]
        public string Name { get; set; }
    }
}
