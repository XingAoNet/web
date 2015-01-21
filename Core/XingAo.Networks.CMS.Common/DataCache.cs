/******************************************************************
* Create By:卢小阳
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using XingAo.Core;

namespace XingAo.Networks.CMS.Common
{
    /// <summary>
    /// 缓存相关的操作类
    /// </summary>
    public static class DataCache
    {
        #region 缓存类型枚举
        /// <summary>
        /// 缓存类型枚举
        /// </summary>
        public enum DataCacheType
        {
            /// <summary>
            /// 默认缓冲
            /// </summary>
            Default,
            /// <summary>
            /// 网站模板缓冲
            /// </summary>
            TempLate,
            /// <summary>
            /// 网站导航条缓冲
            /// </summary>
            Menu,
            /// <summary>
            /// 网站面包宵缓冲
            /// </summary>
            SiteMap,
            /// <summary>
            /// 栏目属性缓冲
            /// </summary>
            ColumnAttExchange,
            /// <summary>
            /// 首页页面缓冲
            /// </summary>
            IndexPage,
           /// <summary>
            ///数据操作 实体对象内容缓村的时间
           /// </summary>
            DataBaseOptModel,
            /// <summary>
            /// WebConfig内的AppSetting
            /// </summary>
            AppSetting,
            /// <summary>
            /// 用户自定义表，tid转成表名
            /// </summary>
            TidToTableName,
            /// <summary>
            /// 所有标签缓存
            /// </summary>
            AllLabels,
            /// <summary>
            /// 用户自定义标签
            /// </summary>
            CustomLable,
            /// <summary>
            /// 微信菜单
            /// </summary>
            WeChatMenu

        }
        #endregion

       private static System.Web.Caching.Cache objCache = HttpRuntime.Cache;
       
        #region get
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {

            return objCache[CacheKey.ToLower()];
        }
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="cachetype">缓存类别枚举</param>
        /// <returns></returns>
        public static object GetCache(string CacheKey, DataCacheType cachetype)
        {

            return objCache[cachetype.ToString().ToLower() + ":" + CacheKey.ToLower()];
        }
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static string GetCacheString(string CacheKey)
        {
            return GetCache(CacheKey.ToLower()).ObjToStr();
        }
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值(不存在时返回空)
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="cachetype">缓存类别枚举</param>
        /// <returns></returns>
        public static string GetCacheString(string CacheKey, DataCacheType cachetype)
        {
            return GetCache(CacheKey.ToLower(), cachetype).ObjToStr();
        }
        #endregion
        
        #region set 普通方法

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {

            objCache.Insert(CacheKey.ToLower(), objObject);
        }
        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">键</param>
        /// <param name="objObject">值</param>
        /// <param name="datacachetype">类型</param>
        public static void SetCache(string CacheKey, object objObject, DataCacheType datacachetype)
        {

            objCache.Insert(datacachetype.ToString().ToLower() + ":" + CacheKey.ToLower(), objObject);
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">键</param>
        /// <param name="objObject">值</param>
        /// <param name="absoluteExpiration">对象缓存在什么时间移除(建议使用DateTime.UtcNow而不是DateTime.Now)</param>
        /// <param name="slidingExpiration">最后一次访问所插入对象时与该对象到期时之间的时间间隔。如果该值等效于 20 分钟，则对象在最后一次被访问 20 分钟之后将到期并被从缓存中移除。TimeSpan.Zero则忽视此时间间隔</param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {

            objCache.Insert(CacheKey.ToLower(), objObject, null, absoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">键</param>
        /// <param name="objObject">值</param>
        /// <param name="timeout">几分钟后失效</param>
        public static void SetCache(string CacheKey, object objObject, int timeout)
        {

            objCache.Insert(CacheKey.ToLower(), objObject, null, DateTime.UtcNow.AddMinutes(timeout), TimeSpan.Zero);
        }
        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey">键</param>
        /// <param name="objObject">值</param>
        /// <param name="timeout">几分钟后失效</param>
        /// <param name="datacachetype">缓冲类型枚举</param>
        public static void SetCache(string CacheKey, object objObject, int timeout, DataCacheType datacachetype)
        {

            objCache.Insert(datacachetype.ToString().ToLower() + ":" + CacheKey.ToLower(), objObject, null, DateTime.UtcNow.AddMinutes(timeout), TimeSpan.Zero);
        }
        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="absoluteExpiration">对象缓存在什么时间移除(建议使用DateTime.UtcNow而不是DateTime.Now)</param>
        /// <param name="slidingExpiration">最后一次访问所插入对象时与该对象到期时之间的时间间隔。如果该值等效于 20 分钟，则对象在最后一次被访问 20 分钟之后将到期并被从缓存中移除。TimeSpan.Zero则忽视此时间间隔</param>
        /// <param name="datacachetype">缓冲类型枚举</param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration, DataCacheType datacachetype)
        {

            objCache.Insert(datacachetype.ToString().ToLower() + ":" + CacheKey.ToLower(), objObject, null, absoluteExpiration, slidingExpiration);
        }

        #endregion


        #region set 扩展方法

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="objObject">要设置成缓存的对象</param>
        /// <param name="CacheKey"></param>
        /// <param name="datacachetype">缓存类型枚举</param>
        public static void SetCache(this object objObject,string CacheKey, DataCacheType datacachetype)
        {

            objCache.Insert(datacachetype.ToString().ToLower() + ":" + CacheKey.ToLower(), objObject);
        }        

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="objObject">要设置成缓存的对象</param>
        /// <param name="CacheKey"></param>
        /// <param name="datacachetype">缓存类型枚举</param>
        public static void SetCache(this object objObject, string CacheKey,int timeout, DataCacheType datacachetype)
        {

            objCache.Insert(datacachetype.ToString().ToLower() + ":" + CacheKey.ToLower(), objObject, null, DateTime.Now.AddMinutes(timeout), TimeSpan.Zero);
        }

        #endregion


        #region 清除缓存
        /// <summary>
        /// 清除缓冲
        /// </summary>
        /// <param name="_type">缓存类型</param>
        /// <param name="CacheID">缓存id</param>
        public static void RemoveCache(DataCacheType _type, string CacheID)
        {

            objCache.Remove(_type.ToString().ToLower() + ":" + CacheID.ToLower());
        }
        /// <summary>
        /// 清除指定类型的缓冲
        /// </summary>
        /// <param name="_type">缓存类型</param>
        public static void RemoveCache(DataCacheType _type)
        {
            
            ArrayList al = new ArrayList();
            IDictionaryEnumerator CacheEnum = objCache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                if (CacheEnum.Key.ToString().ToLower().StartsWith(_type.ToString().ToLower() + ":"))
                    al.Add(CacheEnum.Key.ToString().ToLower());
            }
            foreach (string s in al)
            {
                objCache.Remove(s);
            }
        }
        /// <summary>
        /// 清除缓冲
        /// </summary>
        /// <param name="key">缓冲键值</param>
        public static void RemoveCache(string key)
        {

            objCache.Remove(key.ToLower());
        }
        /// <summary>
        /// 清除所有缓冲
        /// </summary>
        public static void RemoveAllCache()
        {
            ArrayList al = new ArrayList();
           
            IDictionaryEnumerator CacheEnum = objCache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                // AddCache(CacheEnum.Key.ToString(), "", 1);
                al.Add(CacheEnum.Key.ToString().ToLower());
            }
            foreach (string s in al)
            {
                objCache.Remove(s);
            }
        }      
        


        #endregion
        /// <summary>
        /// 取所有缓存
        /// </summary>
        /// <returns></returns>
        public static IList<CacheModel> GetCacheList()
        {
           
            //要循环访问 Cache 对象的枚举数
            IDictionaryEnumerator enumerator = objCache.GetEnumerator();//检索用于循环访问包含在缓存中的键设置及其值的字典枚举数
            if (enumerator != null)
            {
                IList<CacheModel> li = new List<CacheModel>();
                while (enumerator.MoveNext())
                {
                    if (!enumerator.Key.ToString().StartsWith("__") && enumerator.Key.ToString() != "CDKey")
                        li.Add(new CacheModel(enumerator.Key.ToString(), enumerator.Value.ToString()));
                    //_cache.Remove(enumerator.Key.ToString());
                }
                return li;
            }
            return null;
        }
        /// <summary>
        /// 取所有缓存对象模型
        /// </summary>
        public class CacheModel
        {
            public CacheModel(string n, string v)
            {
                CacheName = n; Value = v;
            }
            /// <summary>
            /// 键
            /// </summary>
            public string CacheName
            { get; set; }
            /// <summary>
            /// 值
            /// </summary>
            public string Value
            { get; set; }
        }

    }
    
}
