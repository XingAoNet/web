using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Template.Engine;

namespace XingAo.Networks.CMS.Web.Order
{
    public partial class Pay : System.Web.UI.Page
    {
        Model.WebUserLoginModel LoginUser;
        protected void Page_Load(object sender, EventArgs e)
        {           
            Head.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Head");
            Foot.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Foot");
            if (CookiesHelp.IsLogin<Model.WebUserLoginModel>(CookiesHelp.CookiesTypeEnum.WebUser, out LoginUser))
            {
                if (!IsPostBack)
                {
                    string[] BaseIDs;
                    UnitOfWork uk = new UnitOfWork();
                    if (!string.IsNullOrEmpty(Request.Form["BID"]))
                    {
                        BaseIDs = Request.Form["BID"].Split(',');
                    }
                    else
                        BaseIDs = null;
                    if (BaseIDs != null)
                    {
                        List<Model.Product_OrderBase> list = uk.FindByFunc<Model.Product_OrderBase>(p => p.CreateUserID == LoginUser.ID && p.State == 0 && BaseIDs.Contains(p.ID.ToString())).ToList();
                        foreach (Model.Product_OrderBase OrderBase in list)
                        {
                            if (OrderBase.Product_OrderInfoList == null)
                            {
                                uk.Remove(OrderBase, true);
                            }
                            else
                            {
                                string[] sid = Request.Form["SID"].Split(',');
                                foreach (var info in OrderBase.Product_OrderInfoList)
                                {
                                    var update = info;
                                    if (sid.Contains(info.ID.ToString()))
                                    {
                                        update.BuyCount = Request.Form["Count_" + update.ID.ToString()].ObjToInt(-1) == -1 ? update.BuyCount : Request.Form["Count_" + update.ID.ToString()].ObjToInt(-1);
                                        update.IsConform = 1;
                                        uk.Save(update, update.ID);
                                    }
                                    else
                                    {
                                        update.IsConform = 0;
                                        uk.Save(update, update.ID);
                                    }
                                }
                                OrderBase.TotalPrice = OrderBase.Product_OrderInfoList.Where(p => p.IsConform == 1).Sum(p => p.Price * p.BuyCount);
                                
                                OrderBase.RebateTotalPrice = OrderBase.TotalPrice;//此处编写折扣相关代码
                                OrderBase.RebateDescription = "无折扣";
                                uk.Commit();
                            }
                        }
                    }
                    Model.WebUsers u = uk.FindSigne<Model.WebUsers>(p => p.ID == LoginUser.ID);
                    var AllData=uk.FindByFunc<Model.Product_OrderBase>(p => p.CreateUserID == LoginUser.ID && p.State == 0 && (BaseIDs == null || BaseIDs.Contains(p.ID.ToString()))).ToList();
                    Repeater1.DataSource = AllData;
                    Repeater1.DataBind();
                    long PricePint = AllData.Sum(p=>p.Product_OrderInfoList.Sum(c=>c.ProductPayMaxPoint*c.BuyCount));
                    if (PricePint > u.Points)
                        PricePint = u.Points;
                    UsePoint.Text = "使用" + PricePint.ToString() + "点积分抵现金" + (PricePint.ObjToDecimal() / 100).ToString() + "元,您当前共" + u.Points.ToString() + "积分";
                    RadioButtonList2.DataTextField = "Info";
                    RadioButtonList2.DataValueField = "ID";
                    RadioButtonList2.DataSource = uk.FindByFunc<Model.Product_OrderAddr>(p => p.UserID == LoginUser.ID).Select(p => new { ID = p.ID, Info = p.Name + " " + p.Addr + "(" + p.Tel + ")" }).OrderByDescending(p => p.ID);
                    RadioButtonList2.DataBind();
                    RadioButtonList2.Items.Add(new ListItem("使用新地址", "0"));
                }
            }
            else
                MessageBox.ShowAndRedirect(this, "未登录或登录失效！");
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField BaseID = e.Item.FindControl("BID") as HiddenField;
            Repeater Repeater2 = e.Item.FindControl("Repeater2") as Repeater;
            var s = (IEnumerable<Model.Product_OrderBase>)Repeater1.DataSource;
            Repeater2.DataSource = s.Where(p => p.ID == int.Parse(BaseID.Value)).FirstOrDefault().Product_OrderInfoList.Where(p => p.IsConform == 1).ToList();
            Repeater2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UnitOfWork uk = new UnitOfWork();
            Model.Product_OrderAddr addrModel;
            int CheckedID = RadioButtonList2.SelectedValue.ObjToInt(-1);
            if (CheckedID==0)
            {
                addrModel = new Model.Product_OrderAddr();
                addrModel.Name = txtNewName.Text;
                addrModel.Addr = txtNewAddr.Text;
                addrModel.Tel = txtNewTel.Text;
                addrModel.UserID = LoginUser.ID;
                uk.Save(addrModel, addrModel.ID);
            }
            else
            {
                addrModel = uk.FindSigne<Model.Product_OrderAddr>(p=>p.ID==CheckedID);
            }
            Model.Product_OrderBase OrderBase = uk.FindSigne<Model.Product_OrderBase>(p => p.State == 0 && p.CreateUserID == LoginUser.ID);
            OrderBase.State = (int)Model.OrderStateEnum.UnPay;
            OrderBase.CreateTime = DateTime.Now;
            OrderBase.ReciceInfoID = addrModel.ID;
            uk.Save(OrderBase, OrderBase.ID);
            uk.Remove<Model.Product_OrderInfo>(p => p.IsConform == 0&&p.OrderBaseID==OrderBase.ID, false);
            string err = "";
            uk.Commit(out err);
            if (err == "")
            {
                Server.Transfer("/Order/GetBank.aspx?PayType=" + RadioButtonList1.SelectedValue + "&OrderID=" + OrderBase.ID.ToString() + "&UsePoint=" + UsePoint.Checked.ToString());
              //  RadioButtonList1.SelectedValue
               // MessageBox.ShowAndRedirect(this, "支付成功！", "/UserCenter");
            }
            else
                MessageBox.Show(this, err);
        }
    }
}