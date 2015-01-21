using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.WeChat;


namespace XingAo.Networks.CMS.Web.Manager.Wechat.WeiXin//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext hc)
        {
            string action = hc.Request.Params["action"];
            bool send = false;
            int ID = hc.Request.Params["ID"].ObjToInt();
            if (ID > 0)
            {
                UnitOfWork uk = new UnitOfWork();
                Model.WeiXin_Account model = uk.FindSigne<Model.WeiXin_Account>(c => c.Id == ID);
                if (model != null)
                {
                    LoginInfo login = ActionOption.GetToken(model.AccountName, model.AccountPwd);
                    if (!string.IsNullOrEmpty(action))//添加或修改
                    {
                        switch (action)
                        {
                            case "text":
                                string Msg = hc.Request.Params["Msg"];
                                string fakeids = hc.Request.Params["fakeid"];
                                if (!string.IsNullOrEmpty(fakeids))
                                {
                                    foreach (string fakeid in fakeids.Trim(',').Split(','))
                                    {
                                        if (!string.IsNullOrEmpty(fakeid))
                                            send = ActionOption.SendMessage(login, Msg, fakeid);
                                    }
                                }
                                
                                break;
                        }
                        hc.Response.Write(send ? "成功" : "失败");
                        hc.Response.End();
                    }
                }
            }

            hc.Response.Write("未登记用户");
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