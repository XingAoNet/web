/******************************************************************
* Create By:卢小阳
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Xml.Linq;
using XingAo.Core;

namespace XingAo.Core
{
	/// <summary>
    /// AppSettings操作类
	/// </summary>
	public sealed class ConfigHelper
	{
		/// <summary>
		/// 得到AppSettings中的配置字符串信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetConfigString(string key)
		{
            object objModel = null;

            try
            {
                objModel = ConfigurationManager.AppSettings[key];
                if (objModel != null)
                {
                    objModel = System.Web.HttpContext.Current.Server.HtmlDecode(objModel.ToString());

                }
                else
                    return "";
            }
            catch
            {
                return "";
            }
            
            return objModel.ObjToStr();
		}

		/// <summary>
		/// 得到AppSettings中的配置Bool信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool GetConfigBool(string key)
		{
			bool result = false;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = bool.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}
			return result;
		}
		/// <summary>
		/// 得到AppSettings中的配置Decimal信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static decimal GetConfigDecimal(string key)
		{
			decimal result = 0;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = decimal.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}

			return result;
		}
		/// <summary>
		/// 得到AppSettings中的配置int信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static int GetConfigInt(string key)
		{
			int result = 0;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = int.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}

			return result;
		}
        /// <summary>
        /// 修改 AppSettings的内容
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// <param name="path">路径</param>
        /// <returns>返回是否修改成功</returns>
        public static bool SetAppSetting(string key, string value,string path)
        {
            try
            {
                XElement xml = XElement.Load(FileBaseOption.GetAbslutionPath(path));
                IEnumerable<XElement> settimgs = xml.Elements("add");
                bool isFind = false;
                foreach (XElement el in settimgs)
                {
                    if (el.Attribute("key").Value == key)
                    {
                        el.Attribute("value").Value = value;
                        isFind = true;
                        break;
                    }
                }
                if (!isFind)
                {
                    xml.Add(new XElement("add", new XAttribute("key", key), new XAttribute("value", value)));
                }
                xml.Save(FileBaseOption.GetAbslutionPath(path));
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
