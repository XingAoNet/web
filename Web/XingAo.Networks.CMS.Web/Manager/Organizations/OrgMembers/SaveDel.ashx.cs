using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Organizations.OrgMembers//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_OrgMembers";//----------修改标签ID
        public void ProcessRequest(HttpContext hc)
        {
            string action = hc.Request.QueryString["action"];

            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
             string orgid = hc.Request.Form["TxtOrgId"];
             List<int> dbIds = new List<int>();
             if (!string.IsNullOrEmpty(orgid))
             {
                 dbIds=uk.FindAll<Model.Organization_Relation_Member>().Where(c => c.OrgId == orgid).Select(c=>c.Id).ToList();
             }
             else {
                 code = "300";
                 msg = "组织机构不存在";
                 hc.Response.Write("{\"statusCode\":\"" + code + "\",\"message\":\"" + msg + "\",\"navTabId\":\"" + navTabId + "\",\"rel\":\"\",\"callbackType\":\"" + callbackaction + "\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}");
                 hc.Response.End();
             }
               
           
           
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                string DbId = hc.Request.Form["DbID"];
                if (!string.IsNullOrEmpty(DbId))
                {
                    string[] DbIds = DbId.Split(',');
                    string[] MemberNames = hc.Request.Form["orgName"].Split(',');
                    string[] MemberIds = hc.Request.Form["id"].Split(',');
                 
                    Model.Organization_Relation_Member mode;
                    int _dbid=0;
                    for (int i=0;i< DbIds.Length;i++)
                    { 
                        _dbid=DbIds[i].ObjToInt(0);
                        mode = uk.FindAll<Model.Organization_Relation_Member>().Where(c => c.Id == _dbid).FirstOrDefault();
                        if (mode == null)
                        {
                            mode = new Model.Organization_Relation_Member();
                            mode.OrgId = orgid;
                        }
                        else
                        {
                            dbIds.Remove(mode.Id);
                        }
                        mode.MemberId = MemberIds[i].ObjToInt(0);
                        mode.MemberName = MemberNames[i];
                        uk.Save(mode, mode.Id);
                    }
                    uk.Remove<Model.Organization_Relation_Member>(p => dbIds.Contains(p.Id));

                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = hc.Request.Form["ids"].Split(',');
                uk.Remove<Model.Organization_Relation_Member>(p => ID.Contains(p.Id.ToString()));

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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}