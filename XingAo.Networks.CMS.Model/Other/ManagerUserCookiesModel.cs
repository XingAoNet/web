using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 后台用户cookies 实体对象
    /// </summary>
   public class ManagerUserCookiesModel
    {
       /// <summary>
       /// 用户ID
       /// </summary>      
       public int UserID { get; set; }
       /// <summary>
       /// 真实姓名
       /// </summary>
       public string RealName { get; set; }
       /// <summary>
       /// 前台菜单权限
       /// </summary>
       public string NavIDList { get; set; }
       /// <summary>
       /// 后台菜单权限
       /// </summary>
       public string MenuIDList { get; set; }
       /// <summary>
       /// 用户类型：0超级管理员 1站点管理员 2普通后台用户
       /// </summary>
       public string UserType { get; set; }
       /// <summary>
       /// 登录时间
       /// </summary>
       public string LoginTime { get; set; }
       /// <summary>
       /// 登录次数
       /// </summary>
       public int LoginNum { get; set; }
    }
}
