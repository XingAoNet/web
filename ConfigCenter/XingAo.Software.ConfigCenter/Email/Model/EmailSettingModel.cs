using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Core;
using XingAo.Core.Files;
using System.ComponentModel.DataAnnotations;

namespace XingAo.Software.ConfigCenter.Email
{
    /// <summary>
    /// 邮箱设置
    /// </summary>
    [Serializable]
    public class EmailSettingModel
    {
        /// <summary>
        /// SMTP服务器
        /// </summary>
        [Display(Name = "SMTP服务器")]
        [Required(ErrorMessage = "SMTP服务器")]
        public string SMPTServer { get; set; }
        /// <summary>
        /// 发件人昵称
        /// </summary>
        [Display(Name = "发件人昵称")]
        [Required(ErrorMessage = "发件人昵称不能为空"), StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "{0}必须在{2}到{1}个字符或汉字")]
        public string SendName { get; set; }
        /// <summary>
        /// 邮箱账号
        /// </summary>
        [Display(Name = "邮箱账号")]
        [Required(ErrorMessage = "邮箱账号不能为空")]
        public string SendAccount { get; set; }
        /// <summary>
        /// 邮箱密码
        /// </summary>
        [Display(Name = "邮箱密码")]
        [Required(ErrorMessage = "邮箱密码不能为空")]
        public string SendPwd { get; set; }
        /// <summary>
        /// SMTP端口,默认端口25
        /// </summary>
        [Display(Name = "SMTP端口")]
        [Required(ErrorMessage = "SMTP端口不能为空")]
        public int SMTPPort { get; set; }
        /// <summary>
        /// 身份验证
        /// </summary>
        [Display(Name = "身份验证")]
        public bool SmtpValidation { get; set; }
    }
}
