using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.Registration
{
    public partial class Edit : Common.BaseEditPage
    {
        public StringBuilder perhtml;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                perhtml =new StringBuilder();
                MaterialFamily.Edit.mflists(txtParentID, "");                
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.Activities model = new UnitOfWork().FindSigne<Model.Activities>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtTitle.Text = model.Title;
                        txtKeys.Text = model.Keys;
                        txtDetailedContent.Text = model.DetailedContent;
                        txtPersonNum.Text = model.PersonNum.ToString();
                        txtOrderID.Text = model.OrderID.ToString();
                        txtParentID.SelectedValue = model.ParentID.ToString();
                        txtStartTime.Text = model.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                        txtEndTime.Text = model.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
                        txtCanUse.Text = model.CanUse.ToString();
                        txtPictueAddress.Text = model.PictureAddress;
                        txtAbstract.Text = model.Abstract;
                        txtAGuid.Value = model.AGuid;
                        CurrentUrl.Text = new Model.SiteConfig().SiteUrl + "/Mobile/Registration/RegistrationHead.aspx?Openid=reg&AGuid=" + model.AGuid + "&wxid=" + model.WGuid + "&title=" + model.Title;
                        //model.PerContent.Split(",");
                        if (model.PerContent != null)
                            foreach (string per in model.PerContent.Split(','))
                            {
                                if (per != "")
                                    perhtml.AppendLine("<tr><td><input style='width:30%' class='required textInput' name='percontent' value='" + per + "'/><span class='formInput_del'></span></td></tr>");
                            }
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}
