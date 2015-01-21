using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.SysConfigs.SiteSetting
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.SiteConfig conf=new Model.SiteConfig();
                txtCopyright.Text = conf.Copyright;
                txtFax.Text = conf.Fax;
                txtSiteName.Text = conf.SiteName;
                txtTel.Text = conf.Tel;
                txtUrl.Text=conf.SiteUrl;
                txtZIP.Text = conf.ZIP;
                txtAddress.Text = conf.Address;
                txtServiceEmail.Text = conf.ServiceEmail;
            }
        }
    }
}