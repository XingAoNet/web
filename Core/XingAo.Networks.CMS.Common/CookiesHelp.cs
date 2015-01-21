using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Web.UI;
using XingAo.Core;

namespace XingAo.Networks.CMS.Common
{
    public class CookiesHelp
    {
       

        /// <summary>
        /// 添加cookies
        /// </summary>
        /// <param name="CookiesName">cookies名称</param>
        /// <param name="KeyValues">键值对</param>
        /// <param name="TimeOut">几分钟超时,0为浏览器关闭就超时</param>
        /// <param name="Encrypt">是否将cookies值加密</param>
        /// <param name="Path">与当前cookies一起传输的虚拟路径</param>
        public static void AddUsersCookies<T>(string CookiesName, T uc, int TimeOut, bool Encrypt, string Path)
        {
             HttpCookie c ;
             if (HttpContext.Current.Request.Cookies.AllKeys.Contains(CookiesName))
                 c = HttpContext.Current.Request.Cookies[CookiesName];
             else
                 c = new HttpCookie(CookiesName);
             foreach (string s in HttpContext.Current.Request.Cookies.AllKeys)
             {
                 if (s.StartsWith(CookiesName))
                     HttpContext.Current.Request.Cookies.Remove(s);
             }
             if (ConfigHelper.GetConfigString("SiteUrl").ToLower().Trim() != "")//为方便跨域，cookies全部使用主域名（不带http://www.）来保存有效域
             {
                 if (HttpContext.Current.Request.Url.ObjToStr().ToLower().StartsWith("http://localhost"))
                 {
                     //int port = HttpContext.Current.Request.Url.Port;
                     //if (port == 80)
                     //    c.Domain = "localhost";
                     //else
                     //    c.Domain = "localhost:"+port.ToString();

                 }
                 else
                 {
                     Regex reg = new Regex(@"^(http:\/\/)?(\w|-)+\.", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                     c.Domain = reg.Replace(ConfigHelper.GetConfigString("SiteUrl").ToLower().Trim(), "");
                 }
             }
            c.Path = Path;
            
            string value = uc.ToJSON();
            if (Encrypt)
                value = value.EncryptStr();
            int Count = (value.Length + 3999) / 4000;//分成多少个cookies来存储
            if (Count > 20)
            {
                throw new Exception("您存储的Cookies内容太长，分段存储都已超过20个Cookies！（一个网站最多只能存储20个Cookies），请删除部分无关紧要的Cookies值");
                return;
            }
            c.Values["Count"] = Count.ToString();            
            HttpContext.Current.Response.Cookies.Clear();
            for (int i = 0; i < Count; i++)//开始处理cookies内容太多导致无法保存问题
            {
                HttpCookie SubCookies = new HttpCookie(CookiesName + "_" + i.ToString());
                string SubValue = "";
                if (i + 1 == Count)
                    SubValue = value.Substring(i * 4000);
                else
                    SubValue = value.Substring(i * 4000,4000);
                SubCookies.Values["value"] = SubValue;
                SubCookies.Values["Sign"] = SubValue.ToMD5().EncryptStr().ToMD5();
                SubCookies.Domain = c.Domain;
                if (TimeOut > 0)
                {
                    SubCookies.Expires = DateTime.Now.AddMinutes(TimeOut);
                }
                HttpContext.Current.Response.Cookies.Add(SubCookies);
            }
            if (Count == 1)
                c.Values["Value"] = value; 
            c.Values["AddTime"] = DateTime.Now.ToString();
            
            if (TimeOut > 0)
            {
                c.Expires = DateTime.Now.AddMinutes(TimeOut);               
            }
            c.Values["Sign"] = (value + c.Values["AddTime"]).EncryptStr().ToMD5Two();
            HttpContext.Current.Response.Cookies.Add(c);
        }



        /// <summary>
        /// 添加cookies(加密数据并在浏览器关闭就失效)
        /// </summary>
        /// <param name="CookiesName">cookies名称</param>
        /// <param name="uc">存入cookies内的实体对象</param>
        public static void AddUsersCookies<T>(string CookiesName, T uc)
        {
            AddUsersCookies<T>(CookiesName, uc, 0, true, "/");
        }
        /// <summary>
        /// 添加cookies(加密数据并在浏览器关闭就失效)
        /// </summary>
        /// <param name="CookiesName">cookies名称</param>
        /// <param name="uc">存入cookies内的实体对象</param>
        public static void AddUsersCookies<T>(CookiesNameEnum CookiesName, T uc)
        {
            AddUsersCookies<T>(CookiesName.ToString(), uc, 0, true, "/");
        }
        /// <summary>
        /// 添加cookies
        /// </summary>
        /// <param name="CookiesName">cookies名称</param>
        /// <param name="KeyValues">键值对</param>
        /// <param name="TimeOut">几分钟超时,0为浏览器关闭就超时</param>
        /// <param name="Encrypt">是否将cookies值加密</param>
        /// <param name="Path">与当前cookies一起传输的虚拟路径</param>
        public static void AddUsersCookies<T>(CookiesNameEnum CookiesName, T uc, int TimeOut, bool Encrypt, string Path)
        {
            AddUsersCookies<T>(CookiesName.ToString(), uc, TimeOut, Encrypt, Path);
        }
        
        /// <summary>
        /// 添加网站后台cookies(加密数据并在浏览器关闭就失效)[以Manager作为Cookies的key]
        /// </summary>
        /// <param name="KeyValues">键值对</param>
        /// <param name="TimeOut">几分钟超时,0为浏览器关闭就超时</param>
        /// <param name="Encrypt">是否将cookies值加密</param>
        /// <param name="Path">与当前cookies一起传输的虚拟路径</param>
        public static void AddUsersCookies<T>( T uc)
        {
            AddUsersCookies<T>("Manager", uc, 0, true, "/");
        }
       
        /// <summary>
        /// 取cookies
        /// </summary>
        /// <param name="CookiesName">cookies名称</param>
        /// <param name="Decrypt">是否要解密</param>
        /// <returns></returns>
        public static T GetUsersCookies<T>(string CookiesName, bool Decrypt)
        {
            try
            {
                HttpCookie c = HttpContext.Current.Request.Cookies[CookiesName];                
                if (c != null )
                {
                    int Count = c.Values["Count"].ObjToInt(0);
                    string MainCookiesSign=c.Values["Sign"];
                    string value = "";
                    if (Count == 1)
                    {
                        value = c.Values["value"];
                    }
                    else
                    {
                        for (int i = 0; i < Count; i++)
                        {
                            HttpCookie SubCookies = HttpContext.Current.Request.Cookies[CookiesName + "_" + i.ToString()];
                            string SubValue = SubCookies.Values["value"];
                            string Sign = SubCookies.Values["Sign"];
                            if (SubValue.ToMD5().EncryptStr().ToMD5() == Sign)
                            {
                                value += SubValue;
                            }
                            else
                                return default(T);
                        }
                    }
                    if ((value + c.Values["AddTime"]).EncryptStr().ToMD5Two() == MainCookiesSign)
                    {
                        if (Decrypt)
                            value = value.DecryptStr();
                        return value.JsonToObject<T>();
                    }
                    return default(T);                                      
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return default(T);
        }

        /// <summary>
        /// 取cookies
        /// </summary>
        /// <param name="CookiesName">cookies名称枚举</param>
        /// <param name="Decrypt">是否要解密</param>
        /// <returns></returns>
        public static T GetUsersCookies<T>(CookiesNameEnum CookiesName, bool Decrypt)
        {
            return GetUsersCookies<T>(CookiesName.ToString(), Decrypt);
        }
        /// <summary>
        /// 取cookies并解密
        /// </summary>
        /// <param name="CookiesName">cookies名称</param>
        /// <returns></returns>
        public static T GetUsersCookies<T>(string CookiesName)
        {
            return GetUsersCookies<T>(CookiesName, true);
        }
        /// <summary>
        /// 取cookies并解密
        /// </summary>
        /// <param name="CookiesName">cookies名称枚举</param>
        /// <returns></returns>
        public static T GetUsersCookies<T>(CookiesNameEnum CookiesName)
        {
            return GetUsersCookies<T>(CookiesName.ToString(), true);
        }

        
        /// <summary>
        /// 取网站后台cookies并解密（以Manager作为Cookies的key）
        /// </summary>
        /// <param name="CookiesName">cookies名称</param>
        /// <returns></returns>
        public static T GetUsersCookies<T>()
        {
            return GetUsersCookies<T>("Manager", true);
        }
        /// <summary>
        /// 验证是否登录
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="CookiesName">Cookies名称</param>
        /// <param name="loginUser">如果已登录则返回此登录用户信息的实体对象</param>
        /// <returns></returns>
        public static bool IsLogin<T>(string CookiesName, out T loginUser)
        {
            loginUser = GetUsersCookies<T>(CookiesName);            
            foreach (PropertyInfo Property in typeof(T).GetProperties())
            {
                try
                {
                    if (Property.Name.ToLower() == "id")
                    {
                        string value = loginUser.GetType().GetProperty(Property.Name).GetValue(loginUser, null).ObjToStr();
                        return int.Parse(value) > 0;
                    }
                }
                catch
                { }
            }            
            return false;
        }
        /// <summary>
        /// 验证是否登录
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="CookiesName">Cookies名称枚举</param>
        /// <param name="loginUser">如果已登录则返回此登录用户信息的实体对象</param>
        /// <returns></returns>
        public static bool IsLogin<T>(CookiesNameEnum CookiesName, out T loginUser)
        {
            return IsLogin<T>( CookiesName.ToString(), out loginUser);
        }
        /// <summary>
        /// 验证是否登录（未登录时弹出alert框，确定后转向首页）
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="page">当前页面</param>
        /// <param name="CookiesName">Cookies名称枚举</param>
        /// <param name="loginUser">如果已登录则返回此登录用户信息的实体对象</param>
        /// <returns></returns>
        public static bool VerifyLogin<T>(Page page, CookiesNameEnum CookiesName, out T loginUser)
        {
            bool logined = IsLogin<T>(CookiesName.ToString(), out loginUser);
            if (!logined)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "unlogin", "alert('您还未登录或登录超时,请登录后再操作！');window.location='/UserCenter/UnLogin?url=" + System.Web.HttpContext.Current.Server.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "';", true);
            }
            return logined;
        }
        /// <summary>
        /// 验证是否登录
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="CookiesName">Cookies名称枚举</param>
        /// <returns></returns>
        public static bool IsLogin<T>(CookiesNameEnum CookiesName)
        {
           T loginUser=default(T);
            return IsLogin<T>(CookiesName.ToString(), out loginUser);
        }
        /// <summary>
        /// 删除cookies
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="CookiesName">Cookies名称枚举</param>
        public static void RemoveCookies<T>(CookiesNameEnum CookiesName)
        {
             HttpCookie c = HttpContext.Current.Request.Cookies[CookiesName.ToString()];
             if (c != null)
             {
                 int Count = c.Values["Count"].ObjToInt(0);
                 HttpContext.Current.Response.Cookies.Remove(CookiesName.ToString());
                 HttpContext.Current.Response.Cookies[CookiesName.ToString()].Expires = DateTime.Now.AddDays(-1);
                 for (int i = 0; i < Count; i++)
                 {
                     HttpContext.Current.Response.Cookies.Remove(CookiesName.ToString() + "_" + i.ToString());
                     HttpContext.Current.Response.Cookies[CookiesName.ToString() + "_" + i.ToString()].Expires = DateTime.Now.AddDays(-1);
                 }
             }
        }
        /// <summary>
        /// cookies名称枚举
        /// </summary>
        public enum CookiesNameEnum
        {
            /// <summary>
            /// 网站后台cookies
            /// </summary>
            Manager,
            /// <summary>
            /// 网站前台cookies
            /// </summary>
            WebUser
        }
    }
}