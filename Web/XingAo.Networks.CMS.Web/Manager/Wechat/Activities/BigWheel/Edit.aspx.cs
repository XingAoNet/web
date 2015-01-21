using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.BigWheel
{
    public partial class Edit : Common.BaseEditPage
    {
        public StringBuilder Prizehtml;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Prizehtml = new StringBuilder();
                MaterialFamily.Edit.mflists(txtParentID, "");
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.BigWheel model = new UnitOfWork().FindSigne<Model.BigWheel>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtTitle.Text = model.Title;
                        txtPictueAddress.Text = model.PictureAddress;
                        txtKeys.Text = model.Keys;
                        txtDetailedContent.Text = model.DetailedContent;
                        txtOrderID.Text = model.OrderID.ToString();
                        txtParentID.SelectedValue = model.ParentID.ToString();
                        txtStartTime.Text = model.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                        txtEndTime.Text = model.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
                        txtCanUse.Text = model.CanUse.ToString();
                        txtAbstract.Text = model.Abstract;
                        txtDayNum.Text = model.DayNum.ToString(); ;
                        txtBGuid.Value = model.BGuid;
                        CurrentUrl.Text = new Model.SiteConfig().SiteUrl + "/Mobile/BigWheels/BigWheel.aspx?Openid=bw&BGuid=" + model.BGuid + "&wxid=" + model.WGuid + "&title=" + model.Title;
                        //model.PerContent.Split(",");
                        if (model.Prize != null)
                            foreach (string per in model.Prize.Split(','))
                            {
                                if (per != "")
                                    Prizehtml.AppendLine("<tr><td><input class='textInput' name='prizecontent' value='" + per + "'/></td><td><span class='formInput_del'></span></td></tr>");
                            }
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
                else
                    Prizehtml.AppendLine(" <tr><td><input class='textInput' name='prizecontent'/></td><td><span class='formInput_del'></span></td></tr>");
            }
        }
    }
}