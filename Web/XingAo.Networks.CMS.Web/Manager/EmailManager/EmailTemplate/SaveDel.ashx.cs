﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.EmailManager.EmailTemplate//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "MailTemplateManagement";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.EmailTemplateModel model;
                if (id > 0)
                {
                    model = uk.FindSigne<Model.EmailTemplateModel>(p => p.ID == id);
                    model.ModifyTime = DateTime.Now;
                }
                else
                {
                    model = new Model.EmailTemplateModel();
                    model.CreateTime = DateTime.Now;
                    model.ModifyTime = DateTime.Now;
                }
                model.Name = context.Request.Form["txtName"];
                model.Title = context.Request.Form["txtTitle"];
                model.Info = context.Request.Form["txtInfo"];
                uk.Save(model, id);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.EmailTemplateModel>(p => ID.Contains(p.ID.ToString()));
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