using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using XingAo.Networks.WeChat;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.CustomMenu//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        string navTabId = "WechatMenus";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            Model.ManagerUserCookiesModel loginUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
            string action = context.Request.QueryString["action"];
            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "create":
                        #region
                        List<Model.CustomMenu> menu = uk.FindAll<Model.CustomMenu>().Where(c => c.WGuid == "" && c.CanUse == 1).OrderBy(c => c.OrderID).ToList();
                        StringBuilder menuJosn = new StringBuilder();
                        List<Model.CustomMenu> Itemmenu;
                        foreach (Model.CustomMenu m in menu.Where(c=>c.ParentID==0).OrderBy(c=>c.OrderID))
                        {
                            Itemmenu = menu.Where(c => c.ParentID == m.ID).ToList();
                            if (Itemmenu.Count > 0)
                            {
                                StringBuilder menuItemJosn = new StringBuilder();
                                foreach (Model.CustomMenu im in Itemmenu)
                                    menuItemJosn.Append("{\"type\":\"" + (im.MenuType == "click" ? "click" : "view") + "\",\"name\":\"" + im.Name + "\"," + (im.MenuType == "click" ? "\"key\":\"" + im.Keys + "\"" : "\"url\":\"" + im.KeysText + "\"") + "},");

                                menuJosn.Append("{\"name\":\"" + m.Name + "\",\"sub_button\":[" + menuItemJosn.ToString().Trim(',') + "]},");
                            }
                            else
                                menuJosn.Append("{\"type\":\"" + (m.MenuType == "click" ? "click" : "view") + "\",\"name\":\"" + m.Name + "\"," + (m.MenuType == "click" ? "\"key\":\"" + m.Keys + "\"" : "\"url\":\"" + m.KeysText + "\"") + "},");
                           
                        }
                        string postJosn="{\"button\":[" + menuJosn.ToString().Trim(',') + "]}";

                        Model.WeiXin_Account Account=uk.FindSigne<Model.WeiXin_Account>(c => c.Id == 1);
                        AccessToken acccktoken = ActionOption.AccessToken(Account.AppId, Account.AppSecret).JsonToObject<AccessToken>();
                        string resutl=string.Empty;
                        HttpHelper.HttpPost("https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + acccktoken.access_token, postJosn, EncodeFormat.EF_UTF8, out resutl);
                        HttpMessage hm = resutl.JsonToObject<HttpMessage>();
                        code = hm.errcode;
                        msg = hm.errmsg;
                        callbackaction = "";
                        #endregion
                        break;
                    case "del":
                        #region
                        msg = "删除成功！";
                        callbackaction = "";
                        string[] ID = context.Request.Form["ids"].Split(',');
                        uk.Remove<Model.CustomMenu>(p => ID.Contains(p.ID.ToString()));
                        #endregion
                        break;
                    default:
                        #region
                        Model.CustomMenu mode;
                        if (id > 0)
                            mode = uk.FindSigne<Model.CustomMenu>(p => p.ID == id);
                        else
                        {
                            mode = new Model.CustomMenu();
                            mode.IDateTime = DateTime.Now;
                            mode.Creater = loginUser.RealName;
                            mode.WGuid = "";
                        }
                        mode.ParentID = context.Request.Form["txtPID"].ObjToInt(0);
                        mode.OrderID = context.Request.Form["txtOrderID"].ObjToInt(0);
                        mode.Name = context.Request.Form["txtName"];
                        mode.Keys = context.Request.Form["txtKeys"];
                        mode.KeysText = context.Request.Form["txtKeys_text"];
                        mode.Source = context.Request.Form["txtSource"];
                        mode.MenuType = context.Request.Form["MenuType"];
                        mode.CanUse = context.Request.Form["IsUse"] == "on" ? 1 : 0;
                        mode.EditTime = DateTime.Now;
                        mode.Editer = loginUser.RealName;
                        uk.Save(mode, mode.ID);
                        #endregion
                        break;
                }
                string err = "";
                uk.Commit(out err);
                if (err != "")
                {
                    code = "300";
                    msg = err;
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
