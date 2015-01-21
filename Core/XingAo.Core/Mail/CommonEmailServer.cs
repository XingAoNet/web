/******************************************************************
* Create By:陈成杰
* Create Time:2014-05-29 01:46:37
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/

namespace XingAo.Core.Mail
{
    /// <summary>
    /// 常用的邮箱服务器（包括地址和端口）
    /// </summary>
    public class CommonEmailServer
    {
        /// <summary>
        /// 邮件服务
        /// </summary>
        public class EmailServer
        {
            /// <summary>
            /// 邮件网关
            /// </summary>
            public string Addr;
            /// <summary>
            /// 端口号
            /// </summary>
            public int Port;
            /// <summary>
            /// 是否启用SSL
            /// </summary>
            public bool IsSSL;
        }

        /// <summary>
        /// gmail(google.com)
        /// </summary>
        public static EmailServer gmailSmtp = 
            new EmailServer() { Addr = "smtp.gmail.com", Port = 587, IsSSL = true };
        public static EmailServer gmailPop3 =
            new EmailServer() { Addr = "pop.gmail.com", Port = 995, IsSSL = true };

        public static EmailServer _21cnSmtp = 
            new EmailServer() { Addr = "smtp.21cn.com", Port = 25, IsSSL = false };

        //懒得写了，抽空再补充完整
        /* gmail(google.com)
            POP3服务器地址:pop.gmail.com（SSL启用 端口：995）
            SMTP服务器地址:smtp.gmail.com（SSL启用 端口：587）
            21cn.com: 
            POP3服务器地址:pop.21cn.com（端口：110）
            SMTP服务器地址:smtp.21cn.com（端口：25）
            sina.com: 
            POP3服务器地址:pop3.sina.com.cn（端口：110）
            SMTP服务器地址:smtp.sina.com.cn（端口：25） 
            tom.com: 
            POP3服务器地址:pop.tom.com（端口：110）
            SMTP服务器地址:smtp.tom.com（端口：25）
            163.com: 
            POP3服务器地址:pop.163.com（端口：110）
            SMTP服务器地址:smtp.163.com（端口：25）
            263.net: 
            POP3服务器地址:pop3.263.net（端口：110）
            SMTP服务器地址:smtp.263.net（端口：25）
            yahoo.com: 
            POP3服务器地址:pop.mail.yahoo.com
            SMTP服务器地址:smtp.mail.yahoo.com
            263.net.cn: 
            POP3服务器地址:pop.263.net.cn（端口：110）
            SMTP服务器地址:smtp.263.net.cn（端口：25）
            Foxmail：
            POP3服务器地址:POP.foxmail.com（端口：110）
            SMTP服务器地址:SMTP.foxmail.com（端口：25）
            sinaVIP  
            POP3服务器:pop3.vip.sina.com （端口：110）
            SMTP服务器:smtp.vip.sina.com （端口：25）
            sohu.com: 
            POP3服务器地址:pop3.sohu.com（端口：110）
            SMTP服务器地址:smtp.sohu.com（端口：25）
            etang.com: 
            POP3服务器地址:pop.etang.com
            SMTP服务器地址:smtp.etang.com
            x263.net: 
            POP3服务器地址:pop.x263.net（端口：110）
            SMTP服务器地址:smtp.x263.net（端口：25）
            yahoo.com.cn: 
            POP3服务器地址:pop.mail.yahoo.com.cn（端口：995）
            SMTP服务器地址:smtp.mail.yahoo.com.cn（端口：587）
            雅虎邮箱POP3的SSL不启用端口为110，POP3的SSL启用端口995；SMTP的SSL不启用端口为25，SMTP的SSL启用端口为465
            QQ邮箱                                       QQ企业邮箱           
            POP3服务器地址：pop.qq.com（端口：110）            POP3服务器地址：pop.exmail.qq.com （SSL启用 端口：995）        
            SMTP服务器地址：smtp.qq.com （端口：25）           SMTP服务器地址：smtp.exmail.qq.com（SSL启用 端口：587/465）
            SMTP服务器需要身份验证
            126邮箱                                      HotMail

            POP3服务器地址:pop.126.com（端口：110）            POP3服务器地址：pop.live.com （端口：995）

            SMTP服务器地址:smtp.126.com（端口：25）            SMTP服务器地址：smtp.live.com （端口：587）


            china.com:                                  139邮箱
            POP3服务器地址:pop.china.com（端口：110）         POP3服务器地址：POP.139.com（端口：110） 
            SMTP服务器地址:smtp.china.com（端口：25）         SMTP服务器地址：SMTP.139.com(端口：25)
         */
    }
}
