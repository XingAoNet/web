using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Mobile.Persons
{
    public partial class PersonCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string openid = Request.QueryString["openid"];
                UnitOfWork uk = new UnitOfWork();
                Model.BWPerson bwp = uk.FindSigne<Model.BWPerson>(c => c.OPenId == openid);
                if (bwp != null)
                {
                    txtName.Value = bwp.Name;
                    txtMobile.Value = bwp.Mobile;
                    txtE_mail.Value = bwp.E_Mail;
                    txtAddress.Value = bwp.Address;
                }
            }
        }
    }
}