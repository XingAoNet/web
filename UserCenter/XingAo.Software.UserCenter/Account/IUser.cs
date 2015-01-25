/******************************************************************
 * 文件名 : IUser.cs
 * 数据表 : no
 * 创建者 : 陈成杰
 * 发布日期 : 2015/1/24 22:45:50
 * 文件描述 : 用户信息实体接口
 * 
 * 修改记录
 * R1:
 *  修改作者 ： 
 *  修改日期 ：
 *  修改内容 ：
 *      
 * R2:
 *  修改作者 ：
 *  修改日期 ：
 *  修改内容 ：
 *  
 ******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Software.UserCenter.Audit;

namespace XingAo.Software.UserCenter.Account
{
    /// <summary>
    /// 用户基本信息实体接口
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 用户编号，用于会员唯一表示
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        string RealName { get; set; }
        /// <summary>
        /// 性别，0--保密，1--男，2--女
        /// </summary>
        int Sex { get; set; }
        /// <summary>
        /// 电子邮箱（必须填写，用于邮箱验证）
        /// </summary>
        string EMail { get; set; }
        /// <summary>
        /// 手机号码（必须填写，用于发送短信验证），格式为+86 1XXXXXXXXXX或 1XXXXXXXXXX(X为十位数字）
        /// </summary>
        string Phone { get; set; }
        /// <summary>
        /// 会员注册时间
        /// </summary>
        DateTime RegisterTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 帐号是否可用（1--可用，0--禁用）
        /// </summary>
        int Enable { get; set; }
        /// <summary>
        /// 审核状态：0--未审核 1--审核通过
        /// </summary>	
        int Audit { get; set; }
        /// <summary>
        /// 帐号是否被删除:0--未删除 1--已删除
        /// </summary>
        int IsDel { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        int Level { get; set; }
        /// <summary>
        /// 会员积分
        /// </summary>
        int Point { get; set; }
        /// <summary>
        /// 会员组信息
        /// </summary>
        IGroup Group { get; set; }
        /// <summary>
        /// 会员角色
        /// </summary>
        IRole Role { get; set; }
        /// <summary>
        /// 当前用户下所拥有的权限菜单
        /// </summary>
        IList<IMenu> MenuList { get; set; }
    }
}
