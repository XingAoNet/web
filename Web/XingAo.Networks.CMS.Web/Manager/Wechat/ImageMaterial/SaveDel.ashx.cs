using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;
using XingAo.Networks.CMS.Model.DatabaseModel;
using XingAo.Networks.CMS.Model.Enums;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.ImageMaterial//----------修改命名空间
{
    /// <summary>
    /// SaveDel1 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_ImageMaterial";//----------修改标签ID

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            string wwguid = context.Request.Form["txtWWGuid"];
            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            string tablename = WeiWebEnum.TableNameSwitch(2);
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                string key = context.Request.Form["txtKeys"];
                List<Model.KeywordsIndex> keyList;
                if (wwguid != "")
                    keyList = uk.FindAll<Model.KeywordsIndex>().Where(c => c.WGuid == "" && c.KeyWords == key && c.PrimaryValue != wwguid).ToList();
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
                    Model.ImageMaterial mode;
                    if (id > 0)
                        mode = uk.FindSigne<Model.ImageMaterial>(p => p.ID == id);
                    else
                    {
                        mode = new Model.ImageMaterial();
                        mode.IDateTime = DateTime.Now;
                        mode.Creater = "";
                        mode.WGuid = "";
                        mode.IMGuid = "IM" + System.Guid.NewGuid().ToString("N");
                    }
                    mode.Url = context.Request.Form["txtUrl"];
                    mode.Keys = key;
                    mode.KeyType = context.Request.Form["txtKeyType"].ObjToInt();
                    mode.OrderID = context.Request.Form["txtOrderID"].ObjToInt(1000);
                    mode.Title = context.Request.Form["txtTitle"];
                    mode.PictuerAdress = context.Request.Form["txtHeader"];
                    mode.Abstract = context.Request.Form["txtAbstract"];
                    mode.ParentID = context.Request.Form["txtParentID"].ObjToInt();
                    mode.IsShow = context.Request.Form["IsShow"].ObjToInt();
                    mode.DetailedContent = context.Request.Form["txtDetailedContent"];
                    mode.IsShowTime = context.Request.Form["IsShowTime"].ObjToInt(0);
                    mode.Thumbnail = context.Request.Form["txtThumbnailHeader"];
                    mode.EditTime = DateTime.Now;
                    mode.Editer = "";
                    uk.Save(mode, mode.ID);
                    Model.KeywordsIndex ki;

                    ki = uk.FindSigne<Model.KeywordsIndex>(c => c.TableName == tablename && c.PrimaryValue == mode.IMGuid);
                    if (ki == null)
                    {
                        ki = new Model.KeywordsIndex();
                        ki.WGuid = "";
                    }
                    ki.KeyWords = mode.Keys;
                    ki.PrimaryValue = mode.IMGuid;

                    ki.TableName = tablename;
                    uk.Save(ki, ki.ID);
                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                string[] Guid = uk.FindByFunc<Model.ImageMaterial>(p => ID.Contains(p.ID.ToString())).Select(c => c.IMGuid).ToArray();
                for (int i = 0; i < ID.Length; i++)
                {
                    int Iid = ID[i].ObjToInt();
                    Model.ImageMaterial model = uk.FindSigne<Model.ImageMaterial>(p => p.ID == Iid);
                    if (model != null)
                        model.IsDelete = 1;
                }
                //uk.Remove<Model.ImageMaterial>(p => ID.Contains(p.ID.ToString()));
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