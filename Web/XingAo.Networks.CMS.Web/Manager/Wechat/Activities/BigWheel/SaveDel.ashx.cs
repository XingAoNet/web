using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model;
using XingAo.Core;
using XingAo.Networks.CMS.Model.Enums;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.BigWheel//----------修改命名空间
{
    /// <summary>
    /// SaveDel1 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_BigWheel";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            string bguid = context.Request.QueryString["txtBGuid"];
            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            string tablename = WeiWebEnum.TableNameSwitch(5);
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                string key = context.Request.Form["txtKeys"];
                List<Model.KeywordsIndex> keyList;
                if (bguid != "")
                    keyList = uk.FindAll<Model.KeywordsIndex>().Where(c => c.WGuid == "" && c.KeyWords == key && c.PrimaryValue != bguid).ToList();
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
                    Model.BigWheel mode;
                    if (id > 0)
                        mode = uk.FindSigne<Model.BigWheel>(p => p.ID == id);
                    else
                    {
                        mode = new Model.BigWheel();
                        mode.IDateTime = DateTime.Now;
                        mode.Creater = "";
                        mode.WGuid = "";
                        mode.BGuid = "B" + System.Guid.NewGuid().ToString("N");
                    }
                    mode.Keys = context.Request.Form["txtKeys"];
                    mode.OrderID = context.Request.Form["txtOrderID"].ObjToInt(1000);
                    mode.Title = context.Request.Form["txtTitle"];
                    mode.PictureAddress = context.Request.Form["txtPictueAddress"];
                    mode.Abstract = context.Request.Form["txtAbstract"];
                    mode.ParentID = context.Request.Form["txtParentID"].ObjToInt();
                    mode.DetailedContent = context.Request.Form["txtDetailedContent"];
                    mode.CanUse = context.Request.Form["txtCanUse"].ObjToInt();
                    mode.Prize = context.Request.Form["prizecontent"];
                    mode.Color = context.Request.Form["prizecolor"];
                    mode.DayNum = context.Request.Form["txtDayNum"].ObjToInt();
                    mode.StartTime = StringOption.ObjToDate(context.Request.Form["txtStartTime"], DateTime.Now);
                    mode.EndTime = StringOption.ObjToDate(context.Request.Form["txtEndTime"], DateTime.Now);
                    mode.EditTime = DateTime.Now;
                    mode.Editer = "";
                    uk.Save(mode, mode.ID);
                    Model.KeywordsIndex ki;

                    ki = uk.FindSigne<Model.KeywordsIndex>(c => c.TableName == tablename && c.PrimaryValue == mode.BGuid);
                    if (ki == null)
                    {
                        ki = new Model.KeywordsIndex();
                        ki.WGuid = "";
                    }
                    ki.KeyWords = mode.Keys;
                    ki.PrimaryValue = mode.BGuid;

                    ki.TableName = tablename;
                    uk.Save(ki, ki.ID);
                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                string[] Guid = uk.FindByFunc<Model.BigWheel>(p => ID.Contains(p.ID.ToString())).Select(c => c.BGuid).ToArray();
                for (int i = 0; i < ID.Length; i++)
                {
                    int Iid = ID[i].ObjToInt();
                    Model.BigWheel model = uk.FindSigne<Model.BigWheel>(p => p.ID == Iid);
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