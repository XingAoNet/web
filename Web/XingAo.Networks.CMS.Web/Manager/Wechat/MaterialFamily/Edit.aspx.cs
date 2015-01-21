using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using XingAo.Networks.CMS.Web.Manager.Common;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.MaterialFamily
{
    public partial class Edit : Common.BaseEditPage
    {
        UnitOfWork uk = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mflists(txtParentID, "");
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.MaterialFamily model = uk.FindSigne<Model.MaterialFamily>(p => p.ID == id && p.WGuid == "");
                    if (model != null && model.ID > 0)
                    {
                        txtName.Text = model.Name;
                        txtOrderID.Text = model.OrderID.ToString();
                        txtParentID.SelectedValue = id.ToString();

                        int index = txtParentID.SelectedIndex;
                        ListItem item = txtParentID.SelectedItem;
                        txtParentID.Items.RemoveAt(index);
                        item.Attributes.Add("disabled", "disabled");
                        txtParentID.Items.Insert(index, item);

                        txtParentID.SelectedValue = model.ParentID.ToString();
                        txtSelfID.Value = model.ID.ToString();
                        txtDescribe.Text = model.Describe;
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
                
            }
        }

        public static void mflists(DropDownList txtParentID, string _wxid)
        {
            List<Model.MaterialFamily> mfList = SessionHelper.GetMaterialFamilyByWGuid(_wxid);
            txtParentID.Items.Add(new ListItem("根目录", "0"));
            foreach (Model.MaterialFamily mf in mfList)
            {
                ListItem item = new ListItem(("|".PadRight((mf.Deep + 1) * 3, '-')) + mf.Name, mf.ID.ToString());
                txtParentID.Items.Add(item);
            }
        }

    }
}