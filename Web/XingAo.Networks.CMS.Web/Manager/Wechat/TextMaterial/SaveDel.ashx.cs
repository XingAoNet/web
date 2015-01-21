using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;
using XingAo.Networks.CMS.Model.DatabaseModel;
using XingAo.Networks.CMS.Model.Enums;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.TextMaterial//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_TextMaterial";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            string tguid = context.Request.Form["txtTGuid"];
            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            string tablename = WeiWebEnum.TableNameSwitch(1);
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                string key = context.Request.Form["KeyValue"];
                List<Model.KeywordsIndex> keyList;
                if (tguid != "")
                    keyList = uk.FindAll<Model.KeywordsIndex>().Where(c => c.WGuid == "" && c.KeyWords == key && c.PrimaryValue != tguid).ToList();
                else
                    keyList = uk.FindAll<Model.KeywordsIndex>().Where(c => c.WGuid == "" && c.KeyWords == key).ToList();
                if (keyList.Count() > 0)
                {
                    code = "300";
                    msg = "关键字重复";
                    callbackaction = "";
                }
                else
                {
                    Model.TextMaterial mode;
                    if (id > 0)
                        mode = uk.FindSigne<Model.TextMaterial>(p => p.ID == id);
                    else
                    {
                        mode = new Model.TextMaterial();
                        mode.IDateTime = DateTime.Now;
                        mode.Creater = "";
                        mode.WGuid = "";
                        mode.TGuid = "T" + System.Guid.NewGuid().ToString("N");
                    }
                    mode.Keys = key;
                    mode.KeyType = context.Request.Form["KeyType"].ObjToInt();
                    mode.ReplyContent = context.Request.Form["txtReplyContent"];
                    mode.EditTime = DateTime.Now;
                    mode.Editer = "";
                    uk.Save(mode, mode.ID);
                    Model.KeywordsIndex ki;
                    ki = uk.FindSigne<Model.KeywordsIndex>(c => c.TableName == tablename && c.PrimaryValue == mode.TGuid);
                    if (ki == null)
                    {
                        ki = new Model.KeywordsIndex();
                        ki.WGuid = "";
                    }
                    ki.KeyWords = mode.Keys;
                    ki.PrimaryValue = mode.TGuid;
                    ki.TableName = tablename;
                    uk.Save(ki, ki.ID);
                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                string[] Guid = uk.FindByFunc<Model.TextMaterial>(p => ID.Contains(p.ID.ToString())).Select(c => c.TGuid).ToArray();
                for (int i = 0; i < ID.Length; i++)
                {
                    int Tid = ID[i].ObjToInt();
                    Model.TextMaterial model = uk.FindSigne<Model.TextMaterial>(p => p.ID == Tid);
                    if (model != null)
                        model.IsDelete = 1;
                }
                uk.Remove<Model.KeywordsIndex>(p => Guid.Contains(p.PrimaryValue) && p.TableName == tablename);
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