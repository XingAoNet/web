using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.FriendLink.FriendLink
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                txtGroupID.DataValueField = "ID";
                txtGroupID.DataTextField = "GroupName";
                txtGroupID.DataSource = uk.FindAll<Model.FriendLinkGroup>().ToList();
                txtGroupID.DataBind();
                txtGroupID.Items.Insert(0, new ListItem("--请选择--",""));
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.FriendLink model = uk.FindSigne<Model.FriendLink>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtGroupID.SelectedValue = model.GroupID.ToString();
                        txtID.Value = id.ToString();
                        txtLinkUrl.Text= model.LinkUrl;
                        txtPic.Text = model.Pic;
                        txtTitle.Text = model.Title;
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}