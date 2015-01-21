using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XingAo.Networks.CMS.Web.Manager
{
	public partial class ShowPic : System.Web.UI.Page
	{
        public string picurl { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
            picurl = Request.QueryString["pic"];
		}
	}
}