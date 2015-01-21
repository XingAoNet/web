using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XingAo.Networks.CMS.Model
{
    /// <summary>
    /// 表单数据验证枚举
    /// </summary>
   public enum DataValidationEnum
    {
       /// <summary>
        /// 不验证
       /// </summary>
       [Description("不验证")]
       none,

       #region class属性验证
       /// <summary>
       /// 必填
       /// </summary>
       [Description("必填")]
       required_class,
       /// <summary>
       /// 手机
       /// </summary>
       [Description("手机")]
       phone_class,
       /// <summary>
       /// 邮箱
       /// </summary>
       [Description("邮箱")]
       email_class,
       /// <summary>
       /// 网址
       /// </summary>
       [Description("网址")]
       url_class,
       /// <summary>
       /// 字母、数字、下划线
       /// </summary>
       [Description("字母、数字、下划线")]
       alphanumeric_class,
       /// <summary>
       /// 整数
       /// </summary>
       [Description("整数")]
       digits_class,
       /// <summary>
       /// 浮点数
       /// </summary>
       [Description("浮点数")]
       number_class,
       /// <summary>
       /// 字母
       /// </summary>
       [Description("字母")]
       lettersonly_class,
       /// <summary>
       /// 日期
       /// </summary>
       [Description("日期")]
       date_class,
       #endregion

       #region 其它属性上的验证
       /// <summary>
       /// 最小值
       /// </summary>
       [Description("最小值")]
       min_attr,
       /// <summary>
       /// 最大值
       /// </summary>
       [Description("最大值")]
       max_attr,
       /// <summary>
       /// 最小长度
       /// </summary>
       [Description("最小长度")]
       minlength_attr,
       /// <summary>
       /// 最大长度
       /// </summary>
       [Description("最大长度")]
       maxlength_attr,
       /// <summary>
       /// 远程验证（比如用户名是否重复）
       /// </summary>
       [Description("远程验证")]
       remote_attr,
       /// <summary>
       /// 与某控件相等（比如重复密码时）
       /// </summary>
       [Description("与某控件相等")]
       equalto_attr
       #endregion
    }
}
