using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Common
{
    /// <summary>
    /// 生成编码
    /// </summary>
    public class GenericNumeric
    {
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
        /// <param name="dateTime"></param>
        /// <param name="DateFormat"></param>
        /// <param name="startNumeric"></param>
        /// <param name="IndexFormat"></param>
        /// <returns></returns>
        public static string GenericByDateTimeAddIndex(DateTime dateTime, string DateFormat, int startNumeric, string IndexFormat)
        {
            return string.Empty;
        }

        /// <summary>
        /// 通过索引标识生成编码
        /// </summary>
        /// <param name="startNumeric"></param>
        /// <param name="indexFormart"></param>
        /// <returns></returns>
        public static string GenericByIndex(int startNumeric, string indexFormart)
        {
            return string.Empty;
        }

        /// <summary>
        /// 通过时间生成编码
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="DateFormart"></param>
        /// <returns></returns>
        public static string GenericByDateTime(DateTime dateTime, string DateFormart)
        {
            return string.Empty;
        }
    }
}
