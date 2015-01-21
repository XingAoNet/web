using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;
using XingAo.Networks.CMS.Model.DatabaseModel;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Attention//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_Attention";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            string code = "200", msg = "提交成功！", callbackaction = "";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                int type = context.Request.Form["TxtType"].ObjToInt();
                Model.Attention mode;
                mode = uk.FindAll<Model.Attention>().Where(p => p.WGuid == "").FirstOrDefault();
                if (mode == null)
                {
                    #region 检测套餐回复数

                    #endregion
                    mode = new Model.Attention();
                    mode.IDateTime = DateTime.Now;
                    mode.Creater = "";
                    mode.WGuid = "";
                }
                mode.Keys = context.Request.Form["txtKeys"];
                mode.KeyType = context.Request.Form["txtKeyType"].ObjToInt();
                mode.OrderID = context.Request.Form["txtOrderID"].ObjToInt(1000);
                mode.Title = context.Request.Form["txtTitle"];
                mode.PictuerAdress = context.Request.Form["txtHeader"];
                mode.Abstract = context.Request.Form["txtAbstract"];
                mode.ParentID = context.Request.Form["txtParentID"].ObjToInt();
                mode.IsShow = context.Request.Form["IsShow"].ObjToInt();
                mode.DetailedContent = context.Request.Form["txtDetailedContent"];
                mode.OtherURL = context.Request.Form["txtOtherURL"];
                mode.Type = type;
                mode.EditTime = DateTime.Now;
                mode.Editer = "";
                uk.Save(mode, mode.ID);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.Attention>(p => ID.Contains(p.ID.ToString()));
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
