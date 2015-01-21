/******************************************************************
* Create By:卢小阳
* Create Time:2013/4/21 22:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.NetWork.VerifyPermissions
{
    /// <summary>
    /// 权限验证类
    /// </summary>
    public class Verify
    {
        private string AllLimit = string.Empty;
        public static string AllLimitStr="";
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="Limit">当前拥有的全部权限</param>
        public Verify(string Limit)
        {
            this.AllLimit = Limit;
        }
        /// <summary>
        /// 验证控件权限（Enabled）
        /// </summary>
        /// <param name="control"></param>
        /// <param name="VerifyLimitCode"></param>
        public void VerifyControl(System.Windows.Forms.Control control, string VerifyLimitCode)
        {
            control.Enabled = AllLimit.IndexOf(VerifyLimitCode) > -1;
        }
        /// <summary>
        /// 验证控件权限（Enabled）扩展
        /// </summary>
        /// <param name="control">要验证的控件</param>
        /// <param name="VerifyLimitCode">当前控件所需权限</param>
        public static void VerifyThisControl(this System.Windows.Forms.Control control, string VerifyLimitCode)
        {
            if (string.IsNullOrEmpty(AllLimitStr))
                throw new Exception("使用VerifyThisControl前必须给Verify.AllLimitStr赋值！");
            control.Enabled = AllLimitStr.IndexOf(VerifyLimitCode) > -1;
        }
    }
}
