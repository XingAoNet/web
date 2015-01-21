using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Wechat
{
    public partial class WXMenu : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                Model.WeiXin_Account model = uk.FindAll<Model.WeiXin_Account>().Where(c => c.IsUse == 1).FirstOrDefault();
                if (model != null && model.Id > 0)
                {
                    txtID.Value = model.Id.ToString();
                    txtName.Text = model.AccountName;
                    txtAppId.Text = model.AppId;
                    txtAppSecret.Text = model.AppSecret;
                    ckIsUse.Checked = model.IsUse == 1;
                    txtMenuJosn.Text = model.MenuJson;
                }
                //else
                //    OptionResultJson.Err("数据不存在！", "");
            }
        }
    }
}