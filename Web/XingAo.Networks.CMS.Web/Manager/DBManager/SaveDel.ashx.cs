using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;


namespace XingAo.Networks.CMS.Web.Manager.DBManager//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "TablenavTab";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["ID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.CustomTable mode = new Model.CustomTable();
                mode.ID = context.Request.Form["txtID"].ObjToInt(0);
                mode.TabName = context.Request.Form["txtTableName"];
                mode.ChineseName = context.Request.Form["txtChineseName"];
                mode.Description = context.Request.Form["txtDescription"];
                mode.IsSystemTable = context.Request.Form["txtIsSystemTable"].ObjToInt(1);//如果取不到值，就当系统表论处
                //@ID	int,--id>0时为更新
                //@TabName	nvarchar(50),--要插入或更新的表名
                //@ChineseName	nvarchar(50),--表的中文名称
                //@Description	varchar(4000)--表相关描述
                Dictionary<string, object> par = new Dictionary<string, object>();
                par.Add("ID", mode.ID);
                par.Add("TabName", mode.TabName);
                par.Add("ChineseName", mode.ChineseName);
                par.Add("Description", mode.Description);
                par.Add("IsSystemTable", mode.IsSystemTable);
                string serverbackmsg= uk.ExecuteScalar("Pro_CreateOrUpdateCustomTable", par).ObjToStr();
               
                if (serverbackmsg!="")
                {
                    code = "300";
                    msg = serverbackmsg;
                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                //----------在些添加服务相关操作
                Dictionary<String, object> par = new Dictionary<string, object>();
                int ID = context.Request.Form["ids"].Split(',')[0].ObjToInt();
                par.Add("ID", ID.ToString());
                par.Add("TableName", "");//-使用表名来删除（要保持上面参数ID为0，否则以id来删除）
                string serverbackmsg = uk.ExecuteScalar("Pro_DropTable", par).ObjToStr();
                if (serverbackmsg!="")
                {
                    code = "300";
                    msg = serverbackmsg;
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
