using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using System.Text;

namespace XingAo.Networks.CMS.Web.Manager.Advertising.AD//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_ADV";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.Advertising model;
                if (id > 0)
                    model = uk.FindSigne<Model.Advertising>(p => p.ID == id);
                else
                {
                    model = new Model.Advertising();
                    model.JsFile = "/upload/AdJS/"+DateTime.Now.Ticks.ToString()+".js";
                }
                model.GroupID = context.Request.Form["txtGroupID"].ObjToInt();
                model.Html = context.Request.Form["txtHtml"];
                model.ShowType = context.Request.Form["txtShowType"].ObjToInt();
                model.Title = context.Request.Form["txtTitle"];
                StringBuilder json = new StringBuilder("[{");
                foreach (string s in context.Request.Form.AllKeys)
                {
                    if (s.IndexOf("JsonPar_") >= 0)
                    {
                        json = json.Replace("||", ",");
                        json.AppendLine("\""+s.Replace("JsonPar_","")+"\":\""+context.Request.Form[s]+"\"||");
                    }
                }
                json = json.Replace("||", "");
                model.ParametersJson=json.ToString()+"}]";
                if (id > 0)
                    uk.Update(model);
                else
                    uk.Insert(model);
                string JsTemplate = "";
                switch (model.ShowType)
                {
                    case 0://普通 
                        if (context.Request.Form["outputCk"] == "on")
                            JsTemplate = "document.write('" + model.Html.Replace("\r\n", "").Replace("'", "\'") + "');";
                        else
                            JsTemplate = model.Html;
                        break;
                    case 1://固定浮动式
                        JsTemplate = string.Format(FileOption.ReadFile("左侧固定位置可关闭广告模板.js"), model.Html, model.JsFile.Replace("/upload/AdJS/", "").Replace(".js", ""), model.ParametersJson);
                        break;
                    case 2://全屏漂浮
                        JsTemplate = string.Format(FileOption.ReadFile("全屏飘浮.js"), model.Html, model.JsFile.Replace("/upload/AdJS/", "").Replace(".js", ""), model.ParametersJson);
                        break;
                }
                FileOption.WriteFile(model.JsFile, JsTemplate.Replace("｛", "{").Replace("｝", "}"), false);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                foreach(Model.Advertising m in uk.LoadWhereLambda<Model.Advertising>(p => ID.Contains(p.ID.ToString())))
                {
                    FileOption.DelFile(m.JsFile);
                }
                uk.Remove<Model.Advertising>(p => ID.Contains(p.ID.ToString()));

            }
            string err = "";
            uk.Commit(out err);
            if (err != "")
            {
                code = "300";
                msg = err;
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