/******************************************************************
* Create By:陈成杰
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Web.Security;

namespace XingAo.Core
{
    /// <summary>
    /// MD5加密类
    /// </summary>
    public static class MD5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="ToMd5Str">要加密的字符</param>
        /// <returns>经MD5加密后的字符</returns>
        public static string MakeMD5(string ToMd5Str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(ToMd5Str, "MD5");
        }
        /// <summary>
        /// 转成MD5
        /// </summary>
        /// <param name="ToMd5Str">要转成MD5的字符</param>
        /// <returns>转成md5</returns>
        public static string ToMD5(this string ToMd5Str)
        {
            return MakeMD5(ToMd5Str);
        }
        /// <summary>
        /// 两次MD5加密
        /// </summary>
        /// <param name="ToMd5Str">要加密的字符</param>
        /// <returns>经再次MD5加密后的字符</returns>
        public static string MakeMD5Two(string ToMd5Str)
        {
            return MakeMD5(MakeMD5(ToMd5Str));
        }
        /// <summary>
        /// 两次MD5加密
        /// </summary>
        /// <param name="ToMd5Str">要加密的字符</param>
        /// <returns>两次MD5加密</returns>
        public static string ToMD5Two(this string ToMd5Str)
        {
            return MakeMD5Two(ToMd5Str);
        }
        /// <summary>
        /// N次MD5加密，当N为0时，不做加密处理
        /// </summary>
        /// <param name="ToMd5Str">要加密的字符</param>
        /// <param name="n">加密次数</param>
        /// <returns>MD5加密后的字符</returns>
        public static string ToMD5(this string ToMd5Str, UInt16 n)
        {
            string result = ToMd5Str;
            for (int i = 0; i < n; i++)
            {
                result = MakeMD5(result);
            }
            return result;
        }
    }
}