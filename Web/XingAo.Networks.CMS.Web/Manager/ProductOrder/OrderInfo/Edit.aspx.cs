using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using System.Collections.Specialized;
using XingAo.Networks.CMS.Model;

namespace XingAo.Networks.CMS.Web.Manager.ProductOrder.OrderInfo
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int r = 0;
                UnitOfWork uk = new UnitOfWork();
                int BaseID = Request.QueryString["BID"].ObjToInt();
                txtID.Value = BaseID.ToString();
                var data = uk.LoadWhereLambda<Model.Product_OrderBase>(p => p.ID == BaseID, p => p.OrderByDescending(c => c.ID), 1, 999, out r).ToList();
                Rep_OrderBase.DataSource = data;                
                Rep_OrderBase.DataBind();
                List<Model.WebUsers> user = new List<Model.WebUsers>();
                user.Add(data.FirstOrDefault().BaseWebUsers);
                Rep_UserInfo.DataSource = user;
                Rep_UserInfo.DataBind();

                SetPrice(data);

                txtRebateTotalPrice.Text = data.FirstOrDefault().RebateTotalPrice.ToString();
                BindDroupDownList(txtManagerState, typeof(Model.OrderManagerStateEnum));
                txtManagerState.SelectedValue = data.FirstOrDefault().ManagerState.ToString();
                BindDroupDownList(txtState, typeof(Model.OrderStateEnum));
                SetOrderState(data.FirstOrDefault().State);
                txtState.SelectedValue = data.FirstOrDefault().State.ToString();
                txtRebateDescription.Text = data.FirstOrDefault().RebateDescription;
                if (data.FirstOrDefault().ManagerState == (int)Model.OrderManagerStateEnum.Finshed)
                {
                    SaveBtn.Visible = false;
                }
            }
        }

        /// <summary>
        /// 绑定返射回来的枚举
        /// </summary>
        /// <param name="dr">绑定到哪个DropDownList控件上</param>
        /// <param name="type">哪个枚举的type</param>
        private void BindDroupDownList(DropDownList dr, Type type)
        {
            NameValueCollection keyv = EnumTransform.GetDescriptionAddValue(type);
            foreach (string key in keyv.AllKeys)
                dr.Items.Add(new ListItem(key, keyv[key]));
            dr.Items.Insert(0, new ListItem("--请选择--", ""));
        }

        /// <summary>
        /// 设置价格信息
        /// </summary>
        /// <param name="data"></param>
        private void SetPrice(List<Model.Product_OrderBase> data)
        {
            var orderInfos = data.FirstOrDefault().Product_OrderInfoList;
            Rep_OrderInfo.DataSource = orderInfos;
            Rep_OrderInfo.DataBind();
            //计算所有购买的总价和积分总数
            decimal totelPrice = 0.00M;
            int totelPoint = 0;
            foreach (var orderInfo in orderInfos)
            {
                totelPrice += orderInfo.BuyCount * orderInfo.Price;
                totelPoint += orderInfo.BuyCount * orderInfo.ProductGetPoint;
            }
            TotelPrice.Text = totelPrice.ToString();
            TotelPoint.Text = totelPoint.ToString();
        }

        private void SetOrderState(int orderState)
        {
            NameValueCollection description = EnumTransform.GetDescriptionAddValue(typeof(OrderStateEnum));
            foreach(string k in description.Keys)
            {
                if (description[k] == orderState.ToString())
                {
                    litOrderState.Text += "<span style='color:red; padding-left:20px;'>" + description[k] + "." + k + "</span>";
                }
                else
                {
                    litOrderState.Text += "<span style='padding-left:20px;'>" + description[k] + "." + k + "</span>";
                }
            }
        }
    }
}