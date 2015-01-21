using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Collect//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "nav_collect";//----------修改标签ID
        public void ProcessRequest(HttpContext hc)
        {
            string action = hc.Request.QueryString["action"];

            int id = hc.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            Model.Collect mode;
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
               
                if (id > 0)
                    mode = uk.FindSigne<Model.Collect>(p => p.Id == id);
                else
                {
                    mode = new Model.Collect();
                    mode.CollectId = System.Guid.NewGuid().ToString("N");
                }
                mode.IsUse = hc.Request.Form["CkUse"] == "on" ? 1 : 0;
                mode.Name = hc.Request.Form["txtName"];
                mode.Url = hc.Request.Form["txtUrl"];
                mode.StartTime = hc.Request.Form["txtTime"];
                mode.Expression = hc.Request.Form["txtReg"];
                mode.InsertTable = hc.Request.Form["TableDropDown"];
                mode.ContentExpression = hc.Request.Form["txtContentReg"];
                uk.Save(mode,mode.Id);

                string pames = hc.Request.Form["items"];
                string itemsReg = hc.Request.Form["itemsReg"];
                string itemsField = hc.Request.Form["org.FiledName"];
                string defaultVal = hc.Request.Form["defaultVal"];
                if (!string.IsNullOrEmpty(pames))
                {
                    uk.Remove<Model.Collect_Pattern>(p => p.CollectId == mode.CollectId);
                    Model.Collect_Pattern Pattern;
                    string[] items = pames.Split(',');
                    string[] exs = itemsReg.Split(',');
                    string[] Fields = itemsField.Split(',');
                    string[] defaultVals = defaultVal.Split(',');
                    for (int i = 0; i < items.Length; i++)
                    {
                        Pattern = new Model.Collect_Pattern();
                        Pattern.CollectId = mode.CollectId;
                        Pattern.ParamName = items[i];
                        Pattern.Expression = exs[i];
                        Pattern.InsertField = Fields[i];
                        Pattern.DefaultValue = defaultVals[i];
                        uk.Save(Pattern, Pattern.Id);
                    }
                }
               

            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] IDs = hc.Request.Form["ids"].Split(',');
                foreach (Model.Collect g in uk.FindByFunc<Model.Collect>(c => IDs.Contains(c.Id.ToString())).ToList())
                {
                    uk.Remove(g, false);
                    uk.Remove<Model.Collect_Pattern>(c => c.CollectId == g.CollectId, false);
                }
            }
            string err = "";
            uk.Commit(out err);
            if (err != "")
            {
                code = "300";
                msg = err;
            }
            XingAo.Networks.CMS.Web.Global.collects = null;
            hc.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
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