using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model;

namespace XingAo.Networks.CMS.Web.Manager.Product.ProductAttribute.AttributeSet//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "navTab_ProductAttributeSet";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.Product_Attribute model;
                if (id > 0)
                    model = uk.FindSigne<Model.Product_Attribute>(p => p.ID == id);
                else
                {
                    model = new Model.Product_Attribute();
                }
                model.AttrName = context.Request.Form["txtAttrName"];               
                Model.EditFormControl editform = new EditFormControl();
                editform.ControlType = int.Parse(context.Request.Form["txtFormControlType"]).ToEnum<Model.FormControlTypeEnum>();                
                editform.DataValidation = int.Parse(context.Request.Form["txtDataValidation"]).ToEnum<Model.DataValidationEnum>();
                editform.DrawLineAfter = false;
                editform.FieldName = model.AttrName.ToMD5();
                editform.FormTxt = model.AttrName;
                editform.Height = editform.Width = "";
                editform.UseTag_P = false;
                model.ControlResendJson = editform.ToJSON();
                model.OrderNum = context.Request.Form["txtOrderNum"].ObjToInt(0);
                model.GroupID = context.Request.Form["txtGroupID"].ObjToInt(0);
                model.Descriptions = context.Request.Form["txtDescriptions"];
                uk.Save(model, id);
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.Product_Attribute>(p => ID.Contains(p.ID.ToString()));

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