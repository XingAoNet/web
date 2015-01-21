using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.CacheManager
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = DataCache.GetCacheList().Where(p => (string.IsNullOrEmpty(base.keyString) || p.CacheName.StartsWith(base.keyString))).OrderBy(p => p.CacheName);
                Repeater1.DataBind();
            }
        }
    }
}