using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;


namespace WebApplication.Manager.CacheManager
{
    public partial class ShowCacheValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            string key = Request.QueryString["v"];
            Literal1.Text = Server.HtmlEncode(DataCache.GetCacheList().FirstOrDefault(p => p.CacheName == key).Value).Replace("\n", "<br />");
        }
    }
}