using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.CustomMenu
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.navTab = "CustomMenu_edit";
                UnitOfWork uk = new UnitOfWork();
                foreach (Model.CustomMenu m in DbMenu.GetDb(""))
                    txtPID.Items.Add(new ListItem("".PadRight(m.Deep * 4, (char)0xA0) + "|--" + m.Name, m.ID.ToString()));

                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    Model.CustomMenu model = uk.FindSigne<Model.CustomMenu>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtID.Value = model.ID.ToString();
                        txtOrderID.Text = model.OrderID.ToString();
                        txtName.Text = model.Name;
                        txtKeys.Value = model.Keys;
                        txtKeys_text.Text = model.KeysText;
                        txtSource.Value = model.Source;
                        IsUse.Checked = model.CanUse == 1;
                        txtPID.SelectedValue = model.ParentID.ToString();
                        ClickRadio.Checked = model.MenuType == "click";
                        ViewRadio.Checked = model.MenuType == "view";
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}
