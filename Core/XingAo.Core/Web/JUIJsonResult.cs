/******************************************************************
* Create By:卢小阳
* Create Time:2013年8月22日15:45:44
* Update By:
*  陈成杰 2014年8月6日:重名名，将原来的OptionResultJson修改JUIJsonResult，以方便阅览
* Last Update Time:
* Update Description:
******************************************************************/
using System.Web;

namespace XingAo.Core
{
    /// <summary>
    /// JUI状态返回信息
    /// </summary>
    public static class JUIJsonResult
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
       /// <param name="msg">错误信息</param>
       /// <param name="navTabId"></param>
        public static void Err(string msg, string navTabId)
        {
            ShowMsg(msg, navTabId, StateCode.Err, string.Empty);
        }
        /// <summary>
        /// 显示成功信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="navTabId"></param>
        /// <param name="backurl"></param>
        public static void Success(string msg, string navTabId,string backurl)
        {
            ShowMsg(msg, navTabId, StateCode.Success, backurl);
        }
        public static void TimeOut(string msg, string navTabId, string backurl)
        {
            ShowMsg(msg, navTabId, StateCode.Success, backurl);
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="msg">需要显示的信息内容</param>
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
