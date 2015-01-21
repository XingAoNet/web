/******************************************************************
* Create By:陈成杰
* Create Time:2014-05-29 01:25:45
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Net.Mail;

namespace XingAo.Core.Mail
{
    public class SMTPMailService
    {
        private static SmtpClient client= null;

        /// <summary>
        /// 初始化SMTP发送客户端
        /// </summary>
        /// <param name="mailSendAddress">邮件发送地址信息</param>
        private static void InitSmtpClinet(MailSendAddr mailSendAddress)
        {
            client = client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential
                (mailSendAddress.SendName, mailSendAddress.SendPwd);
            client.Host = mailSendAddress.Host;
            client.Port = mailSendAddress.Port;
            client.EnableSsl = mailSendAddress.EnableSsl; //经过ssl加密
        }

        /// <summary>
        /// 初始化邮件发送信息
        /// </summary>
        /// <param name="toMsg">邮件发送信息及接收地址</param>
        /// <returns>返回转换后的邮件发送信息及接收地址</returns>
        private static MailMessage InitMailMessage(MailSendAddr mailSendAddress, MailMsg toMsg, MailReceiveAddr receiveAddr)
        {
            MailMessage result = new MailMessage();
            FillToEmailAddr(result.To, receiveAddr.Tos);
            FillToEmailAddr(result.CC, receiveAddr.CC);
            FillToEmailAddr(result.Bcc, receiveAddr.Bcc);

            result.From = new MailAddress(mailSendAddress.SendName, mailSendAddress.DisplayName, toMsg.Encoding);
            result.Subject = toMsg.Subject.Trim().Replace("\r\n", "");
            result.Body = toMsg.Body;
            result.Priority = toMsg.Priority;
            result.IsBodyHtml = toMsg.IsBodyHtml;
            result.BodyEncoding = result.SubjectEncoding = toMsg.Encoding;
            return result;
        }

        /// <summary>
        /// 填充收件地址、抄送地址、暗送地址
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="addrs"></param>
        private static void FillToEmailAddr(MailAddressCollection collection, string[] addrs)
        {
            if (addrs == null)
                return;

            foreach (string addr in addrs)
            {
                collection.Add(new MailAddress(addr));
            }
        }

        public static bool Send(
            MailSendAddr mailSendAddress,
            MailReceiveAddr mailReceiveAddress,
            MailMsg mailMessage)

        {
            if (mailSendAddress == null)
                throw new ArgumentNullException("发送地址未设置，请确认。");
            if (mailReceiveAddress == null && mailReceiveAddress.To.Length < 1)
                throw new ArgumentNullException("邮件发送地址未初始化。");
            if (mailMessage.Subject == string.Empty)
                mailMessage.Subject = mailMessage.Body.Substring(20);
            try
            {
                InitSmtpClinet(mailSendAddress);
                client.Timeout = mailMessage.TimeOut;
                client.Send(InitMailMessage(mailSendAddress, mailMessage, mailReceiveAddress));
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
            
        }


    }
}
