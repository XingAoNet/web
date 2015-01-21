using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.WeChat
{
    public class SensitiveUtil
    {
        public static string CheckSensitive(string Content)
        {
            return Content
                .Replace("抢", "*")
                .Replace("二手车", "二 手 车")
                .Replace("抢", "*")
                .Replace("偷", "*")
                .Replace("蒋", "*")
                .Replace("功", "*")
                .Replace("妈的", "*")
                .Replace("匯總", "*")
                .Replace("公关", "*")//   （这个是不能用，要换词）
                .Replace("按摩", "*")//   （这个是不能用，要换词）
                .Replace("贷款", "*")//   （这个是不能用，要换词）
                .Replace("加贷", "*")
                .Replace("机票", "*")
                .Replace("优惠", "优/惠")//   （加空格不行，要加斜杠）
                .Replace("特惠", "特/惠")
                .Replace("移动", "移 动")
                .Replace("自由", "自 由")
                .Replace("政府", "政 府")
                .Replace("美女", "美 女")
                .Replace("酒店", "酒 店")
                .Replace("家居", "家 居")
                .Replace("假发", "假 发")
                .Replace("暴力", "暴 力")
                .Replace("强迫", "强 迫")
                .Replace("绝版", "绝 版")
                .Replace("大片", "大 片")
                .Replace("宝来", "宝 来")
                .Replace("反对", "反 对")
                .Replace("限制", "限 制")
                .Replace("庄家", "庄 家")
                .Replace("医生", "医 生")
                .Replace("公安", "公 安")
                .Replace("顶级", "顶 级")
                .Replace("A级", "A 级")
                .Replace("三级", "三 级")
                .Replace("间行", "间 行")
                .Replace("母子", "母 子")
                .Replace("换购", "换 购")
                .Replace("丝袜", "丝 袜")
                .Replace("钱达", "钱 达")
                .Replace("圆满", "圆 满")
                .Replace("平方", "平 方")
                .Replace("铁路", "铁 路")
                .Replace("折扣", "折 扣")
                .Replace("套现", "套 现")
                .Replace("人大", "人 大")
                .Replace("辅导", "辅 导")
                .Replace("装修", "装 修")
                .Replace("长虹", "长 虹")
                .Replace("旺铺", "旺 铺")
                .Replace("放款", "放 款")
                .Replace("加推", "加 推")
                .Replace("房款", "房 款")
                .Replace("首付", "首 付")
                .Replace("陈军", "陈 军")
                .Replace("朱琳", "朱 琳")
                .Replace("何平", "何 平")
                .Replace("刘青", "刘 青")
                .Replace("程真", "程 真")
                .Replace("王丹", "王 丹")
                .Replace("重庆", "重 庆")
                .Replace("日本", "日 本")
                .Replace("韩国", "韩 国")
                .Replace("国务院", "国 务 院")
                .Replace("生活馆", "生 活 馆")
                .Replace("葡萄酒", "葡 萄 酒")
                .Replace("写字楼", "写 字 楼")
                .Replace("售楼处", "售 楼 处")
                .Replace("想知道", "想 知 道")
                .Replace("芦荟胶", "芦 荟 胶")
                .Replace("价格低", "价 格 低")
                .Replace("本公司", "本 公 司")
                .Replace("一对一", "一 对 一")
                .Replace("限量版", "限 量 版")
                .Replace("养生馆", "养 生 馆")
                .Replace("养生会馆", "*")//（这个是不能用，要换词）
                .Replace("换购活动", "换 购 活 动")
                .Replace("中心广场", "中 心 广 场")
                .Replace("火热报名", "火 热 报 名")
                .Replace("凭此短信", "凭短信")//（凭短信）
                .Replace("抵押业务", "抵 押 业 务")
                .Replace("价格优惠", "价 格 优 惠")
                .Replace("预约热线", "预 约 热 线")
                .Replace("预约电话", "电话")
                .Replace("换购活动", "换 购 活 动")
                .Replace("更多优惠", "更 多 优 惠")
                .Replace("开始报名", "开 始 报 名")
                .Replace("售完即止", "售 完 即 止")
                .Replace("欢迎预订", "欢 迎 预 订")
                .Replace("卡号：62", "会员卡：62")
                .Replace("咨询热线：40", "咨询热线：")
                .Replace("64", "6 4")
                .Replace("133", "13 3")//    （改成13 3）
                .Replace("131", "13 1") //     （改成13 1）
                .Replace("130 ", "13 0")  //   （改成13 0）
                .Replace("1978", "1 9 7 8")//     （改成1 9 7 8）
                .Replace("vip", "Vip") // （改成Vip）
                .Replace("VIP", "Vip")
                .Replace("sm", "Sm")
                .Replace("hz", "Hh z")
                .Replace("详情请致电", "详情 请致电")
                .Replace("有好礼相送", "有好 礼相送")
                .Replace("快乐大作文", "快乐 大作文")
                .Replace("欢迎新老客户光临", "欢迎 新老客户 光临")
                .Replace("探盘", "探 盘")
                .Replace("平米", "平 米")
                .Replace("品质精装豪宅", "品质 精装豪宅")
                .Replace("样板房", "样板 房")
                .Replace("公馆", "公 馆")
                .Replace("楼盘", "楼 盘");

        }
    }
}
