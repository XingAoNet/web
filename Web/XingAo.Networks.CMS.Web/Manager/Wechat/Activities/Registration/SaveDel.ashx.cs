using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Manager.Common;
using XingAo.Networks.CMS.Model.Enums;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.Registration//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_Registration";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            string aguid = context.Request.QueryString["txtAGuid"];
            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            string tablename = WeiWebEnum.TableNameSwitch(0);
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                string key = context.Request.Form["txtKeys"];
                List<Model.KeywordsIndex> keyList;
                if (aguid != "")
                    keyList = uk.FindAll<Model.KeywordsIndex>().Where(c => c.WGuid == "" && c.KeyWords == key && c.PrimaryValue != aguid).ToList();
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
                    Model.Activities mode;
                    if (id > 0)
                        mode = uk.FindSigne<Model.Activities>(p => p.ID == id);
                    else
                    {
                        mode = new Model.Activities();
                        mode.Creater = SessionHelper.ManagerMember.RealName;
                        mode.IDateTime = DateTime.Now;
                        mode.WGuid = "";
                        mode.AGuid = "A" + System.Guid.NewGuid().ToString("N");
                    }
                    mode.Title = context.Request.Form["txtTitle"];
                    mode.Keys = key;
                    mode.DetailedContent = context.Request.Form["txtDetailedContent"];
                    mode.PersonNum = context.Request.Form["txtPersonNum"].ObjToInt();
                    mode.StartTime = StringOption.ObjToDate(context.Request.Form["txtStartTime"], DateTime.Now);
                    mode.EndTime = StringOption.ObjToDate(context.Request.Form["txtEndTime"], DateTime.Now);
                    mode.ParentID = context.Request.Form["txtParentID"].ObjToInt();
                    mode.OrderID = context.Request.Form["txtOrderID"].ObjToInt(1000);
                    mode.CanUse = context.Request.Form["txtCanUse"].ObjToInt();
                    mode.EditTime = DateTime.Now;
                    mode.Editer = SessionHelper.ManagerMember.RealName;
                    mode.PictureAddress = context.Request.Form["txtPictueAddress"];
                    mode.Abstract = context.Request.Form["txtAbstract"];
                    mode.PerContent = context.Request.Form["percontent"].ObjToStr();
                    uk.Save(mode, mode.ID);
                    Model.KeywordsIndex ki;
                    ki = uk.FindSigne<Model.KeywordsIndex>(c => c.TableName == tablename && c.PrimaryValue == mode.AGuid);
                    if (ki == null)
                    {
                        ki = new Model.KeywordsIndex();
                        ki.WGuid = "";
                    }
                    ki.KeyWords = mode.Keys;
                    ki.PrimaryValue = mode.AGuid;
                    ki.TableName = tablename;
                    uk.Save(ki, ki.ID);
                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                string[] Guid = uk.FindByFunc<Model.Activities>(p => ID.Contains(p.ID.ToString())).Select(c => c.AGuid).ToArray();
                for (int i = 0; i < ID.Length; i++)
                {
                    int Iid = ID[i].ObjToInt();
                    Model.Activities model = uk.FindSigne<Model.Activities>(p => p.ID == Iid);
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