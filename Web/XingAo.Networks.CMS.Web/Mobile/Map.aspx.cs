using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using System.Text;

namespace XingAo.Networks.CMS.Web.Mobile
{
    public partial class Map : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string wxguid = Request.QueryString["wx"];
            if (!string.IsNullOrEmpty(wxguid))
            {
                string lb = Request.QueryString["lb"];
                //if (!string.IsNullOrEmpty(lb))
                //    lb = DEncrypt.Decrypt(lb);
                scriptLi.Text = "<script type=\"text/javascript\"> var lx =" + Request.QueryString["lnt"] + ";var ly =" + Request.QueryString["lng"] + "; var llabel='" + lb + "';</script>";
                UnitOfWork uk = new UnitOfWork();
                LocationXY.DataSource = uk.FindAll<Model.LbsMaterial>().Where(c => c.WGuid == wxguid).Select(c => new { c.Title, c.Longitude, c.Latitude }).ToArray();
                LocationXY.DataBind();

            }
        }
    }
}