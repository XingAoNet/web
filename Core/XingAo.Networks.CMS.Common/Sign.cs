/******************************************************************
* Create By:卢小阳
* Create Time:2013/8/21 12:18:57
* Update By:
* Last Update Time:
* Update Description:
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XingAo.Networks.CMS.Common
{
    /// <summary>
    /// 签名生成类
    /// </summary>
    public static class Sign
    {
        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="Params">要验证的参数集合</param>
        /// <param name="AppKey">app帐户</param>
        /// <param name="AppCode">app密钥</param>
        /// <param name="TimeSpan">回传时间轴参数</param>
        /// <returns></returns>
        public static string MakeSign(Dictionary<String, String> Params, string AppKey, string AppCode, out long TimeSpan)
        {
            TimeSpan = DateTime.Now.Ticks;
            return MakeSign(Params, AppKey, AppCode,TimeSpan.ToString());
        }
       /// <summary>
        /// 直接从appconfig内取AppKey AppCode来生成签名
        /// </summary>
        /// <param name="Params">要验证的参数集合</param>
        /// <param name="TimeSpan">回传时间轴参数</param>
        /// <param name="AppKey">app帐户</param>
        /// <param name="AppCode">app密钥(ras中的公钥)</param>
        /// <returns></returns>
        public static string MakeSign(Dictionary<String, String> Params, out long TimeSpan,out string AppKey)
        {
             AppKey = ConfigHelper.GetConfigString("AppKey");
            string AppCode = ConfigHelper.GetConfigString("AppCode");
            TimeSpan = DateTime.Now.Ticks;            
            return MakeSign(Params, AppKey, AppCode, TimeSpan.ToString());
        }
        /// <summary>
        /// 生成签名(使用公钥生成)
        /// </summary>
        /// <param name="Params">要验证的参数集合</param>
        /// <param name="AppKey">app帐户</param>
        /// <param name="AppCode">app密钥(ras中的公钥)</param>
        /// <param name="TimeSpan">时间轴</param>
        /// <returns></returns>
        public static string MakeSign(Dictionary<String, String> Params, string AppKey, string AppCode, string TimeSpan)
        {

            Params.Add("AppId", AppKey);
            Params.Add("AppCode", AppCode.CodeToHtml());
            Params.Add("TimeSpan", TimeSpan);
            RSAEncrypt ras=new RSAEncrypt();
            IEnumerable<KeyValuePair<string, string>> Ioe = Params.OrderBy(p => p.Key);
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in Ioe)
            {
                sb.Append(RepStr(kv.Key) + "=" + RepStr(kv.Value) + "|");
            }
            ras.PublicKey= ConfigHelper.GetConfigString("AppCode").CodeToHtml();
            return  ras.EncryptString(sb.ToString().ToMD5Two());
        }
        /// <summary>
        /// 验证签名是否正确(服务端专用)
        /// </summary>
        /// <param name="Sign">客户端提交上来的签名</param>
        /// <param name="Params">生成签名时的参数集</param>
        /// <param name="AppKey">生成签名时的app帐户</param>
        /// <param name="AppCode">app帐户对应的公钥</param>
        /// <param name="ServerPrivateCode">app帐户对应的私钥</param>
        /// <param name="TimeSpan">生成签名时的时间轴</param>
        /// <returns></returns>
        public static bool VerifySign(string Sign,Dictionary<string, string> Params, string AppKey,string AppCode,string ServerPrivateCode, string TimeSpan)
        {
            Params.Add("AppId", AppKey);
            Params.Add("AppCode", AppCode.CodeToHtml());
            Params.Add("TimeSpan", TimeSpan);
            RSAEncrypt ras = new RSAEncrypt();
            IEnumerable<KeyValuePair<string, string>> Ioe = Params.OrderBy(p => p.Key);
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in Ioe)
            {
                sb.Append(RepStr(kv.Key) + "=" + RepStr(kv.Value) + "|");
            }
            ras.PrivateKey = ServerPrivateCode;
            Sign = ras.DecryptString(Sign);//使用服务器私钥给客户端签名解密
            return (Sign == sb.ToString().ToMD5Two()&&Sign!="");
        }
        
        /// <summary>
        /// 字符过滤
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string RepStr(string s)
        {
            return s.Replace("=", "~~").Replace("|","~").ToLower();
        }
    } 
    
    /// <summary>
    /// 签名类
    /// </summary>
    public class SMSSign
    {
        /// <summary>
        /// 客户端与服务端时间差
        /// </summary>
        public static long TimeOffset = -99999;
        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="UserKey">用户名</param>
        /// <param name="UserPwd">密码</param>
        /// <param name="par">所有要提交的参数【不包括用户名与密码以及签名值】（调用此方法后将返回签名）</param>
        /// <param name="TimeSpan">返回时间</param>
        /// <returns></returns>
        public static string MakeSign(string UserKey, string UserPwd, ref Dictionary<string, string> par, out string TimeSpan)
        {
            if (TimeOffset == -99999)//与服务器时间校正
            {
                try
                {
                    // long start = DateTime.UtcNow.Ticks;
                    string ServerTime = new WebUtils().DoGet(ConfigHelper.GetConfigString("PostUrl") + "API/GetServerTime", null);//调用接口来取服务器时间
                    long now = DateTime.UtcNow.Ticks;//取当前电脑时间
                    TimeOffset = long.Parse(ServerTime) - now;//-start);//计算出服务器时间与当前时间的差
                }
                catch { TimeOffset = 0; }
            }
            par.Add("UserKey", UserKey);
            //par.Add("UserPwd", UserPwd);
            TimeSpan = DateTime.UtcNow.AddTicks(TimeOffset).Ticks.ToString();//取本机时间再加上与服务器的时间差
            par.Add("TimeSpan", TimeSpan);
            IOrderedEnumerable<KeyValuePair<string, string>> parStor = par.OrderBy(p => p.Key);//对所有参数（包括用户名与密码，但不包括签名）
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> item in parStor)
            {
                sb.Append(item.Key + "=" + item.Value + "&");
            }
            string Sign = sb.Append(UserPwd.ToMD5Two()).ToString().ToMD5Two();
            //par.Remove("UserPwd");//生成签名后移除密码（防止泄漏）
            par.Add("Sign", Sign);
            return Sign;
        }
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="par">客户端提交的所有参数集【不包括用户密码】</param>
        /// <param name="ClientSendSign"></param>
        /// <param name="TimeSpan"></param>
        /// <returns></returns>
        public static bool ValidSign(string UserKey, string UserPwd, Dictionary<string, string> par, string ClientSendSign, out string ErrMsg)
        {
            ErrMsg = "";
            long ServerTimeSpan = DateTime.UtcNow.Ticks;
            if (!par.ContainsKey("TimeSpan"))
            {
                ErrMsg = "数据不完整，缺少TimeSpan！";
                return false;
            }
            long ClientTimeSpan = long.Parse(par["TimeSpan"]);
            if (Math.Abs(new TimeSpan(ServerTimeSpan).Subtract(new TimeSpan(ClientTimeSpan)).TotalSeconds) > 10)
            {
                ErrMsg = "请求超时！客户端请求必须在10秒内向服务器提交！";
                return false;
            }
            else
            {
                par.Remove("UserKey");
                par.Remove("UserPwd");
                par.Remove("Sign");
                par.Add("UserKey", UserKey);
                //par.Add("UserPwd", UserPwd);               
                IOrderedEnumerable<KeyValuePair<string, string>> parStor = par.OrderBy(p => p.Key);
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, string> item in parStor)
                {
                    sb.Append(item.Key + "=" + item.Value + "&");
                }
                string Sign = sb.Append(UserPwd.ToMD5Two()).ToString().ToMD5Two();
                if (Sign == ClientSendSign)
                {
                    return true;
                }
                else
                {
                    ErrMsg = "签名错误！";
                    return false;
                }
            }
        }
    }
}
