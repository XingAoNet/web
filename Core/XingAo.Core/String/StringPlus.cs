using System.Collections.Generic;
using System.Text;

namespace XingAo.Core
{
    /// <summary>
    /// 字符串分割、拼接类
    /// </summary>
    public class StringPlus
    {
        /// <summary>
        /// 将内容按特定字符分割成List＜string＞并排除空项
        /// </summary>
        /// <param name="str">要分割的字符串</param>
        /// <param name="speater">分割符</param>
        /// <param name="toLower">是否转成小写</param>
        /// <returns></returns>
        public static List<string> GetStrArray(string str, char speater,bool toLower)
        {
            List<string> list = new List<string>();
            string[] ss =  str.Split(speater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) &&s !=speater.ToString())
                {
                    string strVal = s;
                    if (toLower)
                    {
                        strVal = s.ToLower();
                    }
                    list.Add(strVal);
                }
            }
            return list;
        }
        /// <summary>
        /// 将字符串按,分割成字符串数组
        /// </summary>
        /// <param name="str">要分割的字符串</param>
        /// <returns></returns>
        public static string[] GetStrArray(string str)
        {
            return str.Split(new char[',']);
        }
        /// <summary>
        /// 拼接字符串
        /// </summary>
        /// <param name="list">要拼接的集合</param>
        /// <param name="speater">间隔符</param>
        /// <returns></returns>
        public static string GetArrayStr(List<string> list,string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }
            return sb.ToString();
        }
        
        
        #region 删除最后一个字符之后的字符

        /// <summary>
        /// 删除最后结尾的一个逗号及之后的字符
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns></returns>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }

        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="strchar">分割符</param>
        /// <returns></returns>
        public static string DelLastChar(string str,string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }

        #endregion




        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">要转换的字符串</param>
        /// <returns></returns>
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }        

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        /// <param name="input">要转换的字符串</param>
        /// <returns></returns>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        /// <summary>
        /// 将内容按特定字符分割成List＜string＞
        /// </summary>
        /// <param name="o_str">要分割的内容</param>
        /// <param name="sepeater">分割符</param>
        /// <returns></returns>
        public static List<string> GetSubStringList(string o_str, char sepeater)
        {
            List<string> list = new List<string>();
            string[] ss = o_str.Split(sepeater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != sepeater.ToString())
                {
                    list.Add(s);
                }
            }
            return list;
        }

    }
}
