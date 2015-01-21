using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.DataShare//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_DataShare";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            UnitOfWork uk = new UnitOfWork();
            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.DataShare mode ;
                if (id <= 0)
                {
                    mode = new Model.DataShare();
                    mode.ID = 0;
                }
                else
                    mode = uk.FindSigne<Model.DataShare>(p => p.ID == id);
                mode.Fields = context.Request.Form["txtFields"];
                mode.MethodName = context.Request.Form["txtMethodName"];
                mode.MethodType = context.Request.Form["txtMethodType"].ObjToInt();
                mode.OrderBy = context.Request.Form["txtOrderBy"];
                mode.Tables = context.Request.Form["txtTables"];
                mode.WhereStr = context.Request.Form["txtWhereStr"];
                mode.Descriptions = context.Request.Form["txtDescriptions"];
                if (uk.LoadWhereLambda<Model.DataShare>(p => p.ID != mode.ID && p.MethodName == mode.MethodName).Count() == 0)
                {
                    if (mode.ID > 0)
                        uk.Update(mode);
                    else
                        uk.Insert(mode);
                    string err;
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
                    msg = mode.MethodName+"已存在！";
                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ids = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.DataShare>(p=>ids.Contains(p.ID.ToString()));
                string err;
                uk.Commit(out err);
                if (err!="")
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