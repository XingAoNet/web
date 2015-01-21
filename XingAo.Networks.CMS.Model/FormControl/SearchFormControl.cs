using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Networks.CMS.Common;

namespace XingAo.Networks.CMS.Model
{
   public class SearchFormControl
    {
       /// <summary>
       /// 字段名
       /// </summary>
       public string FieldName { get; set; }
       /// <summary>
       /// 控件前的显示文本
       /// </summary>
       public string BeforControlText{get;set;}

       /// <summary>
       /// 表单控件类型，1单行文本框 2下拉框
       /// </summary>
       public int ControlType { get; set; }
       /// <summary>
       /// 控件要绑定数据时（表名|绑定值|绑定文本||自定义绑定文本|自定义值|自定义绑定文本2|自定义值2...）【注意，如果控件类型为FormControlTypeEnum.lookupGroup时，此处用于“查找并带回”功能所指向的链接地址，具体参看“查找并带回”控件的写法】
       /// </summary>
       public string DataBindTableTxtFieldValue { get; set; }
       /// <summary>
       /// 0不在搜索项上显示  1在普通搜索项上显示 2在高级搜索项上显示 3在普通与高级搜索项上同时显示
       /// </summary>
       public int ShowInLocation { get; set; }
       /// <summary>
       /// 操作类型，比如大于、大于等于、小于等
       /// </summary>
       public string SeachOpt { get; set; }

       ///// <summary>
       ///// 生成字符串
       ///// </summary>
       ///// <returns></returns>
       //public override string ToString()
       //{
       //    string TempLate = "<td>{0}：{1}</td>\r\n";//{0}--文本，{1}--控件
       //    switch (ShowInLocation)
       //    {
       //        case 0:
       //            return "";
       //        case 1:
       //            break;
       //        case 2:
       //            return "功能未实现";
       //        case 3:
       //            return "";
       //    }
       //    return base.ToString();
       //}
    }
}
