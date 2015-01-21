using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Template.Engine;
using System.Text;

namespace XingAo.Networks.CMS.Web.Order
{
    public partial class ShoppingBuy : System.Web.UI.Page
    {
        Model.WebUserLoginModel LoginUser;
        List<Model.Product_OrderBase> orderbaselists;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Head.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Head");
            Foot.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Foot");
            GetRouteData r = new GetRouteData();
            if (!IsPostBack)
            {
                if (CookiesHelp.VerifyLogin<Model.WebUserLoginModel>(this, CookiesHelp.CookiesTypeEnum.WebUser, out LoginUser))
                {
                    int ProductID = r.GetRouteValue("ID").ObjToInt(0);
                    if (ProductID > 0)
                    {
                        UnitOfWork uk = new UnitOfWork();
                        Model.Product_Base ProductBase = uk.FindSigne<Model.Product_Base>(p => p.ID == ProductID);
                        if (ProductBase != null)
                        {
                            #region 商品存在时
                            Model.Product_OrderBase OrderBaseModel = uk.FindSigne<Model.Product_OrderBase>(p => p.State == 0 && p.CreateUserID == LoginUser.ID && p.ManagerState == 0);//查找此用户下未处理的订单
                            if (OrderBaseModel == null)//如果不存在则新增订单
                            {
                                OrderBaseModel = new Model.Product_OrderBase();
                                OrderBaseModel.ChangeManagerStateUserID = null;
                                OrderBaseModel.CreateTime = DateTime.Now;
                                OrderBaseModel.CreateUserID = LoginUser.ID;
                                OrderBaseModel.LastStateTime = null;
                                OrderBaseModel.ManagerState = 0;
                                OrderBaseModel.OrderCode = Guid.NewGuid().ToString("N").ToUpper();
                                OrderBaseModel.State = 0;
                                uk.Save(OrderBaseModel, OrderBaseModel.ID);
                            }
                            Model.Product_OrderInfo orderInfo = null;
                            if (OrderBaseModel.Product_OrderInfoList != null)
                            {
                                orderInfo = OrderBaseModel.Product_OrderInfoList.Where(p => p.ProductID == ProductID).FirstOrDefault();//通过关系查找此订单下的商品
                            }
                            if (orderInfo == null)//如果不存在则新增
                            {
                                orderInfo = new Model.Product_OrderInfo();
                                orderInfo.OrderBaseID = OrderBaseModel.ID;
                                orderInfo.BuyCount = 1;
                                orderInfo.ProductID = ProductID;
                                orderInfo.Price = ProductBase.RealPrice;
                                orderInfo.ProductName = ProductBase.ProductName;
                                orderInfo.IsConform = 0;
                            }
                            else//如果存在就把购买数量加1
                            {
                                orderInfo.IsConform = 0;
                                orderInfo.BuyCount++;
                            }
                            orderInfo.ProductGetPoint = ProductBase.GetPoint;
                            orderInfo.ProductPayMaxPoint = ProductBase.MaxPayPoint;
                            uk.Save(orderInfo, orderInfo.ID);
                            string err = "";
                            uk.Commit(out err);
                            if (string.IsNullOrEmpty(err))
                            {
                                //Response.Write("ok");
                            }
                            else
                            {
                                //Response.Write(err);
                            }
                            #endregion
                        }
                    }
                    ShowDataBind();
                } 
            }
        }

        private void ShowDataBind()
        {
            UnitOfWork uk = new UnitOfWork();
            orderbaselists = uk.FindByFunc<Model.Product_OrderBase>(p => p.State == 0 && p.CreateUserID == LoginUser.ID && p.ManagerState == (int)Model.OrderManagerStateEnum.UnSet).ToList();
           
            OrderBaseList.DataSource = orderbaselists;
            OrderBaseList.DataBind();

        }

        protected void OrderBaseList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                HiddenField HBid = e.Item.FindControl("HBID") as HiddenField;
                Repeater OrderInfoList = e.Item.FindControl("OrderInfoList") as Repeater;
                int BaseID = HBid.Value.ObjToInt(0);
                OrderInfoList.DataSource = orderbaselists.Where(p => p.ID == BaseID).FirstOrDefault().Product_OrderInfoList.ToList();                
                OrderInfoList.DataBind();
            }
            catch { }
        }

        protected void OrderInfoList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                UnitOfWork uk = new UnitOfWork();
                int delID = e.CommandArgument.ObjToInt(0);
                Model.Product_OrderInfo del = uk.FindSigne<Model.Product_OrderInfo>(p => p.ID == delID);
                uk.Remove(del,true);
                if(uk.FindByFunc<Model.Product_OrderInfo>(p=>p.OrderBaseID==del.OrderBaseID).Count()==0)
                uk.Remove<Model.Product_OrderBase>(p => p.ID==del.OrderBaseID);
                string err = "";
                uk.Commit(out err);
                if (err != "")
                    MessageBox.Show(this,err);
                Response.Redirect("/Buy/0");
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            ShowDataBind();
        }        
    }
}