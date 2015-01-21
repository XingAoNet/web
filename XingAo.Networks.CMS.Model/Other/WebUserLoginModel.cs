using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 网站前台用户登录cookies实体类
    /// </summary>
   public class WebUserLoginModel
    {
       /// <summary>
       /// 用户id
       /// </summary>
       public int ID { get; set; }
       /// <summary>
       /// 用户名
       /// </summary>
       public string UserName { get; set; }
       /// <summary>
       /// 真实姓名
       /// </summary>
       public string RealName { get; set; }
       /// <summary>
       /// 会员等级
       /// </summary>
       public int VipLevel { get; set; }
    }
}
