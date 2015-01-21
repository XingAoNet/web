using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.AutoReply//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_Reply";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.ManagerUserCookiesModel LogonUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
                Model.WeiXin_Reply mode;
                if (id > 0)
                    mode = uk.FindSigne<Model.WeiXin_Reply>(p => p.Id == id);
                else
                {
                    mode = new Model.WeiXin_Reply();
                    mode.IDateTime = DateTime.Now;
                    mode.Creater = LogonUser.RealName;
                }
                mode.Title = context.Request.Form["txtTitle"];
                mode.ReplyKey = context.Request.Form["txtReplyKey"];
                mode.Description = context.Request.Form["txtDescription"];

                mode.PicUrl = context.Request.Form["txtPicUrl"];
                mode.Url = context.Request.Form["txtUrl"];
                mode.ReplyContent = context.Request.Form["txtReplyContent"];
                mode.EditTime = DateTime.Now;
                mode.Editer = LogonUser.RealName;
                uk.Save(mode, mode.Id);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.WeiXin_Reply>(p => ID.Contains(p.Id.ToString()));

            }
            string err = "";
            uk.Commit(out err);
            if (err != "")
            {
                code = "300";
                msg = err;
            }
            else
                WxToken.Replys = null;
            context.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}