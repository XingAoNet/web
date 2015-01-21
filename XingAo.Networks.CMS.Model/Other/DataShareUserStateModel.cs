using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 数据共享调用接口--之--用户状态实体对象
    /// </summary>
  public  class DataShareUserStateModel
    {
      /// <summary>
      /// 用户详细信息
      /// </summary>
      public Model.DataShare_Users UserInfo { get; set; }
      /// <summary>
      /// 开始时间
      /// </summary>
      public DateTime StartTime { get; set; }
      /// <summary>
      /// 有效期
      /// </summary>
      public DateTime EndTime { get; set; }
      /// <summary>
      /// 授权密钥
      /// </summary>
      public string AccessToken { get; set; }
     /// <summary>
     /// 请求来源
     /// </summary>
      public string Source { get; set; }
    }
}
