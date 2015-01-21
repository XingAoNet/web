using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using XingAo.Core;

namespace XingAo.Networks.WeChat
{
    public class ActionOption
    {

        /// <summary>
        /// 返回指定用户Token
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static LoginInfo GetToken(string account, string pwd)
        {
            Dictionary<string, LoginInfo> AccountList = new Dictionary<string, LoginInfo>();
            if (HttpContext.Current.Session["WeiXinAccount"] != null)
            {
                AccountList = HttpContext.Current.Session["WeiXinAccount"] as Dictionary<string, LoginInfo>;
                if (AccountList.Keys.Contains(account))
                    return AccountList[account];
            }
            LoginInfo info = Login(account, pwd);
            if (info != null)
            {
                AccountList.Add(account, info);
            }
            HttpContext.Current.Session["WeiXinAccount"] = AccountList;
            return info;
        }

        #region SubscribeMP用户组及成员
        public static CgiData SubscribeMP(LoginInfo loginInfo)
        {
            return SubscribeMP(loginInfo, 10, 0, 0);
        }

        public static CgiData SubscribeMP(LoginInfo loginInfo, int pageidx, int groupid)
        {
            return SubscribeMP(loginInfo, 10, pageidx, groupid);
        }

        public static CgiData SubscribeMP(LoginInfo loginInfo, int PageSize, int pageidx, int groupid)
        {
            CgiData cg = new CgiData();
            try
            {
                if (loginInfo == null)
                    return cg;
                string Url = "https://mp.weixin.qq.com/cgi-bin/contactmanage?t=user/index&token=" + loginInfo.Token + "&pagesize=" + PageSize + "&pageidx=" + pageidx + "&type=0&groupid=" + groupid + "&lang=zh_CN";
                HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(Url);
                webRequest2.CookieContainer = loginInfo.LoginCookie;
                webRequest2.ContentType = "text/html; charset=uft-8";
                webRequest2.Method = "get";
                webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                webRequest2.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();

                StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
                string text2 = sr2.ReadToEnd();
                MatchCollection mc;

                //由于此方法获取过来的信息是一个html网页所以此处使用了正则表达式，注意：（此正则表达式只是获取了fakeid的信息如果想获得一些其他的信息修改此处的正则表达式就可以了。）
                Regex r = new Regex(@"(?<cgiData>cgiData=(?<data>\{[\s\S]*?\});)"); //定义一个Regex对象实例
                string pageIdxReg = @"pageIdx : (?<pageIdx>\d*?),";
                string pageCountReg = @"pageCount : (?<pageCount>\d*?),";
                string pageSizeReg = @"pageSize:(.*?),";
                string currentGroupIdReg = @"currentGroupId:(.*?),";
                string typeReg = @"type:(.*?),";
                string groupsListReg = @"""groups"":(?<data>\[.*\])";
                string friendsListReg = @"""contacts"":(?<data>\[.*\])";
                mc = r.Matches(text2);
                if (mc.Count > 0)
                {
                    string data = mc[0].Groups["data"].Value;
                    string friendsList = new Regex(friendsListReg).Match(data).Groups["data"].Value;
                    cg.friendsList = JSONHelper.JsonToObject<List<Contacts>>(friendsList);
                   
                    string groupsList = new Regex(groupsListReg).Match(data).Groups["data"].Value;
                    cg.groupsList = JSONHelper.JsonToObject<List<Groups>>(groupsList);

                    cg.pageIdx = new Regex(pageIdxReg).Match(data).Groups["pageIdx"].Value.ObjToInt(0);
                    cg.pageCount = new Regex(pageCountReg).Match(data).Groups["pageCount"].Value.ObjToInt(1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
            return cg;
        }
        #endregion

        #region 发送消息
        public static bool SendMessage(LoginInfo loginInfo,string Message, string fakeid)
        {
            bool result = false;
            string strMsg = System.Web.HttpUtility.UrlEncode(Message);
            string padate = "type=1&content=" + strMsg + "&error=false&tofakeid=" + fakeid + "&token=" + loginInfo.Token + "&ajax=1";
            string url = "https://mp.weixin.qq.com/cgi-bin/singlesend?t=ajax-response&lang=zh_CN";
            byte[] byteArray = Encoding.UTF8.GetBytes(padate); // 转化
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);
            webRequest2.CookieContainer = loginInfo.LoginCookie; //登录时得到的缓存 
            webRequest2.Referer = "https://mp.weixin.qq.com/cgi-bin/singlesendpage?t=message/send&token=" + loginInfo.Token + "&tofakeid=" + fakeid + "&lang=zh_CN";
            webRequest2.Method = "POST";
            webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            webRequest2.ContentLength = byteArray.Length;
            Stream newStream = webRequest2.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length); //写入参数 
            newStream.Close();
            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);
            string text2 = sr2.ReadToEnd();
            if (text2.Contains("ok"))
            {
                result = true;
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 32位Md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string GetMd5Str32(string str)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            char[] temp = str.ToCharArray();
            byte[] buf = new byte[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                buf[i] = (byte)temp[i];
            }
            byte[] data = md5Hasher.ComputeHash(buf);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 微信登录
        /// </summary>
        /// <param name="strMPAccount"></param>
        /// <param name="strMPPassword"></param>
        /// <returns></returns>
        public static LoginInfo Login(string strMPAccount, string strMPPassword)
        {
            string password = GetMd5Str32(strMPPassword).ToUpper();  //注意转换为大写
            string padata = "username=" + System.Web.HttpUtility.UrlEncode(strMPAccount) + "&pwd=" + password + "&imgcode=&f=json";
            string url = "http://mp.weixin.qq.com/cgi-bin/login?lang=zh_CN";//请求登录的URL
            try
            {
                CookieContainer cc = new CookieContainer();//接收缓存
                string text2 = GetHttpData(url, padata, cc);
                //此处用到了newtonsoft来序列化
                RetInfo retinfo = JSONHelper.JsonToObject<RetInfo>(text2);

                string token = string.Empty;
                if (retinfo.ErrMsg.Length > 0)
                {
                    token = retinfo.ErrMsg.Split(new char[] { '&' })[2].Split(new char[] { '=' })[1].ToString();//取得令牌
                    LoginInfo loginInfo = new WeChat.LoginInfo();
                    loginInfo.LoginCookie = cc;
                    loginInfo.CreateDate = DateTime.Now;
                    loginInfo.Token = token;
                    return loginInfo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro[" + DateTime.Now.ToString() + "]" + ex.StackTrace);
            }
            return null;
        }

        /// <summary>
        /// 请求数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="Params"></param>
        /// <param name="Method"></param>
        /// <returns></returns>
        private static string GetHttpData(string url, string Params,CookieContainer cc ,string Method = "POST")
        {
            string GetData = string.Empty;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(Params); // 转化
                HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);
                webRequest2.CookieContainer = cc;
                webRequest2.Method = Method;
                webRequest2.ContentType = "application/x-www-form-urlencoded";
                webRequest2.Referer = "http://mp.weixin.qq.com/cgi-bin/login?lang=zh_CN";
                webRequest2.ContentLength = byteArray.Length;
                Stream newStream = webRequest2.GetRequestStream();


                newStream.Write(byteArray, 0, byteArray.Length); //写入参数
                newStream.Close();
                HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
                StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);
                GetData=sr2.ReadToEnd();
            }
            catch (Exception ex)
            {
                GetData=ex.Message;
            }
            return GetData;
        }

        #region 微信接口

        /// <summary>
        /// datetime转换为unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 调用百度地图，返回坐标信息
        /// </summary>
        /// <param name="y">经度</param>
        /// <param name="x">纬度</param>
        /// <returns></returns>
        public string GetMapInfo(string x, string y)
        {
            try
            {
                string res = string.Empty;
                string parame = string.Empty;
                string url = "http://maps.googleapis.com/maps/api/geocode/xml";
                parame = "latlng=" + x + "," + y + "&language=zh-CN&sensor=false";//此key为个人申请
                res = webRequestPost(url, parame);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(res);
                XmlElement rootElement = doc.DocumentElement;
                string Status = rootElement.SelectSingleNode("status").InnerText;
                if (Status == "OK")
                {
                    //仅获取城市
                    XmlNodeList xmlResults = rootElement.SelectSingleNode("/GeocodeResponse").ChildNodes;
                    for (int i = 0; i < xmlResults.Count; i++)
                    {
                        XmlNode childNode =xmlResults[i];
                        if (childNode.Name == "status")
                        {
                            continue;
                        }
                        string city = "0";
                        for (int w = 0; w < childNode.ChildNodes.Count; w++)
                        {
                            for (int q = 0; q < childNode.ChildNodes[w].ChildNodes.Count; q++)
                            {
                                XmlNode childeTwo = childNode.ChildNodes[w].ChildNodes[q];
                                if (childeTwo.Name == "long_name")
                                {
                                    city = childeTwo.InnerText;
                                }
                                else if (childeTwo.InnerText == "locality")
                                {
                                    return city;
                                }
                            }
                        }
                        return city;
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteTxt("map异常:" + ex.Message.ToString() + "Struck:" + ex.StackTrace.ToString());
                return "0";
            }
            return "0";
        }

        /// <summary>
        /// Post 提交调用抓取
        /// </summary>
        /// <param name="url">提交地址</param>
        /// <param name="param">参数</param>
        /// <returns>string</returns>
        public static string webRequestPost(string url, string param)
        {
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(param);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url + "?" + param);
            req.Method = "Post";
            req.Timeout = 120 * 1000;
            req.ContentType = "application/x-www-form-urlencoded;";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Flush();
            }
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理
                Stream strm = wr.GetResponseStream();
                StreamReader sr = new StreamReader(strm, System.Text.Encoding.UTF8);
                string line;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line + System.Environment.NewLine);
                }
                sr.Close();
                strm.Close();
                return sb.ToString();
            }
        }


        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="mysign">返回我方生成的签名</param>
        /// <returns></returns>
        public static bool CheckSign(string Token,string signature,string timestamp,string nonce,out string mysign)
        {
            SortedList li = new SortedList();
            li.Add(Token, Token);
            li.Add(timestamp, timestamp);
            li.Add(nonce, nonce);
            StringBuilder signtext = new StringBuilder();
            foreach (string key in li.Keys)
            {
                signtext.Append(key);
            }
            mysign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signtext.ToString(), "SHA1").ToLower();
            return (mysign == signature);

        }
        #endregion

        /// <summary>
        /// 返回AccessToken
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static string AccessToken(string appid, string secret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "get";
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
            return sr.ReadToEnd();   
        }


        public static string getFakeid(LoginInfo loginInfo,String openid)
        {
            string Url = "https://mp.weixin.qq.com/cgi-bin/contactmanage?t=wxm-friend&token=" + loginInfo.Token + "&lang=zh_CN&pagesize=10&pageidx=0&type=0&groupid=0";
           
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(Url);
            webRequest2.CookieContainer = loginInfo.LoginCookie;
            webRequest2.ContentType = "text/html; charset=uft-8";
            webRequest2.Method = "get";
            webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();

            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
            string text2 = sr2.ReadToEnd();
            return "";
        }
    }
}
