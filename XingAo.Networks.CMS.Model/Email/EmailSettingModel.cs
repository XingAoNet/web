/******************************************************************
* Create By:陈成杰
* Create Time:2014-05-28 18:39:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System.Collections.Generic;
using XingAo.Core;

namespace XingAo.Networks.CMS.Model.Email
{
    /// <summary>
    /// 邮箱设置
    /// </summary>
    public class EmailSettingModel
    {
        /// <summary>
        /// 因为AppConfig只能读取一次，所以采用缓存读取；
        /// </summary>
        private static Dictionary<string, string> settingConfigDict = new Dictionary<string, string>();
        private string _path = string.Empty;

        public EmailSettingModel(string path = @"\Config\Setting\EmailSetting.config") { _path = path; }
        /// <summary>
        /// SMTP服务器
        /// </summary>
        public string SMPTServer
        {
            get
            {
                if (settingConfigDict.ContainsKey("SMPTServer"))
                    return settingConfigDict["SMPTServer"];

                settingConfigDict["SMPTServer"] = ConfigOption.GetConfigString("SMPTServer");
                return ConfigOption.GetConfigString("SMPTServer");
            }
            set 
            {
                ConfigOption.SetAppSetting("SMPTServer", value, _path);
                settingConfigDict["SMPTServer"] = value;
            }
        }
        /// <summary>
        /// 发件人昵称
        /// </summary>
        public string SendName 
        {
            get
            {
                if (settingConfigDict.ContainsKey("SendName"))
                    return settingConfigDict["SendName"];

                settingConfigDict["SendName"] = ConfigOption.GetConfigString("SendName");
                return ConfigOption.GetConfigString("SendName");
            }
            set
            {
                ConfigOption.SetAppSetting("SendName", value, _path);
                settingConfigDict["SendName"] = value;
            }
        }
        /// <summary>
        /// 邮箱账号
        /// </summary>
        public string SendAccount
        {
            get
            {
                if (settingConfigDict.ContainsKey("SendAccount"))
                    return settingConfigDict["SendAccount"];

                settingConfigDict["SendAccount"] = ConfigOption.GetConfigString("SendAccount");
                return ConfigOption.GetConfigString("SendAccount");
            }
            set
            {
                ConfigOption.SetAppSetting("SendAccount", value, _path);
                settingConfigDict["SendAccount"] = value;
            }
        }
        /// <summary>
        /// 邮箱密码
        /// </summary>
        public string SendPwd
        {
            get
            {
                if (settingConfigDict.ContainsKey("SendPwd"))
                    return settingConfigDict["SendPwd"];

                settingConfigDict["SendPwd"] = ConfigOption.GetConfigString("SendPwd");
                return ConfigOption.GetConfigString("SendPwd");
            }
            set
            {
                ConfigOption.SetAppSetting("SendPwd", value, _path);
                settingConfigDict["SendPwd"] = value;
            }
        }
        /// <summary>
        /// SMTP端口,默认端口25
        /// </summary>
        public int SMTPPort
        {
            get
            {
                if (settingConfigDict.ContainsKey("SMTPPort"))
                    return settingConfigDict["SMTPPort"].ObjToInt(25) ;

                settingConfigDict["SMTPPort"] = ConfigOption.GetConfigString("SMTPPort");
                return ConfigOption.GetConfigString("SMTPPort").ObjToInt(25) ;
            }
            set
            {
                ConfigOption.SetAppSetting("SMTPPort", value.ToString(), _path);
                settingConfigDict["SMTPPort"] = value.ToString();
            }
        }
        /// <summary>
        /// 身份验证
        /// </summary>
        public int SmtpValidation
        {
            get
            {
                if (settingConfigDict.ContainsKey("SmtpValidation"))
                    return settingConfigDict["SmtpValidation"].ObjToInt(0);

                settingConfigDict["SmtpValidation"] = ConfigOption.GetConfigString("SmtpValidation");
                return ConfigOption.GetConfigString("SmtpValidation").ObjToInt(0);
            }
            set
            {
                ConfigOption.SetAppSetting("SmtpValidation", value.ToString(), _path);
                settingConfigDict["SmtpValidation"] = value.ToString();
            }
        }
    }
}
