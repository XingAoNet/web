/******************************************************************
* Create By:卢小阳
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Reflection;

namespace XingAo.Core
{
    /// <summary>
    /// JSON帮助类
    /// </summary>
    public static class JSONHelper
    {
        /// <summary>
        /// 对象转JSON
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>JSON格式的字符串</returns>
        public static string ObjectToJSON(object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Serialize(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("ObjectToJSON时遇到错误: " + ex.Message);
            }
        }
         /// <summary>
        /// 对象转JSON
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>JSON格式的字符串</returns>
        public static string ToJSON(this object obj)
        {
            return ObjectToJSON(obj);
        }

       

        /// <summary>
        /// JSON文本转对象,泛型方法
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="jsonText">JSON文本</param>
        /// <returns>指定类型的对象</returns>
        public static T JSONToObject<T>(string jsonText)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Deserialize<T>(jsonText);
            }
            catch (Exception ex)
            {
                return default(T);
                throw new Exception("JSONToObject时遇到错误: " + ex.Message);
            }
        }
        /// <summary>
        /// JSON文本转对象,泛型方法
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="jsonText">JSON文本</param>
        /// <returns>指定类型的对象</returns>
        public static T JsonToObject<T>(this string jsonText)
        {
            return JSONToObject<T>(jsonText);
        }
       /// <summary>
       /// 将datatable转成list
       /// </summary>
       /// <typeparam name="T">目标对象</typeparam>
       /// <param name="dt">数据集</param>
       /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt) where T : class,new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();
            DataColumnCollection Culumns = dt.Columns;
            foreach (DataRow row in dt.Rows)
            {
                T entity = new T();
                foreach (DataColumn col in Culumns)
                {
                    PropertyInfo p = type.GetProperty(col.ColumnName);
                    if (p != null)
                    {
                        //对空值的处理
                        if (row[col.ColumnName] == System.DBNull.Value)
                            p.SetValue(entity, null, null);
                        else
                            p.SetValue(entity, row[col.ColumnName], null);
                    }
                }
                list.Add(entity);
            }
           

            //Type type = typeof(T);
            //List<T> list = new List<T>();
            //PropertyInfo[] pArray = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //foreach (DataRow row in dt.Rows)
            //{
            //    T entity = new T();
            //    foreach (PropertyInfo p in pArray)
            //    {
            //        if (row[p.Name] is Int64)
            //        {
            //            p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
            //            continue;
            //        }
            //        p.SetValue(entity, row[p.Name], null);
            //    }
            //    list.Add(entity);
            //}

            return list;
        }
        /// <summary>
        /// 将datatable转成List《Dictionary《string,object》》
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Dictionary<string,object>> ToList(this DataTable dt) 
        {
            List<Dictionary<string, object>> li = new List<Dictionary<string, object>>();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn coll in dt.Columns)
                {
                    dic.Add(coll.ColumnName, row[coll.ColumnName]);
                } 
                li.Add(dic);
            }
            return li;
        } 
    }
}

