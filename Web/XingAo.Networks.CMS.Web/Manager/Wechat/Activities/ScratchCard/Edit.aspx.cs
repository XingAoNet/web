using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.ScratchCard
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Action = "Card";
                MaterialFamily.Edit.mflists(txtParentID, "");
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.ScratchCard model = new UnitOfWork().FindSigne<Model.ScratchCard>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtTitle.Text = model.Title;
                        txtKeys.Text = model.Keys;
                        txtPersonNum.Text = model.AllowVisitedCount.ToString();
                        txtOrderID.Text = model.OrderID.ToString();
                        txtParentID.SelectedValue = model.ParentID.ToString();
                        txtStartTime.Text = model.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                        txtEndTime.Text = model.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
                        txtCanUse.Text = model.CanUse.ToString();
                        txtCardBG.Text = model.CardBG;
                        txtCardBGSelect.Value = model.MaskCoordinate;
                        InHmtl.Text = model.InHtml;
                        //txtMaskPic.Text = model.MaskPic;
                        txtDefaultGoods.Text = model.DefaultGoodName;
                        txtTotalCount.Text = model.TotalCount.ToString();
                        txtPictureAddress.Text = model.PictureAddress;
                        txtAbstract.Text = model.Abstract;
                        txtSGuid.Value = model.SGuid;
                        CurrentUrl.Text = new Model.SiteConfig().SiteUrl + "/Mobile/ScratchCard/Card.aspx?Openid=sc&sguid=" + model.SGuid + "&wxid=" + model.WGuid + "&title=" + model.Title;
                        //model.PerContent.Split(",");
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}