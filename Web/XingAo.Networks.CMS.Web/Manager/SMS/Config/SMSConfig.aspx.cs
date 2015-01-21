using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using System.Collections.Specialized;
using System.Xml;

namespace XingAo.Networks.CMS.Web.Manager.SMS.Config
{
    public partial class SMSConfig : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.SMSConfig conf = new Model.SMSConfig();
                txtPhoneUsername.Text = conf.PhoneUsername;
                txtPhonePassword.Text = conf.PhonePassword;
            }
        }
    }
}