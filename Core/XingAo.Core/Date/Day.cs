/******************************************************************
* Create By:卢小阳
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;

namespace XingAo.Core
{
    public static class Day
    {
        /// <summary>
        /// 将0-2的数字转成为上午/下午/全天
        /// </summary>
        /// <param name="apm">0-2的数字</param>
        /// <returns></returns>
        public static string Int2ChineseAmPm(int apm)
        {
            switch (apm)
            {
                case 0:
                    return "上午";
                case 1:
                    return "下午";
                case 2:
                    return "全天";
                default:
                    throw new Exception("只能使用0-2之间的数字才能被转成中文的上下午或全天");
            }
        }
        /// <summary>
        /// 将上午/下午/全天转成为数字
        /// </summary>
        /// <param name="apm">上午/下午/全天</param>
        /// <returns></returns>
        public static int ChineseAmPm2Int(string apm)
        {
            switch (apm)
            {
                case "上午":
                    return 0;
                case "下午":
                    return 1;
                case "全天":
                    return 2;
                default:
                    throw new Exception("只能使用:上午/下午/全天");
            }
        }
    }
}
