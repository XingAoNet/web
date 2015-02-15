using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using XingAo.Core;

namespace XingAo.Software.UserCenter
{
    public interface IMobileBindAdmin
    {
        /// <summary>
        /// 用户老手机已经不用了，没法从前台验证老手机，后台绕过老手机验证，新手机验证继续走前台流程
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="adminId"></param>
        /// <param name="adminName"></param>
        /// <param name="remark"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result SkipCurrentMobileValidate(string userId, string adminId, string adminName, string remark, Hashtable options);

        /// <summary>
        /// 用户短信收不到的情况下后台人工绑定
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="mobile"></param>
        /// <param name="adminId"></param>
        /// <param name="adminName"></param>
        /// <param name="remark"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Result BindMobile(string userId, string mobile, string adminId, string adminName, string remark, Hashtable options);
    }
}
