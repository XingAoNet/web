using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using XingAo.Networks.CMS.Template.Engine;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Head.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Head");
            Foot.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Foot");
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.WebUsers u = new Model.WebUsers();
            u.CanUse = 0;
            u.Audit = 0;
            u.LastLoginTime = DateTime.Now;
            u.Points = 0;
            u.Pwd = pwd.Text.ToMD5Two();
            u.RealName = realname.Text.ClearHtml();
            u.UserName = username.Text.ClearHtml();
            u.VipLevel = 0;
            u.Email = email.Text;
            u.Mobile = mobile.Text;
            UnitOfWork uk = new UnitOfWork();
            if (uk.FindByFunc<Model.WebUsers>(user => user.Mobile == u.Mobile).Count() > 0)
            {
                MessageBox.Show(this,"该手机号码已经被注册，请重新确认。");
                return;
            }
            if (uk.FindByFunc<Model.WebUsers>(user => user.Email == u.Email).Count() > 0)
            {
                MessageBox.Show(this, "该邮箱已经被注册，请重新确认。");
                return;
            }
            uk.Save(u,u.ID);
            string err = "";
            uk.Commit(out err);
            if (err != "")
            {
                MessageBox.ShowAndRedirect(this, err, "");
            }
            else
                MessageBox.ShowAndRedirect(this,"注册成功,请等待管理员审核","/");
        }
    }
}