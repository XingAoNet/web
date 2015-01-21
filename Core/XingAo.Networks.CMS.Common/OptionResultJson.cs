/******************************************************************
* Create By:卢小阳
* Create Time:2013年8月22日15:45:44
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace XingAo.Networks.CMS.Common
{
    /// <summary>
    /// JUI状态返回信息
    /// </summary>
    public static class OptionResultJson
    {
        /// <summary>
        /// 结果状态
        /// </summary>
        public enum StateCode
        {
            /// <summary>
            /// 成功
            /// </summary>
            Success=200,
            /// <summary>
            /// 失败
            /// </summary>
            Err=300,
            /// <summary>
            /// 会话超时
            /// </summary>
            TimeOut=301
        }
       /// <summary>
       /// 显示错误信息
       /// </summary>
       /// <param name="errmsg"></param>
       /// <param name="navTabId"></param>
        public static void Err(string errmsg, string navTabId)
        {
            errmsg = errmsg.Replace("\r\n", "").Replace("[", "［").Replace("]", "］").Replace("\"", "＂").Replace("\r", "").Replace("\n", "");
            HttpContext.Current.Response.ClearContent();
           HttpContext.Current.Response.Clear();
           HttpContext.Current.Response.Write("{\"statusCode\":\"300\",\"message\":\"" + errmsg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
           HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 显示成功信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="navTabId"></param>
        /// <param name="backurl"></param>
        public static void Success(string msg, string navTabId,string backurl)
        {
            msg = msg.Replace("\r\n", "").Replace("[", "［").Replace("]", "］").Replace("\"", "＂").Replace("\r", "").Replace("\n", "");
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("{\"statusCode\":\"200\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"\",\"forwardUrl\":\"" + backurl + "\",\"confirmMsg\":\"\"}");
        }
        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="navTabId"></param>
        /// <param name="state"></param>
        /// <param name="backurl"></param>
        public static void ShowMsg(string msg, string navTabId,StateCode state, string backurl)
        {
            msg = msg.Replace("\r\n", "").Replace("[", "［").Replace("]", "］").Replace("\"", "＂").Replace("\r", "").Replace("\n", "");
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.ClearHeaders();
            System.Web.HttpContext.Current.Response.Write("{\"statusCode\":\"" + ((int)state).ToString() + "\",\"message\":\"" + msg + "\",\"navTabId\":\"\",\"callbackType\":\"\",\"forwardUrl\":\"" + backurl + "\"}");
            System.Web.HttpContext.Current.Response.End();
        }
    }
}
