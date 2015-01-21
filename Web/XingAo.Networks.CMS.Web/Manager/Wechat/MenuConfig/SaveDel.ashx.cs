using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.MenuConfig//----------修改命名空间
{
    /// <summary>
    /// ConfigSaveDel 的摘要说明
    /// </summary>
    public class ConfigSaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_Config";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            string code = "200", msg = "提交成功！", callbackaction = "";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.WeiXin_Account model = new UnitOfWork().FindSigne<Model.WeiXin_Account>(c => c.Id == 1);
                if (model != null && model.Id > 0)
                {
                    model.AppId = context.Request.Form["txtAppId"];
                    model.AppSecret = context.Request.Form["txtAppSecret"];
                    model.AccountName= context.Request.Form["txtName"];
                    model.AccountPwd = context.Request.Form["txtPwd"];
                    model.SourceId = context.Request.Form["txtSourceId"];
                    model.WaChatName = context.Request.Form["txtChatName"];
                    model.WaChatNumber = context.Request.Form["txtChatNumber"];
                    model.WaChatHeader = context.Request.Form["txtHeader"];
                    model.QRCode = context.Request.Form["txtErWei"];
                    model.Province = context.Request.Form["TxtProvince"];
                    model.City = context.Request.Form["TxtCity"];
                    model.Address = context.Request.Form["TxtAddress"];
                    model.E_mail = context.Request.Form["txtMail"];
                    model.UserType = context.Request.Form["TxtUserType"].ObjToInt();
                    model.AccountType = context.Request.Form["RadioButAccountType"].ObjToInt();
                    model.EditTime = DateTime.Now;
                    uk.Save(model, model.Id);
                    string err = "";
                    uk.Commit(out err);
                    if (err != "")
                    {
                        code = "300";
                        msg = err;
                    }
                }
                else
                {
                    code = "300";
                    msg ="参数错误，请正常访问";
                }
            }
           
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