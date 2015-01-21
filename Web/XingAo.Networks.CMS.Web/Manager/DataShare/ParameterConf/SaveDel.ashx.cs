using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.DataShare.ParameterConf//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "ParameterConfnavTab";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            UnitOfWork uk=new UnitOfWork();
            int id = context.Request.Form["txtID"].ObjToInt();
            
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                int DataShareID = context.Request["txtDataShareID"].ObjToInt();
                Model.DataShare_ParameterConfig mode;
                if (id > 0)
                    mode = uk.FindSigne<Model.DataShare_ParameterConfig>(p => p.ID == id);
                else
                {
                    mode = new Model.DataShare_ParameterConfig();
                    mode.ID = 0;
                }
                mode.AllowEmpty=context.Request["txtAllowEmpty"].ObjToInt();
                mode.DataType=context.Request["txtDataType"];
                mode.Operators = context.Request["txtOperators"];

                mode.DataShareID =DataShareID;
                mode.FieldName = context.Request.Form["txtFieldName"];
                mode.ParameterName = context.Request.Form["txtParameterName"];
                if (mode.ID > 0)
                    uk.Update(mode);
                else
                    uk.Insert(mode);
               
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
               
                string[] IDs = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.DataShare_ParameterConfig>(p=>IDs.Contains(p.ID.ToString()));               

            }
             string ErrMsg = "";
            uk.Commit(out ErrMsg);
            if (ErrMsg!="")
            {
                code = "300";
                msg = ErrMsg;
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