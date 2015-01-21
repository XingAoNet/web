using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Networks.CMS.Template.Engine;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Core.Mail;

namespace XingAo.Networks.CMS.Web.UserCenter
{
    public partial class FindPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Head.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Head");
            Foot.Text = TemplateEngine.GetTemplateResendHtmlByEname("Page_Foot");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRegEmail.Text) && !string.IsNullOrEmpty(txtImangeCode.Text))
            {
                string code = txtImangeCode.Text;
                if (Session == null || Session["V_Code"] == null || Session["V_Code"].ToString().ToLower() != code.ToLower())
                {
                    MessageBox.ShowAndRedirect(this, "验证码错误", "/UserCenter/FindPwd");
                }
                else
                {
                    UnitOfWork uk = new UnitOfWork();
                    Model.WebUsers user = uk.FindSigne<Model.WebUsers>(p => p.Email == txtRegEmail.Text);
                    if (user != null)
                    {
                        Model.SiteConfig conf = new Model.SiteConfig();
                        string Title = conf.SiteName + " -重设" + user.UserName + "密码";
                        string ContentsTemplate = FileOption.ReadFile("/Templates/OtherTemplates/FindPwdMail.htm");//读取密码重置内容模板
                        int index = ContentsTemplate.LastIndexOf("{注释线-");
                        if (index > 0)
                            ContentsTemplate = ContentsTemplate.Substring(0, index);
                        Model.WebUsersResetPwd model = uk.FindSigne<Model.WebUsersResetPwd>(p => p.Uid == user.ID);
                        if(model==null)
                           model= new Model.WebUsersResetPwd();
                        model.Addtime = DateTime.Now;
                        model.Code = (user.ID.ToString() + user.Email + DateTime.UtcNow.Ticks.ToString()).ToMD5Two();
                        model.Uid = user.ID;
                        uk.Save(model, model.ID);
                        string err = "";
                        uk.Commit(out err);
                        if (err != "")
                        {
                            MessageBox.Show(this, err);
                        }
                        else
                        {
                            sendEmailToUser(Title,ContentsTemplate, user, model, conf);
                        }
                    }
                    else
                        MessageBox.ShowAndRedirect(this,"用户不存在！","/");
                }
            }
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="ContentsTemplate">内容模板</param>
        /// <param name="userModel">用户信息</param>
        /// <param name="resetPwdModel">找回密码信息</param>
        /// <param name="siteConfigModel">站点信息</param>
        private void sendEmailToUser(string title, string ContentsTemplate,
            Model.WebUsers userModel,
            Model.WebUsersResetPwd resetPwdModel,
            Model.SiteConfig siteConfigModel)
        {
            Model.Email.EmailSettingModel settingModel = new Model.Email.EmailSettingModel();
            string port = Request.Url.Port == 80 ? "" : ":" + Request.Url.Port.ToString();
            string url = "http://" + Request.Url.Host + port + "/UserCenter/ResetPwd?p=" + Server.UrlEncode((resetPwdModel.Code).EncryptStr());
            string siteInfo = siteConfigModel.Copyright.Replace("{currentyear}", DateTime.Now.Year.ToString());
            //解释说明：
            //{0}--用户名
            //{1}--重置密码链接
            //{2}--网站名称
            //{3}--邮件发送时间
            //{4}--网站版权信息（在后台网站设置内配置）
            ContentsTemplate = string.Format(ContentsTemplate,
                userModel.UserName,
                url,
                siteConfigModel.SiteName,
                DateTime.Now,
                siteInfo
                );
            MailSendAddr sendAddr =
                new MailSendAddr()
                {
                    SendName = settingModel.SendAccount,
                    DisplayName = settingModel.SendName,
                    SendPwd = settingModel.SendPwd,
                    Port = settingModel.SMTPPort,
                    Host = settingModel.SMPTServer,
                    EnableSsl = settingModel.SmtpValidation>0
                };
            MailReceiveAddr receiveAddr = new MailReceiveAddr(){To= userModel.Email};
            MailMsg msg = new MailMsg() { Body = ContentsTemplate, IsBodyHtml = true, Subject = title };
            if (SMTPMailService.Send(sendAddr, receiveAddr, msg))
            {
                MessageBox.ShowAndRedirect(this, "密码重置链接已发送到您的" + userModel.Email + ",请在30分钟内点击邮件内的链接！", "/");
            }
            else
            {
                MessageBox.Show(this, "邮件服务器出现故障，您将无法收到密码找回信息");
            }
        }
    }
}