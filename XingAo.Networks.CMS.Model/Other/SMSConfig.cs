using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Networks.CMS.Common;
using XingAo.Core;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 邮件配置信息
    /// </summary>
    public class SMSConfig
    {
        /// <summary>
        /// 因为AppConfig只能读取一次，所以采用缓存读取；
        /// </summary>
        private static Dictionary<string, string> SMSConfigDict = new Dictionary<string, string>();
        private string _path = string.Empty;

        public SMSConfig(string path = "/Config/Setting/SMSSetting.config.config") { _path = path; }
        /// <summary>
        /// 帐号
        /// </summary>
        public string PhoneUsername
        {
            get
            {
                if (SMSConfigDict.ContainsKey("PhoneUsername"))
                    return SMSConfigDict["PhoneUsername"];

                SMSConfigDict["PhoneUsername"] = ConfigOption.GetConfigString("PhoneUsername");
                return ConfigOption.GetConfigString("PhoneUsername");
            }
            set
            {
                ConfigOption.SetAppSetting("PhoneUsername", value, _path);
                SMSConfigDict["PhoneUsername"] = value;
            }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string PhonePassword
        {
            get
            {
                if (SMSConfigDict.ContainsKey("PhonePassword"))
                    return SMSConfigDict["PhonePassword"];
                SMSConfigDict["PhonePassword"] = ConfigOption.GetConfigString("PhonePassword");
                return ConfigOption.GetConfigString("PhonePassword");
            }
            set
            {
                ConfigOption.SetAppSetting("PhonePassword", value, _path);
                SMSConfigDict["PhonePassword"] = value;
            }
        }
    }
}
