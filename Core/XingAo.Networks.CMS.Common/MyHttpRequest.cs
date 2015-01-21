/******************************************************************
* Create By:卢小阳
* Create Time:2013-8-22 15:45:30
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace XingAo.Networks.CMS.Common
{
   public static class MyHttpRequest
    {
       /// <summary>
       /// 取当前页面的路径
       /// </summary>
        /// <param name="context">HttpRequest</param>
       /// <returns></returns>
       public static string GetPath(this HttpRequest context)
       {
           string path = context.Path;
           int index = path.LastIndexOf("/");
           return path.Substring(0, index);
       }
    }
}
