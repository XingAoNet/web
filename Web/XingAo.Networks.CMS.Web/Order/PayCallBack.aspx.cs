using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Order
{
    public partial class PayCallBack : System.Web.UI.Page
    {
        /// <summary>
        /// 支付接口回调页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //"PayCallBack.aspx?OrderID=" + Request.QueryString["OrderID"] + " &UsePoint=" + Request.QueryString["UsePoint"]
            UnitOfWork uk = new UnitOfWork();
            Model.Product_OrderBase OrderBase;
            Model.WebUserLoginModel LoginUser;
            int id = Request.QueryString["OrderID"].ObjToInt(0);
            if (CookiesHelp.IsLogin<Model.WebUserLoginModel>(CookiesHelp.CookiesTypeEnum.WebUser, out LoginUser))
            {
                OrderBase = uk.FindSigne<Model.Product_OrderBase>(p => p.State == 0 && p.ID == id&&p.CreateUserID==LoginUser.ID); 
                Model.WebUsers u = uk.FindSigne<Model.WebUsers>(p=>p.ID==LoginUser.ID);
                long PricePint = OrderBase.Product_OrderInfoList.Sum(c => c.ProductPayMaxPoint * c.BuyCount);
                if (PricePint > 0)
                {
                    u.Points -= PricePint;
                    uk.Save(u, u.ID);//扣除积分
                    Model.WebUsersPointInfo info = new Model.WebUsersPointInfo();
                    info.AfterPoint = u.Points;
                    info.AuditTime = DateTime.Now;
                    info.AuditUserID = u.ID;
                    info.BeforePoint = u.Points + PricePint;
                    info.CreateTime = DateTime.Now;
                    info.Descriptions = PricePint.ToString() + "积分抵用订单号：" + OrderBase.OrderCode + " 内的现金" + (PricePint.ObjToDecimal(0) / 100).ToString() + "元";
                    info.IsPass = 1;
                    info.Point = 0 - PricePint;
                    info.Title = "积分抵用现金购物";
                    info.UserID = u.ID;
                    uk.Save(info, info.ID);//添加积分消费记录
                }
                PricePint = OrderBase.Product_OrderInfoList.Sum(c => c.ProductGetPoint * c.BuyCount);//购物所得总积分
                if (PricePint > 0)
                {
                    u.Points += PricePint;
                    uk.Save(u, u.ID);//增加购买商品积分

                    Model.WebUsersPointInfo infoAdd = new Model.WebUsersPointInfo();
                    infoAdd.AfterPoint = u.Points;
                    infoAdd.AuditTime = DateTime.Now;
                    infoAdd.AuditUserID = u.ID;
                    infoAdd.BeforePoint = u.Points - PricePint;
                    infoAdd.CreateTime = DateTime.Now;
                    infoAdd.Descriptions = "订单号：" + OrderBase.OrderCode + "购物获得积分";
                    infoAdd.IsPass = 1;
                    infoAdd.Point = PricePint;
                    infoAdd.Title = "购物得积分";
                    infoAdd.UserID = u.ID;
                    uk.Save(infoAdd, infoAdd.ID);//添加积分增加记录
                } 
               
            }
            else
            { OrderBase = uk.FindSigne<Model.Product_OrderBase>(p => p.State == 0 && p.ID == id); }

            OrderBase.State = (int)Model.OrderStateEnum.Pay;
            uk.Save(OrderBase, OrderBase.ID);
            string err = "";
            uk.Commit(out err);
            if (err == "")
                err = "支付成功";
            Response.Redirect("/PayResult?msg="+Server.UrlEncode(err));
        }
    }
}