using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model.Email;

namespace XingAo.Networks.CMS.Web.Manager.EmailManager.EmailSetting
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmailSettingModel model = new EmailSettingModel();
                txtSendAccount.Text = model.SendAccount;
                txtSendName.Text = model.SendName;
                txtSendPwd.Text = model.SendPwd;
                txtSMPTServer.Text = model.SMPTServer;
                txtSMTPPort.Text = model.SMTPPort.ToString();
                ddlSmtpValidation.SelectedValue = model.SmtpValidation.ToString();
                
            }
        }
    }
}