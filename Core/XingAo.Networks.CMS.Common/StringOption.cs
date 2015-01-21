/******************************************************************
* Create By:卢小阳
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Web;

namespace XingAo.Networks.CMS.Common
{
    /// <summary>
    /// 字符串操作类
    /// </summary>
    public static class StringOption
    {
        #region-----------判断一个字符串是否为数字(返回值为True或False)-------------------
        /// <summary>
        /// 判断一个字符串是否为数字(返回值为True或False)
        /// </summary>
        /// <param name="bPstr">参数bPstr表示要判断的字符串</param>
        /// <returns>判断一个字符串是否为数字(返回值为True或False)</returns>
        public static bool IsNumberic(string bPstr)
        {
            string pattern = @"\d+";
            Regex re = new Regex(pattern);
            if (re.IsMatch(bPstr))
                return true;
            return false;
            //try
            //{
            //    Double bPint = Convert.ToDouble(bPstr);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        /// <summary>
        /// 判断一个字符串是否为数字(返回值为True或False)
        /// </summary>
        /// <param name="bPstr">要判断的字符串</param>
        /// <returns>判断一个字符串是否为数字(返回值为True或False)</returns>
        public static bool IsNumber(this string bPstr)
        {
            return IsNumberic(bPstr);
        }
        #endregion-----------------------------------------------------------------------------

        #region-----------将文本中的非法字符过滤------------------------------------------
        /// <summary>
        /// 将文本中的非法字符过滤
        /// </summary>
        /// <param name="TempStr">要过滤的文本</param>
        /// <param name="Filter">要过滤的关键字，以|间隔</param>
        /// <returns>过滤非法字符后的文本</returns>
        public static string FilterParameters(string TempStr, string Filter)
        {
            string FilterField = Filter;
            string[] filter = FilterField.Split('|');
            if (!string.IsNullOrEmpty(TempStr))
            {
                foreach (string TempReplaceStr in filter)
                {                   
                  TempStr=  Regex.Replace(TempStr, TempReplaceStr,"",RegexOptions.IgnoreCase);
                   // TempStr = TempStr.Replace(TempReplaceStr, "");
                }
            }
            return TempStr;
        }
        /// <summary>
        /// 将文本中的非法字符过滤
        /// </summary>
        /// <param name="TempStr">要过滤的文本,默认过滤select|update|delete|insert|drop|and|*|(|)</param>
        /// <returns></returns>
        public static string FilterParameters(string TempStr)
        { return FilterParameters(TempStr,"select|update|delete|insert|drop|and|\\*|\\(|\\)");}
        #endregion----------------------------------------------

        #region-----------过滤脚本及框架--------------------------------------------------
        /// <summary>
        /// 过滤脚本及框架
        /// </summary>
        /// <param name="html">要过滤的HTML</param>
        /// <returns>过滤脚本及框架后的HTML</returns>
        public static string ClearScript(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new

            System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            return html;
        }
        /// <summary>
        /// 过滤脚本及框架
        /// </summary>
        /// <param name="html">要过滤的HTML</param>
        /// <returns>过滤脚本及框架后的HTML</returns>
        public static string ClearScripts(this string html)
        {return ClearScript(html); }
        #endregion---------------------------------------------

        #region-----------去除HTML标签----------------------------------------------------
        /// <summary>
        /// 去除HTML标签
        /// </summary>
        /// <param name="RContent">要去除标签的文本</param>
        /// <returns></returns>
        public static string ClearHTML(string RContent)
        {
            if (string.IsNullOrEmpty(RContent))
                return "";
            RContent = Regex.Replace(RContent, "<[^>]+>", "");
            return RContent;
        }
        /// <summary>
        /// 去除HTML标签
        /// </summary>
        /// <param name="RContent">要去除标签的文本</param>
        /// <returns>去除HTML标签</returns>
        public static string ClearHtml(this string RContent)
        {
            return ClearHTML(RContent);        
        }
        #endregion-----------------------------------------------------------------------------

        #region-----------替换HTML标签----------------------------------------------------
        /// <summary>
        /// 将HTML标签转化成代码
        /// </summary>
        /// <param name="RContent">要转化标签的文本</param>
        /// <returns></returns>
        public static string HTML_Code(string RContent)
        {
            RContent = RContent.Replace("<", "&lt;");
            RContent = RContent.Replace(">", "&gt;");
            RContent = RContent.Replace("\"", "&quot;");
            //RContent = RContent.Replace("'", "");
            //RContent = RContent.Replace("", "");
            //RContent = RContent.Replace("", "");
            //RContent = RContent.Replace("", "");
            //RContent = RContent.Replace("", "");
            return RContent;
        }
        /// <summary>
        /// 将HTML标签转化成代码
        /// </summary>
        /// <param name="RContent">要转化标签的文本</param>
        /// <returns>将HTML标签转化成代码</returns>
        public static string HtmlToCode(this string RContent)
        {
            return HTML_Code(RContent);
        }
        /// <summary>
        /// 将代码转化成HTML标签
        /// </summary>
        /// <param name="RContent">要转化代码的文本</param>
        /// <returns></returns>
        public static string Code_HTML(string RContent)
        {
            RContent = RContent.Replace("&lt;", "<");
            RContent = RContent.Replace("&gt;", ">");
            RContent = RContent.Replace("&quot;", "\"");
            //RContent = RContent.Replace("'", "");
            //RContent = RContent.Replace("", "");
            //RContent = RContent.Replace("", "");
            //RContent = RContent.Replace("", "");
            //RContent = RContent.Replace("", "");
            return RContent;
        }
        /// <summary>
        /// 将代码转化成HTML标签
        /// </summary>
        /// <param name="RContent">要转化代码的文本</param>
        /// <returns>将代码转化成HTML标签</returns>
        public static string CodeToHtml(this string RContent)
        {
            return Code_HTML(RContent);
        }
        #endregion-----------------------------------------------------------------------------

        #region-----------截取字符串------------------------------------------------------
        /// <summary>
        /// 截取字符串，中文按长度2处理
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">截取长度，中文长度为2</param>
        /// <param name="ClearHtml">是否清除html后再截取</param>
        /// <param name="AfterStr">截取后加回的字符串，如....</param>
        /// <returns></returns>
        public static string CutStr(string str, int len, bool ClearHtml,string AfterStr)
        {
            if (ClearHtml)
                str = ClearHTML(str);
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = str.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;
            bool isCut = false;
            if (str.Length < len)
                return str;
            for (int i = 0; i < len; i++)
            {
                if (regex.IsMatch((stringChar[i]).ToString()))
                {
                    sb.Append(stringChar[i]);
                    nLength += 2;
                }
                else
                {
                    sb.Append(stringChar[i]);
                    nLength = nLength + 1;
                }

                if (nLength > len)
                {
                    isCut = true;
                    break;
                }
            }
            if (isCut)
                return sb.ToString() + AfterStr;
            else
                return sb.ToString();
        }
        /// <summary>
        /// 清除html后再截取字符串并在截取后加...（中文按长度2处理）
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">截取长度，中文长度为2</param>
        /// <returns></returns>
        public static string CutStr(string str, int len)
        {return CutStr( str,  len, true,"..."); }
        /// <summary>
        /// 清除html后再截取字符串并在截取后加...（中文按长度2处理）
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">截取长度，中文长度为2</param>
        /// <param name="ClearHtml">是否清除html后再截取</param>
        /// <returns></returns>
        public static string CutStr(string str, int len, bool ClearHtml)
        { return CutStr(str, len, ClearHtml, "..."); }
        /// <summary>
        /// 截取字符串，中文按长度1处理
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">取长度，中文长度为1</param>
        /// <param name="ClearHtml">是否清除html后再截取</param>
        /// <param name="AfterStr">截取后加回的字符串，如....</param>
        /// <returns></returns>
        public static string CutStr2(string str, int len, bool ClearHtml, string AfterStr)
        {
            if (ClearHtml)
                str = ClearHTML(str);
            if (str.Length > len)
                return str.Substring(0, len) + AfterStr;
            return str;
        }
        /// <summary>
        /// 清除html后再截取字符串并在截取后加...（中文按长度1处理）
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">截取长度，中文长度为1</param>
        /// <returns></returns>
        public static string CutStr2(string str, int len)
        { return CutStr2(str, len, true, "..."); }
        /// <summary>
        /// 清除html后再截取字符串并在截取后加...（中文按长度1处理）
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">截取长度，中文长度为1</param>
        /// <param name="ClearHtml">是否清除html后再截取</param>
        /// <returns></returns>
        public static string CutStr2(string str, int len, bool ClearHtml)
        { return CutStr2(str, len, ClearHtml, "..."); }
        #endregion--------------------------------------------------

        #region-----------取汉字拼音首字母------------------------------------------------
        /// <summary>
        /// 获得字符串汉字首字母
        /// </summary>
        /// <param name="Chinese">字符串</param>
        /// <returns>字符串汉字首字母</returns>
        public static string GetChineseFirstPingYing(string Chinese)
        {
            string _Temp = null;
            for (int i = 0; i < Chinese.Length; i++)
                _Temp = _Temp + GetOneIndex(Chinese.Substring(i, 1));
            return _Temp;
        }

        /// <summary>
        /// 判断是否合法汉字
        /// </summary>
        /// <param name="OneIndexTxt">汉字</param>
        /// <returns>汉字的首字母</returns>
        private static string GetOneIndex(string OneIndexTxt)
        {
            if (Convert.ToChar(OneIndexTxt) >= 0 && Convert.ToChar(OneIndexTxt) < 256)
                return OneIndexTxt;
            else
                return GetGbkX(OneIndexTxt);
        }

        /// <summary>
        /// 得到汉字的首字母
        /// </summary>
        /// <param name="str">汉字</param>
        /// <returns>汉字字母</returns>
        private static string GetGbkX(string str)
        {
            if (str.CompareTo("吖") < 0)
            {
                return str;
            }
            if (str.CompareTo("八") < 0)
            {
                return "A";
            }

            if (str.CompareTo("嚓") < 0)
            {
                return "B";
            }

            if (str.CompareTo("咑") < 0)
            {
                return "C";
            }
            if (str.CompareTo("妸") < 0)
            {
                return "D";
            }
            if (str.CompareTo("发") < 0)
            {
                return "E";
            }
            if (str.CompareTo("旮") < 0)
            {
                return "F";
            }
            if (str.CompareTo("铪") < 0)
            {
                return "G";
            }
            if (str.CompareTo("讥") < 0)
            {
                return "H";
            }
            if (str.CompareTo("咔") < 0)
            {
                return "J";
            }
            if (str.CompareTo("垃") < 0)
            {
                return "K";
            }
            if (str.CompareTo("嘸") < 0)
            {
                return "L";
            }
            if (str.CompareTo("拏") < 0)
            {
                return "M";
            }
            if (str.CompareTo("噢") < 0)
            {
                return "N";
            }
            if (str.CompareTo("妑") < 0)
            {
                return "O";
            }
            if (str.CompareTo("七") < 0)
            {
                return "P";
            }
            if (str.CompareTo("亽") < 0)
            {
                return "Q";
            }
            if (str.CompareTo("仨") < 0)
            {
                return "R";
            }
            if (str.CompareTo("他") < 0)
            {
                return "S";
            }
            if (str.CompareTo("哇") < 0)
            {
                return "T";
            }
            if (str.CompareTo("夕") < 0)
            {
                return "W";
            }
            if (str.CompareTo("丫") < 0)
            {
                return "X";
            }
            if (str.CompareTo("帀") < 0)
            {
                return "Y";
            }
            if (str.CompareTo("咗") < 0)
            {
                return "Z";
            }
            return str;
        }
        #endregion--------------------------------

        #region-----------字符串加密解密--------------------------------------------------
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <param name="encryptKey">加密密码</param>
        /// <returns></returns>
        public static string Encrypt(string str, string encryptKey)
        {
            if (encryptKey.Length > 4)
            {
                encryptKey = encryptKey.Substring(0, 4);
            }
            else if (encryptKey.Length < 4)
            {
                encryptKey = encryptKey.PadLeft(4,'0');
            }
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
            byte[] key = Encoding.Unicode.GetBytes(encryptKey);
            byte[] data = Encoding.Unicode.GetBytes(str);
            MemoryStream MStream = new MemoryStream();
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);
            CStream.FlushFinalBlock();
            return Convert.ToBase64String(MStream.ToArray());
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <param name="encryptKey">加密密码</param>
        /// <returns></returns>
        public static string EncryptStr(this string str, string encryptKey)
        { return Encrypt(str, encryptKey);}
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <returns></returns>
        public static string Encrypt(string str)
        {
            return Encrypt(str, "&5Fk");
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <returns></returns>
        public static string EncryptStr(this string str)
        { return Encrypt(str, "&5Fk"); }
        /// <summary>
        /// 解密(解密失败时返回空)
        /// </summary>
        /// <param name="str">密文</param>
        /// <param name="encryptKey">解密密码</param>
        /// <returns></returns>
        public static string Decrypt(string str, string encryptKey)
        {
            if (encryptKey.Length > 4)
            {
                encryptKey = encryptKey.Substring(0, 4);
            }
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
            byte[] key = Encoding.Unicode.GetBytes(encryptKey);
            try
            {
                byte[] data = Convert.FromBase64String(str);
                MemoryStream MStream = new MemoryStream();
                CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
                CStream.Write(data, 0, data.Length);
                CStream.FlushFinalBlock();
                return Encoding.Unicode.GetString(MStream.ToArray());
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 解密(解密失败时返回空)
        /// </summary>
        /// <param name="str">密文</param>
        /// <param name="encryptKey">解密密码</param>
        /// <returns></returns>
        public static string DecryptStr(this string str, string encryptKey)
        {return Decrypt( str,  encryptKey); }
        /// <summary>
        /// 解密(解密失败时返回空)
        /// </summary>
        /// <param name="str">密文</param>
        /// <returns></returns>
        public static string Decrypt(string str)
        { return Decrypt(str, "&5Fk"); }
        /// <summary>
        /// 解密(解密失败时返回空)
        /// </summary>
        /// <param name="str">密文</param>
        /// <returns></returns>
        public static string DecryptStr(this string str)
        { return Decrypt(str, "&5Fk"); }
        /// <summary>
        /// 对象为null转为空，如果不为null，则返回对象的.ToString()
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjectToString(object o)
        {
            if (o == null)
                return "";
            return o.ToString().Trim();
        }
        /// <summary>
        /// 对象为null转为空，如果不为null，则返回对象的.ToString()
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjToStr(this object o)
        {
            return ObjectToString(o);
        }
        /// <summary>
        /// 对象格式化成字符
        /// </summary>
        /// <param name="o">对象</param>
        /// <param name="format">格式化字符串</param>
        /// <returns></returns>
        public static string ObjToStr(this object o, string format)
        {
            try
            {
                switch (o.GetType().FullName.ToLower())
                {
                    case "system.datetime":
                        return ((DateTime)o).ToString(format);
                    case "system.int":
                        return ((int)o).ToString(format);
                    case "system.float":
                        return ((float)o).ToString(format);
                    case "system.decimal":
                        return ((decimal)o).ToString(format);
                    default:
                        return o.ObjToStr();
                }
            }
            catch { return o.ObjToStr(); }
        }
        /// <summary>
        /// 对象为null或空时返回-1，如果不为null，则返回对象的整数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int ObjToInt(this object o)
        {
            string s= ObjectToString(o);
            int v=-1;
            try{ v=int.Parse(s);}
            catch{}
            return s == "" ? -1 :v;
        }

        /// <summary>
        /// 对象为null或空时返回默认值，如果不为null，则返回对象的长整数
        /// </summary>
        /// <param name="o"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static long ObjToLong(this object o, long defaultValue)
        {
            string s = ObjectToString(o);
            long v = -1;
            try { v = long.Parse(s); }
            catch { }
            return s == "" ? defaultValue : v;
        }
        /// <summary>
        /// 对象为null或空时返回0，如果不为null，则返回对象的长整数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static long ObjToLong(this object o)
        {
            return o.ObjToLong(0);
        }
        /// <summary>
        /// 对象为null或空时返回defaultValue，如果不为null，则返回对象的整数
        /// </summary>
        /// <param name="o"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ObjToInt(this object o,int defaultValue)
        {
            if (o == null) return defaultValue;
            int v = defaultValue;
            if (string.IsNullOrEmpty(o.ToString()))
                return defaultValue;
            int.TryParse(o.ToString(),out v);
            return v;
        }
        #endregion
        /// <summary>
        /// 对象为null或空时返回defaultValue，如果不为null，则返回对象的decimal
        /// </summary>
        /// <param name="o"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static decimal ObjToDecimal(this object o,decimal defaultValue)
        {
            if(o==null)
                return defaultValue;
            string s = ObjectToString(o);
            try
            {
                decimal v = decimal.Parse(s);
                return v;
            }
            catch { return defaultValue; }
           
        }
        /// <summary>
        /// 对象转decimal。对象为null或空时返回decimal类型的0，如果不为null，则返回对象decimal类型的值
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static decimal ObjToDecimal(this object o)
        {
            return ObjToDecimal(o, 0);

        }
        /// <summary>
        /// 将数组转成以特定符号间隔的字符串
        /// </summary>
        /// <param name="par">要转化的数组</param>
        /// <param name="f">间隔符</param>
        /// <returns></returns>
        public static string ToString(this string[] par, char f)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in par)
            {
                sb.Append(s + f);
            }
            if (sb.Length > 1)
                return sb.Remove(sb.Length, 1).ToString();
            return "";
        }
        /// <summary>
        /// 生成webservice的key
        /// </summary>
        /// <returns></returns>
        public static string MakeWebServiceKey()
        {
            Uri url = HttpContext.Current.Request.Url;
            string host = url.Host;
            return (host.ToLower().ToMD5()+"|"+DateTime.Now.Ticks.ToString()).EncryptStr("A#b3");            
        }

        /// <summary>
        /// 对象为null或空时返回defaultValue，如果不为null，则返回对象的整数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DateTime ObjToDate(string _value, DateTime defaultValue)
        {
            DateTime s = defaultValue;
            try { s = DateTime.Parse(_value); }
            catch { }
            return s;
        }


        /// <summary>
        /// 获得传入对象的值(返回双浮点型)
        /// </summary>
        /// <param name="_value">传入的值</param>
        /// <param name="defaultValue">如果没有获取到 返回该默认值</param>
        /// <returns></returns>
        public static double GetobjectToSingle(object _value, double defaultValue)
        {
            if (_value == null)
                return defaultValue;
            return GetStringToSingle(_value.ToString(), defaultValue);
        }



        public static double GetStringToSingle(string _value, double defaultValue)
        {
            double num;
            if (!double.TryParse(_value, out num))
            {
                num = defaultValue;
            }
            return num;

        }

        /// <summary>
        /// 隐藏手机号码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string HiddenPhone(string phone)
        {
            //string hiddenphone = Regex.Replace(phone, @"(.*?)[^\/]+\/$", "$1");
            //return hiddenphone;
            if (phone.Length != 11)
                return "130****0000";
            string leftphone = phone.Substring(0, 3);
            string rightphone = phone.Substring(7, 4);
            return leftphone + "****" + rightphone;
        }
    }
}
