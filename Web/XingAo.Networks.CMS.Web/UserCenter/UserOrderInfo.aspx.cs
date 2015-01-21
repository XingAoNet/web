using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Template.Engine;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    public partial class UserOrderInfo : System.Web.UI.Page
    {
        Model.WebUserLoginModel LoginUser = null;
        string search = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser = ((UcMaster)Master).LoginUser;
            if (LoginUser == null) return;
            if (!IsPostBack)
                ShowData(LoginUser, search);
        }

        private void ShowData(Model.WebUserLoginModel LoginUser,string search)
        {
            UnitOfWork uk = new UnitOfWork();
            int r = 0;
            if (search == null || search == string.Empty)
            {
                Repeater1.DataSource = uk.LoadWhereLambda<Model.Product_OrderBase>(
                    p => p.CreateUserID == LoginUser.ID,
                    c => c.OrderByDescending(d => d.CreateTime).ThenByDescending(d => d.ID),
                    AspNetPager1.CurrentPageIndex,
                    AspNetPager1.PageSize,
                    out r)
                    .ToList();
            }
            else
            {
                Repeater1.DataSource = uk.LoadWhereLambda<Model.Product_OrderBase>(
                    p => (p.CreateUserID == LoginUser.ID) && (p.Product_OrderInfoList.Where(op => op.ProductName.Contains(search)).Count()>0),
                    c => c.OrderByDescending(d => d.CreateTime).ThenByDescending(d => d.ID),
                    AspNetPager1.CurrentPageIndex,
                    AspNetPager1.PageSize,
                    out r)
                    .ToList();
            }
            AspNetPager1.RecordCount = r;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField BaseID = e.Item.FindControl("BID") as HiddenField;
            Repeater Repeater2 = e.Item.FindControl("Repeater2") as Repeater;
            if (e.Item.DataItem is Model.Product_OrderBase)
            {
                Model.Product_OrderBase prd = (Model.Product_OrderBase)e.Item.DataItem;

                var s = (IEnumerable<Model.Product_OrderBase>)Repeater1.DataSource;
                Repeater2.DataSource = s.Where(p => p.ID == prd.ID).FirstOrDefault().Product_OrderInfoList.Where(p => p.IsConform == 1).ToList();
                Repeater2.DataBind();
            }
        }
        public string GetState(object o)
        {
            int state = o.ObjToInt(-1);
            switch (state)
            {
                case 0:
                    return "未付款";
                case 1:
                    return "已付款";
                case 2:
                    return "已发货";
                case 3:
                    return "已收货";
                case 4:
                    return "已评价";
                case 51:
                    return "申请取消订单";
                case 52:
                    return "管理员同意取消订单";
                case 53:
                    return "申请退货";
                case 54:
                    return "管理员同意申请退货";
                default:
                    return "未知";
            }
        }
        public string GetOptionLink(object o, string Bid)
        {
            int state = o.ObjToInt(-1);
            switch (state)
            {
                case 0:
                    return "<a href=\"/ConformPay\">付款</a><a href=\"/UserCenter/Del/" + Bid + "\">删除</a>";//"未付款";
                case 1:
                    return "<a href=\"/UserCenter/Cancle/" + Bid + "\">申请取消</a>";//"已付款";
                case 2:
                    return "<a href=\"/UserCenter/ConformReceive/" + Bid + "\">确认收货</a><a href=\"/UserCenter/ReturnBack/" + Bid + "\">申请退货</a>";//"已发货";
                case 3:
                    return "<a href=\"/UserCenter/ReturnBack/" + Bid + "\">申请退货</a><a href=\"/UserCenter/Evaluate/" + Bid + "\">评价</a>";//"已收货";
                //case 4:
                //    return "<a href=\"\">申请退货</a>";//"已评价";
                //case 51:
                //    return "申请取消订单";
                //case 52:
                //    return "管理员同意取消订单";
                //case 53:
                //    return "申请退货";
                //case 54:
                //    return "管理员同意申请退货";
                default:
                    return "";
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if(LoginUser!=null)
                ShowData(LoginUser, search);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData(LoginUser, txtOrderSearch.Text);
        }

    }
}