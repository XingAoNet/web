using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Systems
{
    public partial class Interface : BaseMemberPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string n = "shengben";
                Model.WeiXin_Account model = new UnitOfWork().FindAll<Model.WeiXin_Account>().FirstOrDefault();
                if (model != null && model.Id > 0)
                {
                    ApiLi.Text = new Model.SiteConfig().SiteUrl + "/Api/TokenApi.ashx?n=" + n.ToMD5().Substring(0, 15);
                    TokeLi.Text = n.ToMD5().Substring(0, 15);
                }
                else
                    JUIJsonResult.Err("数据不存在！", "");
            }
        }
    }
}