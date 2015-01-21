using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Order
{
    public partial class BuyRemove : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Model.WebUserLoginModel LoginUser;
            if (CookiesHelp.IsLogin<Model.WebUserLoginModel>(CookiesHelp.CookiesTypeEnum.WebUser, out LoginUser))
            {
                GetRouteData r = new GetRouteData();
                int ID = r.GetRouteValue("ID").ObjToInt(0);
                UnitOfWork uk=new UnitOfWork();
                Model.Product_OrderInfo info = uk.FindSigne<Model.Product_OrderInfo>(p=>p.ID==ID);
                if (info != null)
                {
                    if (info.BaseProduct_OrderBase != null && info.BaseProduct_OrderBase.CreateUserID == LoginUser.ID)
                    {
                        if (info.BaseProduct_OrderBase.State == 0)
                        {
                            uk.Remove(info,true);
                            Response.Write("ok");
                        }
                        else
                            Response.Write("商品处于已付款或更高的状态，不允许再删除！");
                    }
                    else
                        Response.Write("数据不存在！");
                }
                else
                    Response.Write("数据不存在！");
            }
            else
                Response.Write("未登录或登录超时！");
        }
    }
}