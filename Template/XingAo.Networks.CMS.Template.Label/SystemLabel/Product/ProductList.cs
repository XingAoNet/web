using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Routing;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel.Product
{
   /// <summary>
   /// 取产品列表
   /// </summary>
    [Serializable]
    public class ProductList
    {
        /// <summary>
        /// 取多少条数据，0为取全部
        /// </summary>
        public int GetCount { get; set; }
        /// <summary>
        /// 是否显示分页
        /// </summary>
        public int PageSize { get;set;}
        /// <summary>
        /// 每页显示多少条数据（GetCount为0时有效）
        /// </summary>
        public bool ShowPager { get; set; }
        /// <summary>
        /// 生成的列表最外层ul css样式class名称
        /// </summary>
        public string UlCssClassName { get; set; }
        /// <summary>
        /// 类别id
        /// </summary>
        public int ProductClassID { get; set; }
        /// <summary>
        /// 取生成的html
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
           GetRouteData RouteData= new GetRouteData();
            StringBuilder html = new StringBuilder();
            html.AppendLine("<ul" + (string.IsNullOrEmpty(UlCssClassName) ? "" : " class=\"" + UlCssClassName + "\"") + ">");
            if(ProductClassID<=0)
                ProductClassID = RouteData.GetRouteValue("Category").ObjToInt(0);
            int ProductCurrentPage = RouteData.GetRouteValue("Page").ObjToInt(1);
            IEnumerable<Model.Product_Base> data ;
            string _ProductClassID = ProductClassID.ToString();
            Expression<Func<Model.Product_Base, bool>> where = p => (ProductClassID == 0 || p.ProductClassIDs.IndexOf("," + _ProductClassID + ",") > -1);

            data = new UnitOfWork().LoadWhereLambda<Model.Product_Base>(where, p => p.OrderByDescending(c => c.ID), ProductCurrentPage,(ShowPager?PageSize: (GetCount==0?int.MaxValue:GetCount)));
            foreach(Model.Product_Base product in data)
            {
                html.AppendLine("<li>");
                html.AppendLine("<img src=\""+product.PicList.Split(',')[0]+"\" alt=\""+product.ProductName+"\" />");
                //"{ClassName}/Category{Category}/Show{ProductID}"
                html.AppendLine("<a href=\"/" + RouteData.GetRouteValue("ClassName") + "/Category" + (ProductClassID > 0 ? ProductClassID.ToString() : product.ProductClassIDs.Trim(',').Split(',')[0]) + "/Show"+product.ID.ToString()+"\">" + product.ProductName + "</a>");
                html.AppendLine("<div class=\"Prices\"><s>￥" + product.RealPrice.ToString("0.00") + "</s><span>￥" + product.RealPrice.ToString("0.00") + "</span></div>");
                html.AppendLine("</li>");
            }
            html.AppendLine("</ul>");
            if (ShowPager)
                html.AppendLine("分页未完成，XingAo.Networks.CMS.Template.Label-》Product-》ProductList.cs上去完善！");
            return html.ToString();
        }
    }
}
