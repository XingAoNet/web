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
using System.Web.Security;

namespace XingAo.Networks.CMS.Common
{
    /// <summary>
    /// MD5加密类
    /// </summary>
    public static class MD5
    {
        #region-----------MD5加密---------------------------------------------------------
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
        /// 转成md5
        /// </summary>
        /// <param name="ToMd5Str">要转成md5的字符</param>
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
        #endregion
    }
}
