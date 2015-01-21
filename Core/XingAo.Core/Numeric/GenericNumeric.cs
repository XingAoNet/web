/******************************************************************
* Create By:陈成杰
* Create Time:2014-07-29 01:53:08
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Core.Numeric
{
    /// <summary>
    /// 生成编码
    /// </summary>
    public class GenericNumeric
    {
        private static Dictionary<string, int> beforeIndexNumeric = new Dictionary<string, int>();

        /// <summary>
        /// 通过GUID生成编码
        /// </summary>
        /// <returns></returns>
        public static string GenericByGUID()
        {
            return new Guid().ToString();
        }

        /// <summary>
        /// 通过时间及索引标识生成编码
        /// </summary>
        /// <param name="dateTime">需要生成编码的时间</param>
        /// <param name="dateFormat">编码格式，默认为yyyyMMddhhmmss</param>
        /// <param name="startNumeric">开始索引的数字</param>
        /// <param name="indexFormat">编码方式，补充不满的位数，例如5位递增：开始编码为1，则第一次生成00001，第二次生成00002</param>
        /// <param name="indexPlaces">编码位数</param>
        /// <param name="indexIdentifying">索引标识，用于区分生成编码的唯一标识</param>
        /// <returns>返回时间及索引标识生成编码</returns>
        public static string GenericByDateTimeAddIndex(DateTime dateTime, string dateFormat, int startNumeric, char indexFormat,int indexPlaces,string indexIdentifying)
        {
            return string.Format("{0}{1}",
                GenericByDateTime(dateTime,dateFormat),
                GenericByIndex(startNumeric,indexFormat,indexPlaces,indexIdentifying));
        }
        /// <summary>
        /// 通过当前时间及默认索引标识（默认从1开始，不满位数以0补充）生成编码
        /// </summary>
        /// <param name="indexPlaces">编码位数</param>
        /// <param name="indexIdentifying">索引标识，用于区分生成编码的唯一标识</param>
        /// <returns>返回时间及索引标识生成编码</returns>
        public static string GenericByDateTimeAddIndex(int indexPlaces, string indexIdentifying)
        {
            return GenericByDateTimeAddIndex(DateTime.Now, string.Empty, 1, '0', indexPlaces, indexIdentifying);
        }

        /// <summary>
        /// 通过索引标识生成编码
        /// </summary>
        /// <param name="startNumeric">开始索引的数字</param>
        /// <param name="indexFormart">编码方式，补充不满的位数，例如5位递增：开始编码为1，则第一次生成00001，第二次生成00002</param>
        /// <param name="indexPlaces">编码位数</param>
        /// <param name="indexIdentifying">索引标识，用于区分生成编码的唯一标识</param>
        /// <returns></returns>
        public static string GenericByIndex(int startNumeric, char indexFormart,int indexPlaces, string indexIdentifying)
        {
            int beforeNumeric = 0;
            if (beforeIndexNumeric.Keys.Contains(indexIdentifying))
                beforeNumeric = beforeIndexNumeric[indexIdentifying];
            //自动加1
            int numeric = beforeIndexNumeric[indexIdentifying] = beforeNumeric + 1;
            string result = string.Empty;
            for (int i = 0; i < indexPlaces - numeric.ToString().Length; i++)
            {
               result = string.Format("{0}{1}", indexFormart, numeric);
            }
            return result;
        }

        /// <summary>
        /// 通过时间生成编码（带编码格式）
        /// </summary>
        /// <param name="dateTime">需要生成编码的时间</param>
        /// <param name="DateFormart">编码格式，默认为yyyyMMddhhmmss</param>
        /// <returns>返回时间编码</returns>
        public static string GenericByDateTime(DateTime dateTime, string DateFormart)
        {
            if (string.IsNullOrEmpty(DateFormart))
                DateFormart = "yyyyMMddhhmmss";
            return dateTime.ToString(DateFormart);
        }
        /// <summary>
        /// 通过时间生成编码
        /// </summary>
        /// <param name="dateTime">需要生成编码的时间</param>
        /// <returns>返回时间编码</returns>
        public static string GenericByDateTime(DateTime dateTime){ return GenericByDateTime(dateTime, string.Empty);}
        /// <summary>
        /// 生成当前时间编码（Now）
        /// </summary>
        /// <returns>返回时间编码</returns>
        public static string GenericByDateTime() { return GenericByDateTime(DateTime.Now); }

    }
}
