using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Networks.CMS.Common;
using XingAo.Core;

namespace XingAo.Networks.CMS.Template.Label.LabelFunctions
{
    /// <summary>
    /// 网站配置信息
    /// </summary>
    public  class SiteConfig
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName
        {
            get
            {
                return ConfigOption.GetConfigString("SiteName");
            }
            set
            {
                ConfigOption.SetAppSetting("SiteName",value);
            }
        }
        /// <summary>
        /// 网站主域名
        /// </summary>
        public string SiteUrl
        {
            get
            {
                return ConfigOption.GetConfigString("SiteUrl");
            }
            set
            {
                ConfigOption.SetAppSetting("SiteUrl",value);
            }
        }
        /// <summary>
        /// 版权信息
        /// </summary>
        public string Copyright
        {
            get
            {
                return ConfigOption.GetConfigString("Copyright");
            }
            set
            {
                ConfigOption.SetAppSetting("Copyright",value);
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            get
            {
                return ConfigOption.GetConfigString("Tel");
            }
            set
            {
                ConfigOption.SetAppSetting("Tel",value);
            }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get
            {
                return ConfigOption.GetConfigString("Fax");
            }
            set
            {
                ConfigOption.SetAppSetting("Fax",value);
            }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string ZIP
        {
            get
            {
                return ConfigOption.GetConfigString("ZIP");
            }
            set
            {
                ConfigOption.SetAppSetting("ZIP",value);
            }
        }
        /// <summary>
        /// 首页关键字（搜索引擎）
        /// </summary>
        public string IndexKeyWords
        {
            get
            {
                return ConfigOption.GetConfigString("IndexKeyWords");
            }
            set
            {
                ConfigOption.SetAppSetting("IndexKeyWords",value);
            }
        }
        /// <summary>
        /// 首页描述（搜索引擎）
        /// </summary>
        public string IndexDescription
        {
            get
            {
                return ConfigOption.GetConfigString("IndexDescription");
            }
            set
            {
                ConfigOption.SetAppSetting("IndexDescription",value);
            }
        }
    }
}
