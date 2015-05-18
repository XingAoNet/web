using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Core.Web
{
    /// <summary>
    /// 返回JUI的消息信息模块
    /// </summary>
    public class MsgResultModel
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string navTabId { get; set; }
        /// <summary>
        /// callbackType如果是closeCurrent就会关闭当前tab
        /// </summary>
        public string callbackType { get; set; }
        /// <summary>
        /// 只有callbackType="forward"时需要forwardUrl值
        /// </summary>
        public string forwardUrl { get; set; }
        public string confirmMsg { get; set; }
        public string rel { get; set; }
    }
    /// <summary>
    /// 返回JUI的消息信息
    /// </summary>
    public static class MsgResult
    {
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="navTabId"></param>
        /// <returns></returns>
        public static MsgResultModel Success(string msg, string navTabId)
        {
            return ShowResult(msg, 200, navTabId, "", "", "", "");
        }
        /// <summary>
        /// 返回成功的消息并关闭当前对话框
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="navTabId"></param>
        /// <returns></returns>
        public static MsgResultModel SuccessAndClosedDailog(string msg, string navTabId)
        {
            return ShowResult(msg, 200, navTabId, "", "closeCurrent", "", "");
        }
        public static MsgResultModel SuccessAndClosedDailog(string msg, string navTabId, string forwardUrl)
        {
            return ShowResult(msg, 200, navTabId, "", "closeCurrent", forwardUrl, "");
        }
        /// <summary>
        /// 返回错误消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="navTabId"></param>
        /// <returns></returns>
        public static MsgResultModel Error(string msg, string navTabId)
        {
            return ShowResult(msg, 300, navTabId, "", "", "", "");
        }
        /// <summary>
        /// 登录超时消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static MsgResultModel LogOnTimeOut(string msg, string url)
        {
            return ShowResult(msg, 301, url, "", "", "", "");
        }
        /// <summary>
        /// 显示完整的消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="statsCode"></param>
        /// <param name="id"></param>
        /// <param name="rel"></param>
        /// <param name="callbackType"></param>
        /// <param name="forwardUrl"></param>
        /// <param name="confirmMsg"></param>
        /// <returns></returns>
        public static MsgResultModel ShowResult(string msg, int statsCode, string navTabId, string rel, string callbackType, string forwardUrl, string confirmMsg)
        {
            return new MsgResultModel() { message = msg, statusCode = statsCode, navTabId = navTabId, rel = rel, callbackType = callbackType, forwardUrl = forwardUrl, confirmMsg = confirmMsg };
        }
    }
}
