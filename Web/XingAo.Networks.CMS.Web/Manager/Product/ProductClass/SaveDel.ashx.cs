using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Product.ProductClass//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_ProductTypeManagement";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            int id = context.Request.Form["txtID"].ObjToInt(0);
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {

                Dictionary<string, object> par = new Dictionary<string, object>();
                par.Add("ID", id);//--0为添加 其它为修改
                par.Add("Name", context.Request.Form["txtClassName"]);
                par.Add("Pic",context.Request.Form["txtPic"]);
                par.Add("PicHover", context.Request.Form["txtPicHover"]);
                par.Add("DefaultPrice", context.Request.Form["txtDefaultPrice"]);//--默认价格
                par.Add("Pid", context.Request.Form["txtPid"]);//--所属父级的id，顶级为0
                string errmsg = uk.ExecuteScalar("Pro_SaveProductClass", par).ObjToStr();
                if (errmsg != "ok")
                {
                    code = "300";
                    msg = errmsg.Split('|')[1];
                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.Product_Class>(p => ID.Contains(p.ID.ToString()));

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