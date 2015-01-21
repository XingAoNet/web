using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;
using XingAo.Networks.CMS.Model.DatabaseModel;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.LBSMaterial//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_LBSMaterial";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.LbsMaterial mode;
                if (id > 0)
                    mode = uk.FindSigne<Model.LbsMaterial>(p => p.ID == id);
                else
                {
                    mode = new Model.LbsMaterial();
                    mode.Creater = "";
                    mode.IDateTime = DateTime.Now;
                    mode.WGuid = "";
                }
                mode.Title = context.Request.Form["txtTitle"];
                mode.Abstract = context.Request.Form["txtAbstract"];
                mode.Address = context.Request.Form["txtAddress"];
                mode.DetailedContent = context.Request.Form["txtDetailedContent"];
                mode.Longitude = StringOption.GetobjectToSingle(context.Request.Form["txtlng"],0);
                mode.Latitude = StringOption.GetobjectToSingle(context.Request.Form["txtlat"], 0);
                mode.PictureAdrress = context.Request.Form["txtPictureAdrress"];
                mode.TelPhone = context.Request.Form["txtTelPhone"];
                mode.URL = context.Request.Form["txtURL"];
                mode.IsShow = context.Request.Form["IsShow"].ObjToInt();
                mode.EditTime = DateTime.Now;
                mode.Editer = "";
                uk.Save(mode, mode.ID);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.LbsMaterial>(p => ID.Contains(p.ID.ToString()));

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
