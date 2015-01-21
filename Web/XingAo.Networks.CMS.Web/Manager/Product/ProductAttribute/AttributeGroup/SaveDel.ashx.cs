using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Product.ProductAttribute.AttributeGroup//----------修改命名空间
{
    /// <summary>
    /// 属性分组或称之为属性模板操作页 到时商品编辑页需要什么样的动态属性，就从此组的id里取到具体的动态属性
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_ProductAttributeGroup";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.Product_AttributeGroup mode;
                if (id > 0)
                    mode = uk.FindSigne<Model.Product_AttributeGroup>(p => p.ID == id);
                else
                {
                    mode = new Model.Product_AttributeGroup();
                }
                mode.GroupName = context.Request.Form["txtGroupName"];
                mode.Descriptions = context.Request.Form["txtDescriptions"];
                uk.Save(mode, id);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                //uk.Remove<Model.xxxx>(p => ID.Contains(p.ID.ToString()));

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