using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Navigation
{
    /// <summary>
    /// Move 的摘要说明
    /// </summary>
    public class Move : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_Navigation";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            DataCache.RemoveCache(DataCache.DataCacheType.Menu);
            DataCache.RemoveCache(DataCache.DataCacheType.ColumnAttExchange);
            string code = "200", msg = "提交成功！", callbackaction = "";
            UnitOfWork uk = new UnitOfWork();
           
            string[] par = context.Request.QueryString["Par"].Split('|');//ID|0或1   0为下移
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("MoveType", par[1] == "1" ? "up" : "down");
            pars.Add("Id", par[0]);
           int state= uk.ExecuteScalar("Pro_MoveWebNavigation", pars).ObjToInt(-1111);
           string ErrMsg = "";
            bool ok = false;
            switch (state)
            {
                case -1:
                    ok = true;
                    ErrMsg = "操作成功！";
                    break;
                case 0:
                    ok = false;
                    ErrMsg = "此栏目已是最后一级，不能再下移！";
                    break;
                case 1:
                    ok = false;
                    ErrMsg = "此栏目已是最上一级，不能再上移！";
                    break;
                case 999:
                    ok = false;
                    ErrMsg = "处理数据时遇到错误，本次操作已被撤销！";
                    break;
                default:
                    ok = false;
                    ErrMsg = "未知错误，请与管理员联系！";
                    break;
            }
            if (!ok)
            {
                code = "300";
            }
            msg = ErrMsg;
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
