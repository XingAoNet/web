using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Networks.CMS.Template.Engine;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Head.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Head");
            Foot.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Foot");
            if (!IsPostBack)
            {
                string pp = Request.QueryString["p"].ObjToStr().DecryptStr();
                Button1.Visible = false;
                if (!string.IsNullOrEmpty(pp))
                {
                    UnitOfWork uk = new UnitOfWork();
                    uk.Remove<Model.WebUsersResetPwd>(p => p.Addtime < DateTime.Now.AddMinutes(-30));//移除30分钟以外的数据
                    uk.Commit();
                    Model.WebUsersResetPwd m = uk.FindSigne<Model.WebUsersResetPwd>(p => p.Code == pp);
                    if (m == null)
                    {
                        MessageBox.ShowAndRedirect(this, "此链接不存在或已失效，请重新申请重置密码并在30分钟内完成操作！", "/UserCenter/FindPwd");
                    }
                    else
                    {
                        Button1.Visible = true;
                        HiddenField1.Value = m.Uid.ToString();
                        HiddenField2.Value = m.Code;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UnitOfWork uk = new UnitOfWork();
            int uid = HiddenField1.Value.ObjToInt();
            Model.WebUsers user = uk.FindSigne<Model.WebUsers>(p => p.ID == uid);
            if (user != null)
            {
                user.Pwd = TextBox1.Text.ToMD5Two();
            }
            uk.Remove<Model.WebUsersResetPwd>(p => p.Code == HiddenField2.Value);
            string err = "";
            uk.Commit(out err);
            if (string.IsNullOrEmpty(err))
                MessageBox.ShowAndRedirect(this, "修改成功,您的新密码为:"+TextBox1.Text+"，请牢记您的密码！", "/");
            else
                MessageBox.Show(this, err);
        }
    }
}