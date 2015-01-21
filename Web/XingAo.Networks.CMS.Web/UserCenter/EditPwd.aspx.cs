using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Networks.CMS.Template.Engine;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    public partial class EditPwd : System.Web.UI.Page
    {
        Model.WebUserLoginModel LoginUser;
        UnitOfWork uk = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser = ((UcMaster)Master).LoginUser;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.WebUsers user = uk.FindSigne<Model.WebUsers>(p => p.ID == LoginUser.ID);
            if (user != null)
            {
                if (TextBox1.Text.ToMD5Two() == user.Pwd)
                {
                    user.Pwd = TextBox2.Text.ToMD5Two();
                    uk.Save(user,user.ID);
                    string err = "";
                    uk.Commit(out err);
                    if (err == "")
                        MessageBox.ShowAndRedirect(this, "修改成功！", "/UserCenter");
                    else
                        MessageBox.ShowAndRedirect(this,err);
                }
                else
                    MessageBox.ShowAndRedirect(this,"旧密码错误！");
            }
            else
                MessageBox.ShowAndRedirect(this,"用户不存在或登录超时！");
        }
    }
}