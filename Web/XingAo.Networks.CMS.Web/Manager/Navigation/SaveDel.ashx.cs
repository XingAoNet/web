using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Navigation//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_Navigation";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            DataCache.RemoveCache(DataCache.DataCacheType.Menu);
            DataCache.RemoveCache(DataCache.DataCacheType.ColumnAttExchange);
            int id = context.Request.Form["ID"].ObjToInt();
            UnitOfWork uk = new UnitOfWork();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            if (!string.IsNullOrEmpty(action))//添加或修改
            {

                Model.WebNavigation model = new Model.WebNavigation();
                model.ID = context.Request.Form["txtID"].ObjToInt(0);
                int pid = context.Request.Form["txtPID"].ObjToInt();
                model.EName = context.Request.Form["txtEName"];
                model.IndexTemplate = context.Request.Form["txtIndexTemplate"].ObjToInt();
                model.InfoTemplate = context.Request.Form["txtInfoTemplate"].ObjToInt();
                model.ListTemplate = context.Request.Form["txtListTemplate"].ObjToInt();
                model.Name = context.Request.Form["txtName"];
                model.OutLink = context.Request.Form["txtOutLink"];
                model.Pic = context.Request.Form["txtPic"];
                model.PicHover = context.Request.Form["txtPicHover"];
                model.SearchEngineDescription = context.Request.Form["txtSearchEngineDescription"];
                model.SearchEngineKeyWords = context.Request.Form["txtSearchEngineKeyWords"];
                model.ShowInLeftNavigation = context.Request.Form["txtShowInLeftNavigation"].ObjToInt();
                model.ShowInTopNavigation = context.Request.Form["txtShowInTopNavigation"].ObjToInt();
                model.Target = context.Request.Form["txtTarget"];
                Dictionary<string, object> par = new Dictionary<string, object>();
                par.Add("ID", model.ID);
                par.Add("Name", model.Name);
                par.Add("EName", model.EName);
                par.Add("Pic", model.Pic);
                par.Add("PicHover", model.PicHover);
                par.Add("IndexTemplate", model.IndexTemplate);
                par.Add("ListTemplate", model.ListTemplate);
                par.Add("InfoTemplate", model.InfoTemplate);
                par.Add("OutLink", model.OutLink);
                par.Add("Target", model.Target);
                par.Add("ShowInTopNavigation", model.ShowInTopNavigation);
                par.Add("ShowInLeftNavigation", model.ShowInLeftNavigation);
                par.Add("SearchEngineKeyWords", model.SearchEngineKeyWords);
                par.Add("SearchEngineDescription", model.SearchEngineDescription);
                par.Add("Pid", pid);
                string errmsg = uk.ExecuteScalar("Pro_SaveWebNavigation", par).ObjToStr();
                if (errmsg != "ok")
                {
                    code = "300";
                    msg = errmsg.Split('|')[1];
                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string IDs = context.Request.Form["ids"];
                uk.Remove<Model.WebNavigation>(p => IDs.Split(',').Contains(p.ID.ToString()));
                //uk.Remove<Model.>
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