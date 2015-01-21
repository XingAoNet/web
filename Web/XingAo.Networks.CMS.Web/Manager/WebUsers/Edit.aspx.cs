using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.WebUsers
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.WebUsers model = uk.FindSigne<Model.WebUsers>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        //隐藏密码输入信息
                        panelPassword.Visible = false ;
                        //显示数据
                        txtUserName.Text = model.UserName;
                        txtUserName.ReadOnly = true;
                        txtAudit.SelectedValue = model.Audit.ToString();
                        txtCanUse.SelectedValue = model.CanUse.ToString();
                        txtEmail.Text = model.Email;
                        txtMobile.Text = model.Mobile;
                        txtPoint.Text = model.Points.ToString();
                        txtRealName.Text = model.RealName;
                        txtVipLevel.Text = model.VipLevel.ToString();
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}