using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 自定义表-列表页生成时每个字段属性设置 实体
    /// </summary>
   public class ListFormControl
    {
       /// <summary>
       /// 表头要显示的文字
       /// </summary>
       public string DisplayTitleText { get; set; }
       /// <summary>
       /// 字段名称
       /// </summary>
       public string FieldName { get; set; }
       /// <summary>
       /// 表头宽度
       /// </summary>
       public string TitleWidth { get; set; }
       /// <summary>
       /// 表头对方方式
       /// </summary>
       public string Align { get; set; }
       /// <summary>
       /// 数据项对齐方式
       /// </summary>
       public string DataItemAlign { get; set; }
       /// <summary>
       /// 绑定链接，如：＜ａ　ｈｒｅｆ＝＇ｘｘｘ．ａｓｐｘ？ｉｄ＝{ID}＆Cｌａｓｓ＝{CｌａｓｓID}＇＞{０}＜／ａ＞　　　{０}将会被替换成当前字段的内容，如果为空则显示此字段真实值或转义值，具体是否显示转义得看DisplayValue属性的值
       /// </summary>
       public string HrefLink { get; set; }
       /// <summary>
       /// 对此字段值进行转义，例如｛０｝＝＝１？“是”：“否”　如果为空则不转义【注意：只支持三目运算符来转义,同时带有转义与格式化时，格式化优先执行】
       /// </summary>
       public string DisplayValue { get; set; }
       /// <summary>
       /// 格式化【注意：同时带有转义与格式化时，格式化优先执行】
       /// </summary>
       public string Format { get; set; }

       
    }
}
