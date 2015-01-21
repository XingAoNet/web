using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
using XingAo.Networks.WeChat;
using XingAo.Core;

namespace XingAo.Networks.WeChat
{
    public class PhoneSend
    {
        /// <summary>
        /// 获得传入对象的值(返回整型)
        /// </summary>
        /// <param name="_value">传入的值</param>
        /// <param name="defaultValue">如果没有获取到 返回该默认值</param>
        /// <returns>返回整型</returns>
        public static int GetInputInt32(string _value, int defaultValue)
        {

            int num;
            if (!int.TryParse(_value, out num))
            {
                num = defaultValue;
            }
            return num;
        }

        #region 加密
        
        public static string HashString(string value)
        {

            byte[] data = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(value));

            StringBuilder hashedString = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                hashedString.Append(data[i].ToString("x2"));
            }
            return hashedString.ToString();

        }
        
        public static bool verifyHashString(string input, string enCodeString)
        {
            string str = HashString(input);
            StringComparer sCompare = StringComparer.OrdinalIgnoreCase;
            if (sCompare.Compare(enCodeString, str) == 0)
                return true;
            return false;
        }
        
        #endregion

        public static bool SendMsg(string Msg, string _mobile, out string ResultMsg,int port=1)
        {
            string user = System.Configuration.ConfigurationManager.AppSettings["PhoneUsername"];
            string pwd = System.Configuration.ConfigurationManager.AppSettings["PhonePassword"];
            if (port == 2)
            {
                user = System.Configuration.ConfigurationManager.AppSettings["PhoneUsername2"];
                pwd = System.Configuration.ConfigurationManager.AppSettings["PhonePassword2"];
            }
    
            string _mobiles = _mobile.Trim(',').Replace(",", ";");
            Encoding encode = Encoding.UTF8;
            string _msg = SensitiveUtil.CheckSensitive(Msg);
            string content = _msg;
            content = System.Web.HttpUtility.UrlEncode(content, encode);
            string Balance = ReturnMsg("http://116.213.72.20/SMSHttpService/Balance.aspx", "username=" + user + "&password=" + pwd);

            if (GetInputInt32(Balance, 0) > 0)
            {
                string rs = ReturnMsg("http://116.213.72.20/SMSHttpService/CheckDeadWord.aspx", "msg=" + content);
                if (rs != "")
                {
                    string splitMsg = _msg;
                    foreach (string str in rs.Split('|'))
                    {
                        splitMsg = splitMsg.Replace(str, str.ToLower().Insert(1, " "));
                    }
                    content = System.Web.HttpUtility.UrlEncode(splitMsg, encode);
                }
                string result = ReturnMsg("http://116.213.72.20/SMSHttpService/send.aspx", string.Format("username={0}&password={1}&mobile={2}&content={3}", user, pwd, _mobiles, content));
                string msg = "";
                switch (result)
                {
                    case "-2":
                        msg = "提交的号码中包含不符合格式的手机号码";
                        break;
                    case "-1":
                        msg = "数据保存失败";
                        break;
                    case "0":
                        msg = "发送成功";
                        break;
                    case "1001":
                        msg = "用户名或密码错误";
                        break;
                    case "1002":
                        msg = "余额不足";
                        break;
                    case "1003":
                        msg = "参数错误，请输入完整的参数";
                        break;
                    case "1004":
                        msg = "其他错误";
                        break;
                    case "1005":
                        msg = "预约时间格式不正确";
                        break;
                }
                ResultMsg = msg;               
            }
            else
                ResultMsg = Balance;
            return true;    
        }
        /// <summary>
        /// URLpost请求
        /// </summary>
        /// <param name="URL">请求地址</param>
        /// <param name="data">URL参数</param>
        /// <returns></returns>
        private static string ReturnMsg(string URL, string data)
        {
            string outStr;
            int ret = HttpHelper.HttpPost(URL, data, EncodeFormat.EF_UTF8, out outStr);
            if (ret == 200)
            {
                return outStr;
            }
            return "失败";
        }

        public static bool SendClientMsg(string content, string personName, string _mobiles, string _ResultInfo)
        {
            string ResultMsg = string.Empty;
            Encoding gb2312 = Encoding.GetEncoding("GB2312");
            string user = System.Configuration.ConfigurationManager.AppSettings["SendClientUsername"];
            string pwd = System.Configuration.ConfigurationManager.AppSettings["SendClientPassword"];
            content = System.Web.HttpUtility.UrlEncode(System.Web.HttpUtility.UrlEncode(content, gb2312), gb2312);
            personName = System.Web.HttpUtility.UrlEncode(System.Web.HttpUtility.UrlEncode(personName, gb2312), gb2312);
            string ResultInfo = System.Web.HttpUtility.UrlEncode(System.Web.HttpUtility.UrlEncode(_ResultInfo, gb2312), gb2312);
            string data = string.Format("func=sendsms&username={0}&password={1}&mobiles={2}&message={3}&Recipient={4}&ResultInfo={5}", user, pwd, _mobiles, content, personName, ResultInfo);
            string outStr;
            int ret = HttpHelper.HttpPost("http://www.chemmu.net/Api/SmsApiEx.aspx", data, EncodeFormat.EF_GB2312, out outStr);
            if (ret == 200)
            {
                ResultMsg =outStr;
            }
            ResultMsg = "发送失败";
            return false;
        }


    }
}
