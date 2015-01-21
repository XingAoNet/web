using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XingAo.Networks.CMS.Common;
using XingAo.Networks.CMS.DbHelper;

namespace XingAo.Networks.CMS.Template.Label.SystemLabel.Product
{
    /// <summary>
    /// 商品详细内容显示
    /// </summary>
   [Serializable]
    public class AddToShoppingCart
    {        

       /// <summary>
       /// 渲染html
       /// </summary>
       /// <returns></returns>
       public string GetHtml()
       {
           StringBuilder html = new StringBuilder();
           GetRouteData r = new GetRouteData();
           int ProductID = r.GetRouteValue("ID").ObjToInt(0);
           if (ProductID > 0)
           {
 
           }
           return html.ToString();
       }
    }
}
