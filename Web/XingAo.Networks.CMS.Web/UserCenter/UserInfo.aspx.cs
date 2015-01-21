using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Template.Engine;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    public partial class UserInfo : System.Web.UI.Page
    {
        Model.WebUserLoginModel LoginUser;
        UnitOfWork uk = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoginUser = ((UcMaster)Master).LoginUser;
                Rep_UserInfo.DataSource = uk.FindByFunc<Model.WebUsers>(p => p.ID == LoginUser.ID).ToList();
                Rep_UserInfo.DataBind();

            }
        }

        protected void Btn_UpdatePwd_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Model.WebUsers user = uk.FindSigne<Model.WebUsers>(p => p.ID == LoginUser.ID);
                if (user != null)
                {
                    if (txtOldPwd.Text.ToMD5Two() == user.Pwd)
                    {
                        user.Pwd = txtNewPwd.Text.ToMD5Two();
                        uk.Save(user, user.ID);
                        string err = "";
                        uk.Commit(out err);
                        if (err != "")
                        {
                            MessageBox.ShowAndRedirect(this, err);
                        }
                        else
                            MessageBox.ShowAndRedirect(this, "密码修改成功！", "/UserCenter");
                    }
                    else
                        MessageBox.ShowAndRedirect(this, "旧密码错误！");
                }
                else
                    MessageBox.ShowAndRedirect(this, "用户不存在！");
            }
        }
    }
}