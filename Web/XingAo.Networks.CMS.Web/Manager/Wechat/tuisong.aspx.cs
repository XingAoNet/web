using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;
using System.Text;
using System.Xml;
using System.Security.Cryptography;
using XingAo.Networks.CMS.Common;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;

namespace XingAo.Networks.CMS.Web.Manager.Wechat
{
    public partial class tuisong : System.Web.UI.Page
    {

        const string Token = "XingAo";
        //"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx78de4d812b46e50d&secret=0a6b9b32ec7701e572425089b321fed8"
        protected void Page_Load(object sender, EventArgs e)
        {
            //string postStr = "";
            //if (Request.HttpMethod.ToLower() == "post")
            //{
            //    Stream s = System.Web.HttpContext.Current.Request.InputStream;
            //    byte[] b = new byte[s.Length];
            //    s.Read(b, 0, (int)s.Length);
            //    postStr = Encoding.UTF8.GetString(b);

            //    if (!string.IsNullOrEmpty(postStr))
            //    {
            //        //封装请求类
            //        XmlDocument doc = new XmlDocument();
            //        doc.LoadXml(postStr);
            //        XmlElement rootElement = doc.DocumentElement;

            //        XmlNode MsgType = rootElement.SelectSingleNode("MsgType");

            //        RequestXML requestXML = new RequestXML();
            //        requestXML.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
            //        requestXML.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
            //        requestXML.CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;
            //        requestXML.MsgType = MsgType.InnerText;

            //        if (requestXML.MsgType == "text")
            //        {
            //            requestXML.Content = rootElement.SelectSingleNode("Content").InnerText;
            //        }
            //        else if (requestXML.MsgType == "location")
            //        {
            //            requestXML.Location_X = rootElement.SelectSingleNode("Location_X").InnerText;
            //            requestXML.Location_Y = rootElement.SelectSingleNode("Location_Y").InnerText;
            //            requestXML.Scale = rootElement.SelectSingleNode("Scale").InnerText;
            //            requestXML.Label = rootElement.SelectSingleNode("Label").InnerText;
            //        }
            //        else if (requestXML.MsgType == "image")
            //        {
            //            requestXML.PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText;
            //        }

            //        //回复消息
            //        ResponseMsg(requestXML);
            //    }
            //}
            //else
            //{
            //    Valid();
            //}
        }

        /// <summary>
        /// 验证微信签名
        /// </summary>
        /// * 将token、timestamp、nonce三个参数进行字典序排序
        /// * 将三个参数字符串拼接成一个字符串进行sha1加密
        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
        /// <returns></returns>
        private bool CheckSignature()
        {
            string signature = Request.QueryString["signature"];
            string timestamp = Request.QueryString["timestamp"];
            string nonce = Request.QueryString["nonce"];
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Valid()
        {
            string echoStr = Request.QueryString["echoStr"];
            if (CheckSignature())
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    Response.Write(echoStr);
                    Response.End();
                }
            }
        }

        /// <summary>
        /// 回复消息(微信信息返回)
        /// </summary>
        /// <param name="weixinXML"></param>
        private string ResponseMsg(RequestXML requestXML)
        {
            try
            {
                string resxml = "";
                if (requestXML.MsgType == "text")
                {
                    resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + requestXML.Content + "]]></Content><FuncFlag>0</FuncFlag></xml>";
                }
                //else if (requestXML.MsgType == "location")
                //{
                //    string city = GetMapInfo(requestXML.Location_X, requestXML.Location_Y);
                //    if (city == "0")
                //    {
                //        resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[Sorry，没有找到" + city + " 的相关产品信息]]></Content><FuncFlag>0</FuncFlag></xml>";
                //    }
                //    else
                //    {
                //        resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[Sorry，这是 " + city + " 的产品信息：圈圈叉叉]]></Content><FuncFlag>0</FuncFlag></xml>";
                //    }
                //}
                //else if (requestXML.MsgType == "image")
                //{
                //    //返回10以内条
                //    int size = 10;
                //    resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + size + "</ArticleCount><Articles>";
                //    List<string> list = new List<string>();
                //    //假如有20条查询的返回结果
                //    for (int i = 0; i < 20; i++)
                //    {
                //        list.Add("1");
                //    }
                //    string[] piclist = new string[] { "/Abstract_Pencil_Scribble_Background_Vector_main.jpg", "/balloon_tree.jpg", "/bloom.jpg", "/colorful_flowers.jpg", "/colorful_summer_flower.jpg", "/fall.jpg", "/fall_tree.jpg", "/growing_flowers.jpg", "/shoes_illustration.jpg", "/splashed_tree.jpg" };

                //    for (int i = 0; i < size && i < list.Count; i++)
                //    {
                //        resxml += "<item><Title><![CDATA[沈阳-黑龙江]]></Title><Description><![CDATA[元旦特价：￥300 市场价：￥400]]></Description><PicUrl><![CDATA[" + "http://www.hougelou.com" + piclist[i] + "]]></PicUrl><Url><![CDATA[http://www.hougelou.com]]></Url></item>";
                //    }
                //    resxml += "</Articles><FuncFlag>1</FuncFlag></xml>";
                //}
                //WriteTxt(resxml);
                return resxml;
            }
            catch (Exception ex)
            {
                WriteTxt("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());
            }
            return "";
        }

        /// <summary>
        /// unix时间转换为datetime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        private DateTime UnixTimeToTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// datetime转换为unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 记录bug，以便调试
        /// </summary>
        /// <returns></returns>
        public bool WriteTxt(string str)
        {
            try
            {
                FileStream fs = new FileStream(Server.MapPath("/bugLog.txt"), FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.WriteLine(str);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
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
                        XmlNode childNode = xmlResults[i];
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
                WriteTxt("map异常:" + ex.Message.ToString() + "Struck:" + ex.StackTrace.ToString());
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
        public string webRequestPost(string url, string param)
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

        public static bool ExecLogin(string strMPAccount,string strMPPassword)
        {
            bool result = false;
            string password = GetMd5Str32(strMPPassword).ToUpper();  //注意转换为大写
            string padata = "username=" + System.Web.HttpUtility.UrlEncode(strMPAccount) + "&pwd=" + password + "&imgcode=&f=json";
            string url = "http://mp.weixin.qq.com/cgi-bin/login?lang=zh_CN";//请求登录的URL
            try
            {
                CookieContainer cc = new CookieContainer();//接收缓存
                byte[] byteArray = Encoding.UTF8.GetBytes(padata); // 转化
                HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);
                webRequest2.CookieContainer = cc;
                webRequest2.Method = "POST";
                webRequest2.ContentType = "application/x-www-form-urlencoded";
                webRequest2.Referer = "http://mp.weixin.qq.com/cgi-bin/login?lang=zh_CN";
                webRequest2.ContentLength = byteArray.Length;
                Stream newStream = webRequest2.GetRequestStream();
                // Send the data.
                newStream.Write(byteArray, 0, byteArray.Length); //写入参数
                newStream.Close();
                HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
                StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);
                string text2 = sr2.ReadToEnd();

                //此处用到了newtonsoft来序列化
               WeiXinRetInfo retinfo =JSONHelper.JsonToObject<WeiXinRetInfo>(text2);

                string token = string.Empty;
                if (retinfo.ErrMsg.Length > 0)
                {
                    token = retinfo.ErrMsg.Split(new char[] { '&' })[2].Split(new char[] { '=' })[1].ToString();//取得令牌
                    LoginInfo.LoginCookie = cc;
                    LoginInfo.CreateDate = DateTime.Now;
                    LoginInfo.Token = token;
                    result = true;
                }
            }
            catch (Exception ex)
            {
              throw new Exception("Erro[" + DateTime.Now.ToString() + "]" + ex.StackTrace);
            }
            return result;
        }

        public static class LoginInfo
        {
            /// <summary>
            /// 登录后得到的令牌
            /// </summary> 
            public static string Token { get; set; }
            /// <summary>
            /// 登录后得到的cookie
            /// </summary>
            public static CookieContainer LoginCookie { get; set; }
            /// <summary>
            /// 创建时间
            /// </summary>
            public static DateTime CreateDate { get; set; }

        }

        //发送信息

        public static bool SendMessage(string Message, string fakeid)
        {
            bool result = false;
            CookieContainer cookie = null;
            string token =null;

            //此处的作用是判断Cookie是否过期如果过期就重新获取，获取cookie的方法本人在.net 实现微信公众平台的主动推送信息中有源码。大家可以去看一下。这里就不再粘源代码了。

            if (null == LoginInfo.LoginCookie || LoginInfo.CreateDate.AddMinutes(60) < DateTime.Now)
            {
                ExecLogin("XingAoNet", "xingao123");
            }
            cookie = LoginInfo.LoginCookie;//取得cookie
            token = LoginInfo.Token;//取得token

            string strMsg = System.Web.HttpUtility.UrlEncode(Message);
            string padate = "type=1&content=" + strMsg + "&error=false&tofakeid=" + fakeid + "&token=" + token + "&ajax=1";
            string url = "https://mp.weixin.qq.com/cgi-bin/singlesend?t=ajax-response&lang=zh_CN";

            byte[] byteArray = Encoding.UTF8.GetBytes(padate); // 转化

            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(url);

            webRequest2.CookieContainer = cookie; //登录时得到的缓存

            webRequest2.Referer = "https://mp.weixin.qq.com/cgi-bin/singlemsgpage?token=" + token + "&fromfakeid=" + fakeid + "&msgid=&source=&count=20&t=wxm-singlechat&lang=zh_CN";

            webRequest2.Method = "POST";

            webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";

            webRequest2.ContentType = "application/x-www-form-urlencoded";

            webRequest2.ContentLength = byteArray.Length;

            Stream newStream = webRequest2.GetRequestStream();

            // Send the data. 
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

        public string AccessToken(string appid, string secret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "get";
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
            return sr.ReadToEnd();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           ExecLogin(TextBox1.Text, TextBox2.Text);
            TextBox4.Text=LoginInfo.Token;
            TxtAccessToken.Text = AccessToken("wx78de4d812b46e50d", "0a6b9b32ec7701e572425089b321fed8");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //SubscribeMP();
            //SendMessage(TextBox3.Text, "2611039617");
            RequestXML requestXML = new RequestXML();
            requestXML.ToUserName = TextBox5.Text;
            requestXML.FromUserName = TextBox4.Text;
            requestXML.CreateTime = ConvertDateTimeInt(DateTime.Now).ToString();
            requestXML.MsgType ="text";

            if (requestXML.MsgType == "text")
            {
                requestXML.Content = TextBox3.Text;
            }


            string padata = ResponseMsg(requestXML);
            string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + TxtAccessToken.Text.Trim();//请求的URL    
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(padata); // 转化    
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.ContentLength = byteArray.Length;

                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length); //写入参数    
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                _lblMsg2.Text = "返回结果：" + sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }    

        }

        public static string GetOpenidByFakeid(string fakeid)
        {
            try
            {
                CookieContainer cookie = null;
                string token = null;


                cookie = LoginInfo.LoginCookie;//取得cookie
                token = LoginInfo.Token;//取得token
                string Url = "https://mp.weixin.qq.com/cgi-bin/singlesendpage?t=message/send&action=index&tofakeid=" + fakeid + "&token=" + token + "&lang=zh_CN";
                HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(Url);
                webRequest2.CookieContainer = cookie;
                webRequest2.ContentType = "text/html; charset=UTF-8";
                webRequest2.Method = "GET";
                webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                webRequest2.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
                StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
                string text2 = sr2.ReadToEnd();
                
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public static void SubscribeMP()
        {

            try
            {
                CookieContainer cookie = null;
                string token = null;
                cookie = LoginInfo.LoginCookie;//取得cookie
                token = LoginInfo.Token;//取得token


                /*获取用户信息的url，这里有几个参数给大家讲一下，1.token此参数为上面的token 2.pagesize此参数为每一页显示的记录条数


                3.pageid为当前的页数，4.groupid为微信公众平台的用户分组的组id，当然这也是我的猜想不一定正确*/
                            //https://mp.weixin.qq.com/cgi-bin/contactmanage?t=user/index&pagesize=10&pageidx=0&type=0&groupid=100&token=284786873&lang=zh_CN
                string Url = "https://mp.weixin.qq.com/cgi-bin/contactmanage?t=user/index&token=" + token + "&pagesize=10&pageidx=0&type=0&groupid=100&lang=zh_CN";
                HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(Url);
                webRequest2.CookieContainer = cookie;
                webRequest2.ContentType = "text/html; charset=uft-8";
                webRequest2.Method = "GET";
                webRequest2.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
                webRequest2.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();

                StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
                string text2 = sr2.ReadToEnd();
                MatchCollection mc;


                //由于此方法获取过来的信息是一个html网页所以此处使用了正则表达式，注意：（此正则表达式只是获取了fakeid的信息如果想获得一些其他的信息修改此处的正则表达式就可以了。）
                Regex r = new Regex(@"(?<cgiData>cgiData=(?<data>\{[\s\S]*?\});)"); //定义一个Regex对象实例
                string pageIdxReg = @"pageIdx:(.*?),";
                string pageCountReg = @"pageCount:(.*?),";
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
                    List<contacts> friendsList2 = JSONHelper.JsonToObject<List<contacts>>(friendsList);

                    string groupsList = new Regex(groupsListReg).Match(data).Groups["data"].Value;
                    List<groups> groupsList2 = JSONHelper.JsonToObject<List<groups>>(groupsList);

                }
        
               

            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox6.Text = GetOpenidByFakeid(TextBox5.Text);
        }



    }


    public class groups
    {
        public int id { get; set; }
        public string name { get; set; }
        public int cnt { get; set; }
    }

    public class contacts
    {
        public Int64 id { get; set; }
        public string nick_name { get; set; }
        public int group_id { get; set; }
        public string remark_name { get; set; }
        
    }

    public class WeiXinRetInfo
    {
        public string ErrMsg { get; set; }
    }

    //微信请求类
    public class RequestXML
    {
        private string toUserName;
        /// <summary>
        /// 消息接收方微信号，一般为公众平台账号微信号
        /// </summary>
        public string ToUserName
        {
            get { return toUserName; }
            set { toUserName = value; }
        }

        private string fromUserName;
        /// <summary>
        /// 消息发送方微信号
        /// </summary>
        public string FromUserName
        {
            get { return fromUserName; }
            set { fromUserName = value; }
        }

        private string createTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        private string msgType;
        /// <summary>
        /// 信息类型 地理位置:location,文本消息:text,消息类型:image
        /// </summary>
        public string MsgType
        {
            get { return msgType; }
            set { msgType = value; }
        }

        private string content;
        /// <summary>
        /// 信息内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string location_X;
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public string Location_X
        {
            get { return location_X; }
            set { location_X = value; }
        }

        private string location_Y;
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Location_Y
        {
            get { return location_Y; }
            set { location_Y = value; }
        }

        private string scale;
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public string Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        private string label;
        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        private string picUrl;
        /// <summary>
        /// 图片链接，开发者可以用HTTP GET获取
        /// </summary>
        public string PicUrl
        {
            get { return picUrl; }
            set { picUrl = value; }
        }
    }
}