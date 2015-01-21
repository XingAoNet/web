/******************************************************************
* Create By:卢小阳
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace XingAo.Networks.CMS.Common
{
    /// <summary>
    /// 邮件发送操作类
    /// </summary>
    public class MailSender
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="server">Smtp邮件服务器地址</param>
        /// <param name="port">邮件服务器发送端口，默认为25</param>
        /// <param name="sender">发件人邮箱</param>
        /// <param name="SenderUserName">发件人邮箱用户名(isAuthentication=true时有效)</param>
        /// <param name="SenderPwd">发件人邮箱密码(isAuthentication=true时有效)</param>
        /// <param name="recipient">收件人邮箱</param>
        /// <param name="Cc">邮件抄送给xxx邮箱地址数组(不抄送为null)</param>
        /// <param name="Bcc">邮件密件抄送给xxx邮箱地址数组(不密件抄送为null,批量群发建议使用密件抄送，这样别人看不到其它收件人的地址)</param>
        /// <param name="subject">邮件标题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="isBodyHtml">邮件内容是否为html</param>
        /// <param name="encoding">邮件编码（如gb2312、utf-8等）</param>
        /// <param name="isAuthentication">是否启用  用于验证发件人身份的凭据</param>
        /// <param name="files">邮件附件列表</param>
        /// <returns></returns>
        public static bool Send(
            string server,
            int port, 
            string sender, 
            string SenderUserName, 
            string SenderPwd, 
            string recipient, 
            string[] Cc, 
            string[] Bcc, 
            string subject, 
            string body, 
            bool isBodyHtml, 
            Encoding encoding, 
            bool isAuthentication, 
            params string[] files)
        {
            try
            {
                MailMessage message = new MailMessage(sender, recipient);
                message.IsBodyHtml = isBodyHtml;
                message.SubjectEncoding = encoding;
                message.BodyEncoding = encoding;
                //抄送
                if (Cc != null && Cc.Length != 0)
                {
                    foreach (string s in Cc)
                        message.CC.Add(s);
                }
                //密送
                if (Bcc != null && Bcc.Length != 0)
                {
                    foreach (string s in Bcc)
                        message.Bcc.Add(s);
                }
                message.Subject = subject;
                message.Body = body;

                message.Attachments.Clear();
                if (files != null && files.Length != 0)
                {
                    for (int i = 0; i < files.Length; ++i)
                    {
                        Attachment attach = new Attachment(files[i]);
                        message.Attachments.Add(attach);
                    }
                }

                SmtpClient smtpClient = new SmtpClient(server, port);
                if (isAuthentication == true)
                {
                    smtpClient.Credentials = new NetworkCredential(SenderUserName, SenderPwd);
                }
                smtpClient.Timeout = 1000;
                smtpClient.EnableSsl = true;
                
                smtpClient.Send(message);
                return true;
            }
            catch(Exception ex) { return false; }

        }
        /// <summary>
        /// 发送邮件（编码为Default,内容为html格式，启用凭据，无附件）
        /// </summary>
        /// <param name="server">Smtp邮件服务器地址</param>
        /// <param name="sender">发件人邮箱</param>
        /// <param name="SenderUserName">发件人邮箱用户名(isAuthentication=true时有效)</param>
        /// <param name="SenderPwd">发件人邮箱密码(isAuthentication=true时有效)</param>
        /// <param name="recipient">收件人邮箱</param>
        /// <param name="subject">邮件标题</param>
        /// <param name="body">邮件内容</param>
        /// <returns></returns>
        public static bool Send(string server, int port, string sender, string SenderUserName, string SenderPwd, string recipient, string subject, string body)
        {
            return Send(server, port, sender, SenderUserName, SenderPwd, recipient, null, null, subject, body, true, Encoding.Default, true, null);
        }
        /// <summary>
        /// 发送邮件（内容为html格式，启用凭据，无附件）
        /// </summary>
        /// <param name="server">Smtp邮件服务器地址</param>
        /// <param name="sender">发件人邮箱</param>
        /// <param name="SenderUserName">发件人邮箱用户名(isAuthentication=true时有效)</param>
        /// <param name="SenderPwd">发件人邮箱密码(isAuthentication=true时有效)</param>
        /// <param name="recipient">收件人邮箱</param>
        /// <param name="subject">邮件标题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="encoding">邮件编码（如gb2312、utf-8等）</param>
        /// <returns></returns>
        public static bool Send(string server, int port, string sender, string SenderUserName, string SenderPwd, string recipient, string subject, string body, Encoding encoding)
        {
            return Send(server, port, sender, SenderUserName, SenderPwd, recipient, null, null, subject, body, true, encoding, true, null);
        }
        /// <summary>
        /// 发送邮件（内容为html格式，启用凭据，无附件）
        /// </summary>
        /// <param name="server">Smtp邮件服务器地址</param>
        /// <param name="sender">发件人邮箱</param>
        /// <param name="SenderUserName">发件人邮箱用户名(isAuthentication=true时有效)</param>
        /// <param name="SenderPwd">发件人邮箱密码(isAuthentication=true时有效)</param>
        /// <param name="recipient">收件人邮箱</param>
        /// <param name="Cc">邮件抄送给xxx邮箱地址数组(不抄送为null)</param>
        /// <param name="Bcc">邮件密件抄送给xxx邮箱地址数组(不密件抄送为null,批量群发建议使用密件抄送，这样别人看不到其它收件人的地址)</param>
        /// <param name="subject">邮件标题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="encoding">邮件编码（如gb2312、utf-8等）</param>
        /// <returns></returns>
        public static bool Send(string server, int port, string sender, string SenderUserName, string SenderPwd, string recipient, string[] Cc, string[] Bcc, string subject, string body, Encoding encoding)
        {
            return Send(server,port, sender, SenderUserName, SenderPwd, recipient, Cc, Bcc, subject, body, true, encoding, true, null);
        }
    }
}
