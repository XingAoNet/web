/******************************************************************
* Create By:卢小阳
* Create Time:2013-8-22 15:45:52
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections;
using System.Reflection;

namespace XingAo.Core
{
    public static class ReflectionOpt
    {
        private static Hashtable ht = new Hashtable();
        /// <summary>
        /// 反射调用（调用前会先给这个类的属性赋值）
        /// </summary>
        /// <param name="NameSpace">根命名空间</param>
        /// <param name="ClassName">类名(带完整命名空间的)</param>
        /// <param name="MethodName">要调用的方法名</param>
        /// <param name="Params">给属性赋值的  值数组或将每个值作为参数输入，如果没有属性则为null</param>
        /// <returns></returns>
        public static object GetMethodResult(string NameSpace, string ClassName, string MethodName, params string[] Params)
        {
            object obj;
            if (ht.Contains(ClassName))
                obj = (object)ht[ClassName];
            else
            {
                obj = Assembly.Load(NameSpace).CreateInstance(ClassName);
                if (obj != null)
                    ht.Add(ClassName, obj);
            }
            PropertyInfo[] prts = obj.GetType().GetProperties();
            if (Params != null)
            {
                int PropertiesLen = prts.Length;
                if (Params.Length < PropertiesLen)
                    PropertiesLen = Params.Length;
                for (int i = 0; i < PropertiesLen; i++)
                {
                    prts[i].SetValue(obj, Convert.ChangeType(Params[i], prts[i].PropertyType), null);
                    // HttpContext.Current.Response.Write(prts[i].Name + "    " + ((System.ComponentModel.DescriptionAttribute)prts[i].GetCustomAttributes(false)[0]).Description + "<br />");

                }
            }
            try
            {
                MethodInfo methodEntity = obj.GetType().GetMethod(MethodName);
                if (prts.Length > 0)
                {
                    return methodEntity.Invoke(obj,null);
                }
                else
                    return methodEntity.Invoke(obj,Params);
            }
            catch (Exception err)
            {
                return err.Message;
            }
            // HttpContext.Current.Response.Write("Add=" + objectResulutEntity.ToString() + "<br>");
        }

        #region-----------动态调用--------------------------------------------------------

        /// <summary>
        /// 动态调用方法,调用举例：Profile_String("CommClass", "CommClass", "MakeMD5", new object[] {"2222"})+"<br />");Response.Write(Profile_String("CommClass", "CommClass", "MakeMD5", new object[] { });
        /// </summary>
        /// <param name="Namespace">命名空间</param>
        /// <param name="Lib">类名</param>
        /// <param name="Methods">方法名</param>
        /// <param name="parametors">参数，无参时用new object[] { }</param>
        /// <returns></returns>
        public static string GetStaticMethodResult(string Namespace, string Lib, string Methods, Object[] parametors)
        {            
            object curObj = Assembly.Load(Namespace).CreateInstance(Lib);
            Type t = curObj.GetType();
            Type[] ts;
            if (parametors == null)
                ts = new Type[0];
            else
                ts = new Type[parametors.Length];
            try
            {
                if (parametors != null)
                {
                    for (int i = 0; i < parametors.Length; i++)
                    {
                        ts[i] = parametors[i].GetType();
                    }

                    MethodInfo me = t.GetMethod(Methods, ts);
                    object obj = me.Invoke(curObj, parametors);
                    return obj.ToString();

                }
                else
                {
                    MethodInfo me = t.GetMethod(Methods, System.Type.EmptyTypes);
                    return (string)me.Invoke(curObj, null);
                }
            }
            catch (Exception err)
            {
                return err.Message;
                //return "执行" + Methods + "方法时出现异常！";
                // return "执行" + Methods + "()方法时出现异常！" + err.ToString().Replace("\r\n", "<br>");
            }
        }
        #endregion

        /// <summary>
        /// 取类所有公共属性（要求可序列化的）
        /// </summary>
        /// <param name="NameSpace">命名空间</param>
        /// <param name="ClassName">类名</param>
        /// <returns></returns>
        public static PropertyInfo[] GetPropertyInfo(string NameSpace, string ClassName)
        {
            object obj;
            if (ht.Contains(NameSpace + "." + ClassName))
                obj = (object)ht[NameSpace + "." + ClassName];
            else
                obj = Assembly.Load(NameSpace).CreateInstance(NameSpace + "." + ClassName);
            PropertyInfo[] prts = obj.GetType().GetProperties();
            return prts;
        }       
    }
}
