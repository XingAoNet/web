using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using System.Text;

namespace XingAo.Networks.CMS.Web.Manager.SysConfigs.ManagerUser
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.ManagerUser model = new UnitOfWork().FindSigne<Model.ManagerUser>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtCanUse.SelectedValue = model.CanUse.ToString();
                        txtGroupIDs.Text = model.GroupIDs;
                        txtRealName.Text = model.RealName;
                        txtUserName.Text = model.UserName;
                        txtUserName.ReadOnly = true;
                        txtPwd2.Attributes.Add("equalto", "#" + txtPwd.ClientID);
                        StringBuilder grouptxt = new StringBuilder();
                        string[] GroupIDs = model.GroupIDs.Split(',');
                        IEnumerable<Model.ManagerUserGroup> GroupList = new UnitOfWork().FindByFunc<Model.ManagerUserGroup>(p => GroupIDs.Contains(p.ID.ToString()));
                        foreach (Model.ManagerUserGroup group in GroupList)
                        {
                            grouptxt.Append(group.GroupName + ",");
                        }
                        txtGroupIDs_text.Text = grouptxt.ToString().TrimEnd(',');
                        txtUserType.SelectedValue = model.UserType.ToString();
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
                else
                {
                    txtPwd.Attributes.Add("class", "required");
                    txtPwd2.Attributes.Add("class", "required");
                    txtPwd2.Attributes.Add("equalto", "#"+txtPwd.ClientID);
                }
            }
        }
    }
}