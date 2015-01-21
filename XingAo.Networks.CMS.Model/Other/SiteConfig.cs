using System.Collections.Generic;
using XingAo.Core;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 网站配置信息
    /// </summary>
    public class SiteConfig
    {
        /// <summary>
        /// 因为AppConfig只能读取一次，所以采用缓存读取；
        /// </summary>
        private static Dictionary<string, string> siteConfigDict = new Dictionary<string, string>();
        string ConfigFilePath = "/Config/AppSetting.config";

        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName
        {
            get
            {
                if (siteConfigDict.ContainsKey("SiteName"))
                   return siteConfigDict["SiteName"];

                siteConfigDict["SiteName"] = ConfigOption.GetConfigString("SiteName");
                return ConfigOption.GetConfigString("SiteName");
            }
            set
            {
                ConfigOption.SetAppSetting("SiteName", value, ConfigFilePath);
                siteConfigDict["SiteName"] = value;
            }
        }
        /// <summary>
        /// 网站主域名
        /// </summary>
        public string SiteUrl
        {
            get
            {
                if (siteConfigDict.ContainsKey("SiteUrl"))
                    return siteConfigDict["SiteUrl"];

                siteConfigDict["SiteUrl"] = ConfigOption.GetConfigString("SiteUrl");
                return ConfigOption.GetConfigString("SiteUrl");
            }
            set
            {
                ConfigOption.SetAppSetting("SiteUrl", value, ConfigFilePath);
                siteConfigDict["SiteUrl"] = value;
            }
        }
        /// <summary>
        /// 版权信息
        /// </summary>
        public string Copyright
        {
            get
            {
                if (siteConfigDict.ContainsKey("Copyright"))
                    return siteConfigDict["Copyright"];

                siteConfigDict["Copyright"] = ConfigOption.GetConfigString("Copyright");
                return ConfigOption.GetConfigString("Copyright");
            }
            set
            {
                ConfigOption.SetAppSetting("Copyright", value, ConfigFilePath);
                siteConfigDict["Copyright"] = value;
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            get
            {
                if (siteConfigDict.ContainsKey("Tel"))
                    return siteConfigDict["Tel"];

                siteConfigDict["Tel"] = ConfigOption.GetConfigString("Tel");
                return ConfigOption.GetConfigString("Tel");
            }
            set
            {
                ConfigOption.SetAppSetting("Tel", value, ConfigFilePath);
                siteConfigDict["Tel"] = value;
            }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get
            {
                if (siteConfigDict.ContainsKey("Fax"))
                    return siteConfigDict["Fax"];

                siteConfigDict["Fax"] = ConfigOption.GetConfigString("Fax");
                return ConfigOption.GetConfigString("Fax");
            }
            set
            {
                ConfigOption.SetAppSetting("Fax", value, ConfigFilePath);
                siteConfigDict["Fax"] = value;
            }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string ZIP
        {
            get
            {
                if (siteConfigDict.ContainsKey("ZIP"))
                    return siteConfigDict["ZIP"];

                siteConfigDict["ZIP"] = ConfigOption.GetConfigString("ZIP");
                return ConfigOption.GetConfigString("ZIP");
            }
            set
            {
                ConfigOption.SetAppSetting("ZIP", value, ConfigFilePath);
                siteConfigDict["ZIP"] = value;
            }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get
            {
                if (siteConfigDict.ContainsKey("Address"))
                    return siteConfigDict["Address"];

                siteConfigDict["Address"] = ConfigOption.GetConfigString("Address");
                return ConfigOption.GetConfigString("Address");
            }
            set
            {
                ConfigOption.SetAppSetting("Address", value, ConfigFilePath);
                siteConfigDict["Address"] = value;
            }
        }
        /// <summary>
        /// 服务邮箱
        /// </summary>
        public string ServiceEmail
        {
            get
            {
                if (siteConfigDict.ContainsKey("ServiceEmail"))
                    return siteConfigDict["ServiceEmail"];

                siteConfigDict["ServiceEmail"] = ConfigOption.GetConfigString("ServiceEmail");
                return ConfigOption.GetConfigString("ServiceEmail");
            }
            set
            {
                ConfigOption.SetAppSetting("ServiceEmail", value, ConfigFilePath);
                siteConfigDict["ServiceEmail"] = value;
            }
        }

    }
}
