using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    public partial class ChangeState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.WebUserLoginModel LoginUser;
            if (CookiesHelp.IsLogin<Model.WebUserLoginModel>(CookiesHelp.CookiesTypeEnum.WebUser, out LoginUser))
            {
                GetRouteData r = new GetRouteData();
                string State = r.GetRouteValue("State");
                int id = r.GetRouteValue("ID").ObjToInt(-1);
                UnitOfWork uk = new UnitOfWork();
                Model.Product_OrderBase model = uk.FindSigne<Model.Product_OrderBase>(p => p.ID == id && p.CreateUserID == LoginUser.ID);
                if (model == null)
                {
                    MessageBox.Show(this, "物品不存在！");
                }
                else
                {
                    switch (State.ToLower())
                    {
                        case "del"://用户删除自己的订单
                            if (model.State == (int)Model.OrderStateEnum.UnPay || model.State == (int)Model.OrderStateEnum.Evaluate)
                            {
                                model.UserDel = 1;
                            }
                            else
                            {
                                MessageBox.Show(this, "只有未付款或已评价的订单才能删除！");
                                return;
                            }
                            break;
                        case "cancle"://取消或申请取消订单
                            if (model.State == (int)Model.OrderStateEnum.Pay)
                            {
                                model.State = 0;
                            }
                            else if (model.State == (int)Model.OrderStateEnum.Send)
                            {
                                model.State = (int)Model.OrderStateEnum.ApplyCancelOrder;
                            }
                            else
                            {
                                MessageBox.Show(this, "订单不是处于已支付或已发货状态，无法取消！");
                                return;
                            }
                            break;
                        case "conformreceive"://确认收货
                            if (model.State == (int)Model.OrderStateEnum.Send )
                            {
                                model.State =  (int)Model.OrderStateEnum.Received;
                            }
                            else
                            {
                                MessageBox.Show(this, "订单不是处于已发货状态，无法确认收货！");
                                return;
                            }
                            break;
                        case "returnback"://申请退货
                            if (model.State == (int)Model.OrderStateEnum.Send||model.State == (int)Model.OrderStateEnum.Received)
                            {
                                model.State = (int)Model.OrderStateEnum.ApplayBack;
                            }
                            else
                            {
                                MessageBox.Show(this, "订单不是处于已发货或已收货状态，无法申请退货！");
                                return;
                            }
                            break;
                        case "evaluate"://评价
                            if (model.State == (int)Model.OrderStateEnum.Received)
                            {
                                model.State = (int)Model.OrderStateEnum.Evaluate;
                            }
                            else
                            {
                                MessageBox.Show(this, "订单不是处于已收货状态，无法评价！");
                                return;
                            }
                            break;
                            
                    }
                    uk.Save(model,model.ID);
                    string err = "";
                    uk.Commit(out err);
                    MessageBox.ShowAndRedirect(this,"操作成功！","/UserCenter");
                }
            }
            else
                MessageBox.Show(this, "未登录或登录超时！");
            

        }
    }
}