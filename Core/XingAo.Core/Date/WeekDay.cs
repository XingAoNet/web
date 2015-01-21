/******************************************************************
* Create By:卢小阳
* Create Time:2013年8月22日15:48:21
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using XingAo.Core;

namespace XingAo.Core
{
   public static class WeekDay
    {
       /// <summary>
       /// 将数字返回成为中文星期x
       /// </summary>
       /// <param name="day">0为星期天</param>
       /// <returns></returns>
       public static string Int2Chinese(int day)
       {
           switch (day)
           {
               case 0:
                   return "星期天";
               case 1:
                   return "星期一";
               case 2:
                   return "星期二";
               case 3:
                   return "星期三";
               case 4:
                   return "星期四";
               case 5:
                   return "星期五";
               case 6:
                   return "星期六";
               default:
                   throw new Exception("错误参数,星期只能从0-6之间进行转换!");
           }
       }
       /// <summary>
       /// 将数字返回成为中文星期x
       /// </summary>
       /// <param name="day">0为星期天</param>
       /// <returns></returns>
       public static string Int2Chinese(string day)
       {
           if (day.IsNumber())
               return Int2Chinese(int.Parse(day));
           throw new Exception("参数类型错误!必须是0-6的数字才能被转成中文的星期");
       }
       /// <summary>
       /// 将数字转成中文星期几
       /// </summary>
       /// <param name="day">0-6之间的数字，0为星期天</param>
       /// <returns></returns>
       public static string ToChineseWeekDay(this int day)
       {
           return Int2Chinese(day);
       }
       /// <summary>
       /// 将中文星期转成为数字,星期天为0
       /// </summary>
       /// <param name="week">星期xxx</param>
       /// <returns></returns>
       public static int Chinese2Int(string week)
       {
           switch (week)
           {
               case "星期天":
                   return 0; 
               case "星期一":
                   return 1;
               case "星期二":
                   return 2;
               case "星期三":
                   return 3;
               case "星期四":
                   return 4;
               case "星期五":
                   return 5;
               case "星期六":
                   return 6;
               case "星期日":
                   return 0;
               default:
                   throw new Exception("错误参数!");
           }
       }

       /// <summary>
       /// 取指定的日期是在那一年里的第几周
       /// </summary>
       /// <param name="dtime">日期</param>
       /// <returns>第几周</returns>
       public static int GetWeekOfYear(DateTime dtime)
       {
           DateTime tmpdate = DateTime.Parse(dtime.ToString("yyyy-01-01"));
          return (dtime.DayOfYear + 6 + (int)tmpdate.DayOfWeek) / 7;
       }
       /// <summary>
       /// 取指定的日期是在那一年里的第几周
       /// </summary>
       /// <param name="dtime"></param>
       /// <returns></returns>
       public static int WeekOfYear(this DateTime dtime)
       {
           return GetWeekOfYear(dtime);
       }
    }
}
