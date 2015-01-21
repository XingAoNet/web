using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Networks.CMS.Common;
using System.ComponentModel;
using XingAo.Core;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel
{
    public class SiteConfig
    {       
        /// <summary>
        /// 取配置信息内的网站名称
        /// </summary>
        /// <returns></returns>
        public static string GetSiteName()
        {
            return ConfigOption.GetConfigString("SiteName");
        }
        /// <summary>
        /// 取配置信息内的网站主域名
        /// </summary>
        /// <returns></returns>
        public static string GetSiteUrl()
        {
            return ConfigOption.GetConfigString("SiteUrl");
        }
        /// <summary>
        /// 取配置信息内的网站版权信息
        /// </summary>
        /// <returns></returns>
        public static string GetCopyright()
        {
            return ConfigOption.GetConfigString("Copyright").Replace("{currentyear}",DateTime.Now.Year.ToString());
        }
        /// <summary>
        /// 取配置信息内的联系电话
        /// </summary>
        /// <returns></returns>
        public static string GetTel()
        {
            return ConfigOption.GetConfigString("Tel");
        }
        /// <summary>
        /// 取配置信息内的传真
        /// </summary>
        /// <returns></returns>
        public static string GetFax()
        {
            return ConfigOption.GetConfigString("Fax");
        }
        /// <summary>
        /// 取配置信息内的邮编
        /// </summary>
        /// <returns></returns>
        public static string GetZIP()
        {
            return ConfigOption.GetConfigString("ZIP");
        }
    }
}
