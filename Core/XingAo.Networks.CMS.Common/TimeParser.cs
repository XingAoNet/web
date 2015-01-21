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

namespace XingAo.Networks.CMS.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class TimeParser
    {
        /// <summary>
        /// 把秒转换成分钟
        /// </summary>
        /// <returns></returns>
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));           
        }

        #region 返回某年某月最后一天
        /// <summary>
        /// 返回某年某月最后一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>日</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int Day = lastDay.Day;
            return Day;
        }
        #endregion

        #region 返回时间差
        /// <summary>
        /// DateDiff返回值枚举
        /// </summary>
        public enum DateDiffType
        {
            /// <summary>
            /// 返回毫秒
            /// </summary>
            Milliseconds,
            /// <summary>
            /// 返回秒
            /// </summary>
            Seconds,
            /// <summary>
            /// 返回分钟
            /// </summary>
            Minutes,
            /// <summary>
            /// 返回小时
            /// </summary>
            Hours,
            /// <summary>
            /// 返回天
            /// </summary>
            Days,
            /// <summary>
            /// 返回年
            /// </summary>
            Years
        }
        /// <summary>
        /// 取两个时间的时间差
        /// </summary>
        /// <param name="DateTime1">要比较的时间</param>
        /// <param name="DateTime2">被比较的时间</param>
        /// <param name="datedifftype">返回值类型枚举</param>
        /// <returns></returns>
        public static double DateDiff(DateTime DateTime1, DateTime DateTime2, DateDiffType datedifftype)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2);
            switch ((int)datedifftype)
            {
                case 0:
                    return ts.TotalMilliseconds;
                case 1:
                    return ts.TotalSeconds;
                case 2:
                    return ts.TotalMinutes;
                case 3:
                    return ts.TotalHours;
                case 4:
                    return ts.TotalDays;
                case 5:
                    return ts.TotalDays / 365;
            }
            return -987654321;
        }
        /// <summary>
        /// 取两个时间的时间差(返回秒)
        /// </summary>
        /// <param name="DateTime1">要比较的时间</param>
        /// <param name="DateTime2">被比较的时间</param>
        /// <returns></returns>
        public static double DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            return DateDiff(DateTime1, DateTime2, DateDiffType.Seconds);
        }
        /// <summary>
        /// 取两个时间的时间差(返回秒)
        /// </summary>
        /// <param name="DateTime1">要比较的时间</param>
        /// <param name="DateTime2">被比较的时间</param>
        /// <returns></returns>
        public static double GetDateDiff(this DateTime DateTime1, DateTime DateTime2)
        {
            return DateDiff(DateTime1, DateTime2, DateDiffType.Seconds);
        }
        #endregion
    }
}
