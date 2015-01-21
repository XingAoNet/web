/******************************************************************
* Create By:卢小阳
* Create Time:2013/4/21 22:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using XingAo.NetWorks.VerifyPermissions.Enum;
using System.Collections.Specialized;
using System.ComponentModel;

namespace XingAo.NetWorks.VerifyPermissions.Utility
{
    /// <summary>
    /// 反射操作类
    /// </summary>
    public static class Reflection
    {
        /// <summary>
        /// 取类所有公共属性（要求可序列化的）
        /// </summary>
        /// <param name="NameSpace">命名空间</param>
        /// <param name="ClassName">类名</param>
        /// <returns></returns>
        public static PropertyInfo[] GetPropertyInfo(string NameSpace, string ClassName)
        {
            object obj = Assembly.Load(NameSpace).CreateInstance(NameSpace + "." + ClassName);
            PropertyInfo[] prts = obj.GetType().GetProperties();
            return prts;
        }
        /// <summary>
        /// 反射 操作权限枚举    的名称及序号（序号从0开始）
        /// </summary>
        /// <returns></returns>
        private static FieldInfo[] GetOperatingKeyValue()
        {
            FieldInfo[] KeyValue = typeof(Operating).GetFields();
            return KeyValue;
        }
        /// <summary>
        /// 取  操作权限枚举    的描述及索引值（序号从0开始）
        /// </summary>
        /// <returns></returns>
        public static NameValueCollection GetOperatingDescriptionValue()
        {
            NameValueCollection li = new NameValueCollection();
            foreach (FieldInfo fi in GetOperatingKeyValue())
            {
                if (fi.Name.ToLower().IndexOf("value_") > -1)
                    continue;
                li.Add(
                    ((int)fi.GetValue(null)).ToString(), 
                    ((DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute), false)).Description
                    );
                
            }
            return li;
        }
    }
}
