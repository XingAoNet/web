using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;

namespace XingAo.Networks.CMS.Web.Manager.SMS.SMSSend
{
    public partial class ImprtPhone : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Action = "Imprt";
            }
        }

      
    }
}