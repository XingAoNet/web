using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using System.Text;

namespace XingAo.Networks.CMS.Web.Mobile
{
    public partial class MapLine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    string s_x = Request.QueryString["lnt"];
                    string s_y = Request.QueryString["lng"];
                    UnitOfWork uk = new UnitOfWork();
                    Model.LbsMaterial model = uk.FindSigne<Model.LbsMaterial>(c => c.ID == id);
                    if (model != null)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("<script type=\"text/javascript\">");
                        sb.AppendLine("var sx =" + s_x + ";");
                        sb.AppendLine("var sy =" + s_y + "; ");
                        sb.AppendLine("var ex =" + model.Longitude + ";");
                        sb.AppendLine("var ey =" + model.Latitude + "; ");
                        string lb = Request.QueryString["lb"];
                        //if (!string.IsNullOrEmpty(lb))
                        //    lb = DEncrypt.Decrypt(lb);
                        sb.AppendLine("var llabel='" + lb + "';");
                        sb.AppendLine("</script>");
                        scriptLi.Text = sb.ToString();
                    }
                }
            }
        }
    }
}