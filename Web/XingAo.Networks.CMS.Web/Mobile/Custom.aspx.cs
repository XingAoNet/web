using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Mobile
{
    public partial class Custom : System.Web.UI.Page
    {
        public string headjsons;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string wxid = Request.QueryString["wxid"];
                UnitOfWork uk = new UnitOfWork();
              //  Model.WeiTemplate temp=uk.FindSigne<Model.WeiTemplate>(c => c.WGuid == wxid);
                //if (temp != null)
                //{
                //    headjsons = temp.CssType;
                //}
            }
        }
    }
}