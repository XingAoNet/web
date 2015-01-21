/******************************************************************
* Create By:卢小阳
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Specialized;

namespace XingAo.Networks.CMS.Common
{
    /// <summary>
    /// 枚举转换类
    /// </summary>
    public static class EnumTransform
    {
        /// <summary>
        /// 根据枚举名称字符串来转换成枚举
        /// </summary>
        /// <param name="name">枚举名称字符串</param>
        /// <returns>返回枚举</returns>
        public static T FindByStringName<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name, true);
        }
        /// <summary>
        /// 根据枚举值来转换成枚举
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>返回枚举</returns>
        public static T FindByIntValue<T>(int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
        #region 扩展方法
        /// <summary>
        /// 根据枚举名称字符串来转换成枚举
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string name)
        {
            return FindByStringName<T>(name);
        }
        /// <summary>
        /// 根据枚举值来转换成枚举
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value)
        {
            return FindByIntValue<T>(value);
        }
        /// <summary>
        /// 获取枚举的描述信息（Description属性）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToEnumDescription<T>(this int value)
        {
            T t = (T)Enum.ToObject(typeof(T), value);
            return ToEnumDescription<T>(t);
        }

        /// <summary>
        /// 获取枚举的描述信息(Description属性)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToEnumDescription<T>(this T value)
        {
            Type type = typeof(T);
            MemberInfo[] memberInfo = type.GetMember(value.ToString());
            object[] o;
            if (memberInfo.Count() > 0)
            {
                o = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (o.Count() > 0)
                    return ((DescriptionAttribute)o[0]).Description;
                return string.Empty;
            }
            return string.Empty;
        }
        #endregion
        /// <summary>
        /// 取  枚举    的描述及索引值（序号从0开始）
        /// </summary>
        /// <returns></returns>
        public static NameValueCollection GetDescriptionAddValue<TEnum>()
        {
            Type type = typeof(TEnum);
            return GetDescriptionAddValue(type);
        }

        /// <summary>
        /// 取  枚举    的描述及索引值（序号从0开始）
        /// </summary>
        /// <returns></returns>
        public static NameValueCollection GetDescriptionAddValue(Type type)
        {
            NameValueCollection li = new NameValueCollection();
            foreach (FieldInfo fi in type.GetFields())
            {
                if (fi.Name.ToLower().IndexOf("value_") > -1)
                    continue;
                li.Add(
                    ((DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute), false)).Description,
                    ((int)fi.GetValue(null)).ToString()
                    );

            }
            return li;
        }
    }
}
