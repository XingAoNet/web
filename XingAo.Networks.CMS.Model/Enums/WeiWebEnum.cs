using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model.Enums
{
    public class WeiWebEnum
    {
        public static string TypeSwitch(int type)
        {
            switch (type)
            {
                case 0:
                    return "完全匹配";
                case 1:
                    return "部分匹配";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 0、报名活动；1、文本回复；2、图文回复；3、LBS回复；4、官网；5、大转盘；6、刮刮卡
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string TableNameSwitch(int type)
        {
            switch (type)
            {
                case 0:
                    return "Activities";
                case 1:
                    return "TextMaterial";
                case 2:
                    return "ImageMaterial";
                case 3:
                    return "LbsMaterial";
                case 4:
                    return "WeiWebsite";
                case 5:
                    return "BigWheel";
                case 6:
                    return "ScratchCard";
                default:
                    return "";
            }
        }

        public enum TableName
        {
            /// <summary>
            /// 报名活动
            /// </summary>
            Activities = 0,
            /// <summary>
            /// 文本回复
            /// </summary>
            TextMaterial = 1,
            /// <summary>
            /// 图文回复
            /// </summary>
            ImageMaterial = 2,
            /// <summary>
            /// LBS回复
            /// </summary>
            //LbsMaterial = 3,
            ScratchCard=4

        }

        public enum Matching
        {
            /// <summary>
            /// 单行文本框
            /// </summary>
            [Description("完全匹配")]
            Perfectly = 0,
            /// <summary>
            /// 部分匹配
            /// </summary>
            [Description("部分匹配")]
            Partial = 1
        }

        /// <summary>
        /// 1、开启；0、关闭
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string StateSwitch(int type)
        {
            switch (type)
            {
                case 0:
                    return "关闭";
                case 1:
                    return "开启";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 1、服务号；0、订阅号
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string AcountTypeSwitch(int type)
        {
            switch (type)
            {
                case 0:
                    return "订阅号";
                case 1:
                    return "服务号";
                case 2:
                    return "订阅号（已认证）";
                default:
                    return "";
            }
        }
    }

    // 摘要:
    //     操作权限实体接口
    public interface IOperatingInfo
    {
        //
        // 摘要:
        //     具体操作
        XingAo.Networks.CMS.Model.Enums.WeiWebEnum.Matching Match { get; set; }
    }

    public class OperatingInfo : IOperatingInfo
    {
        public XingAo.Networks.CMS.Model.Enums.WeiWebEnum.Matching Match
        {
            get;
            set;
        }
    }
}
