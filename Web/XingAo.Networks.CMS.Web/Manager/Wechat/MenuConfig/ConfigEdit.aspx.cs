using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.MenuConfig
{
    public partial class ConfigEdit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Action = "config";
                Model.WeiXin_Account model = new UnitOfWork().FindSigne<Model.WeiXin_Account>(p => p.Id == 1);
                string addressInit = "addressInit('TxtProvince', 'TxtCity', 'TxtAddress', '浙江', '台州市', '路桥区');";
                if (model != null && model.Id > 0)
                {
                    txtID.Value = model.Id.ToString();
                    txtAppId.Text = model.AppId;
                    txtAppSecret.Text = model.AppSecret;
                    txtName.Text = model.AccountName;
                    txtPwd.Text = model.AccountPwd; 
                    txtChatName.Text = model.WaChatName;
                    txtSourceId.Text = model.SourceId;
                    txtChatNumber.Text = model.WaChatNumber;
                    txtHeader.Text = model.WaChatHeader;
                    txtErWei.Text = model.QRCode;
                    txtMail.Text = model.E_mail;
                    RadioButAccountType.SelectedValue = model.AccountType.GetValueOrDefault(1).ToString();
                    addressInit = "addressInit('TxtProvince', 'TxtCity', 'TxtAddress', '" + model.Province + "', '" + model.City + "', '" + model.Address + "');";
                }
                else
                    JUIJsonResult.Err("数据不存在！", "");
            }
        }
    }
}