using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Product.Product//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly string navTabId = "ProductInfoManagement";//----------修改标签ID
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            int id = context.Request.Form["txtID"].ObjToInt();
            string code = "200", msg = "提交成功！", callbackaction = "closeCurrent";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(action))//添加或修改
            {
                Model.Product_Base model;
                if (id > 0)
                    model = uk.FindSigne<Model.Product_Base>(p => p.ID == id);
                else
                {
                    model = new Model.Product_Base();
                    model.TotalCount = context.Request.Form["txtTotalCount"].ObjToInt(0);
                }
                model.AttributeGroupID = context.Request.Form["txtAttributeGroupID"].ObjToInt(0);
                model.PicList = GetPicList(context);
                model.Price = context.Request.Form["txtPrice"].ObjToDecimal(9999);
                model.ProductClassIDs = ","+context.Request.Form["txtProductClassIDs"]+",";
                model.ProductName = context.Request.Form["txtProductName"];
                model.ProductNumber = context.Request.Form["txtProductNumber"];
                model.RealPrice = context.Request.Form["txtRealPrice"].ObjToDecimal(9999);
                model.SellCount = context.Request.Form["txtSellCount"].ObjToInt(0);
                model.State = context.Request.Form["txtState"].ObjToInt(0);
                model.GetPoint = context.Request.Form["txtGetPoint"].ObjToInt(0);
                model.MaxPayPoint = context.Request.Form["txtMaxPayPoint"].ObjToInt(0);
                uk.Save(model, id);
                uk.Remove<Model.Product_AttributeValues>(p=>p.ProductBaseID==model.ID,false);
                IEnumerable<Model.Product_Attribute> AttributeList = uk.FindByFunc<Model.Product_Attribute>(p => p.GroupID == model.AttributeGroupID);
                foreach (Model.Product_Attribute att in AttributeList.OrderByDescending(p=>p.OrderNum).ThenByDescending(p=>p.ID))
                {
                    Model.Product_AttributeValues value= new Model.Product_AttributeValues();
                    value.AttrName = att.AttrName;
                    value.AttrValue = context.Request.Form["txt_" + att.AttrName.ToMD5()];
                    value.ProductBaseID = model.ID;
                    uk.Save(value,value.ID);
                }
            }
            else//删除
            {
                msg = "删除成功！";
                callbackaction = "";
                string[] ID = context.Request.Form["ids"].Split(',');
                uk.Remove<Model.Product_Base>(p => ID.Contains(p.ID.ToString()));

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

        /// <summary>
        /// 设置图片列表拼装成字符串，用于保存至数据库
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetPicList(HttpContext context)
        {
            string result = string.Empty;
            result += context.Request.Form["txt_PicTitle1"] + ",";
            result += context.Request.Form["txt_PicTitle2"] + ",";
            result += context.Request.Form["txt_PicTitle3"] + ",";
            result += context.Request.Form["txt_PicTitle4"] + ",";
            result += context.Request.Form["txt_PicTitle5"];
            return result;
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