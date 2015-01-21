using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.WeChat;
using System.Text;
using System.Net;
using System.IO;

namespace XingAo.Networks.CMS.Web.Manager.Wechat//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "Nav_Weixin";//----------修改标签ID
        public void ProcessRequest(HttpContext hc)
        {
            string action = hc.Request.QueryString["action"];
           
            string code = "200", msg = "提交成功！", callbackaction = "";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {

                int ID = hc.Request.Form["txtID"].ObjToInt();
                Model.WeiXin_Account model = uk.FindSigne<Model.WeiXin_Account>(c => c.Id == ID);
                if (model != null)
                {
                    string ck = hc.Request.Form["sendMenu"];
                    string pwd = hc.Request.Form["txtPwd"];
                    model.AccountName = hc.Request.Form["txtName"];
                    if (!string.IsNullOrEmpty(pwd))
                        model.AccountPwd = hc.Request.Form["txtPwd"];
                    model.AppId = hc.Request.Form["txtAppId"];
                    model.AppSecret = hc.Request.Form["txtAppSecret"];
                    model.IsUse = hc.Request.Form["ckIsUse"]=="on"?1:0;
                    model.MenuJson = hc.Request.Form["txtMenuJosn"];
                    if (ck == "on")
                    {
                        LoginInfo login = ActionOption.GetToken(model.AccountName, model.AccountPwd);
                        AccessToken acccktoken = ActionOption.AccessToken(model.AppId, model.AppSecret).JsonToObject<AccessToken>();
                        string result = postWebReq("https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + acccktoken.access_token, model.MenuJson, Encoding.UTF8);
                    }
                }
                uk.Save(model, model.Id);

            }

            string err = "";
            uk.Commit(out err);
            if (err != "")
            {
                code = "300";
                msg = err;
            }
            hc.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
        }


        static string postWebReq(string postUrl, string paramData, Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData);
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteArray.Length;

                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();

                HttpWebResponse reponse = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(reponse.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                
                sr.Close();
                reponse.Close();
                newStream.Close();


            }
            catch
            {
                
            }
            return ret;
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