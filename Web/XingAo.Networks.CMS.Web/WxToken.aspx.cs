using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using System.IO;
using System.Text;
using System.Xml;
using XingAo.Networks.WeChat;
using XingAo.Networks.CMS.Template.Label.SystemLabel;

namespace XingAo.Networks.CMS.Web
{
    public partial class WxToken : System.Web.UI.Page
    {
        public static List<Model.WeiXin_Reply> Replys;
        private string Token = "";//申请时的token
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Token = Request.QueryString["n"];
                if (Request.HttpMethod.ToLower() == "post")
                {
                    #region
                    string postStr = "";
                    Stream s = Request.InputStream;
                    byte[] b = new byte[s.Length];
                    s.Read(b, 0, (int)s.Length);
                    postStr = Encoding.UTF8.GetString(b);

                    if (!string.IsNullOrEmpty(postStr))
                    {
                        //封装请求类
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(postStr);
                        XmlElement rootElement = doc.DocumentElement;

                        XmlNode MsgType = rootElement.SelectSingleNode("MsgType");

                        RequestXML requestXML = new RequestXML();
                        requestXML.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                        requestXML.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                        requestXML.CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;

                        requestXML.MsgType = MsgType.InnerText;

                        if (requestXML.MsgType == "event")
                        {
                            requestXML.Event = rootElement.SelectSingleNode("Event").InnerText;
                            requestXML.EventKey = rootElement.SelectSingleNode("EventKey").InnerText;
                        }

                        if (requestXML.MsgType == "text")
                        {
                            requestXML.Content = rootElement.SelectSingleNode("Content").InnerText;
                        }
                        else if (requestXML.MsgType == "location")
                        {
                            requestXML.Location_X = rootElement.SelectSingleNode("Location_X").InnerText;
                            requestXML.Location_Y = rootElement.SelectSingleNode("Location_Y").InnerText;
                            requestXML.Scale = rootElement.SelectSingleNode("Scale").InnerText;
                            requestXML.Label = rootElement.SelectSingleNode("Label").InnerText;
                        }
                        else if (requestXML.MsgType == "image")
                        {
                            requestXML.PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText;
                        }

                        //回复消息
                        Response.Write(ResponseMsg(requestXML));
                    }
                    #endregion
                }
                else
                {
                    if (!string.IsNullOrEmpty(Token))
                    {
                        #region
                        string echostr = Request.QueryString["echostr"];
                        string mysign = "";
                        string signature = Request.QueryString["signature"];
                        string timestamp = Request.QueryString["timestamp"];
                        string nonce = Request.QueryString["nonce"];

                        if (ActionOption.CheckSign(Token, signature, timestamp, nonce, out mysign))
                            Response.Write(echostr);
                        else
                        {
                            StringBuilder err = new StringBuilder();
                            err.AppendLine("datetime=" + DateTime.Now.ToString());
                            err.AppendLine("signature=" + Request.QueryString["signature"]);
                            err.AppendLine("timestamp=" + Request.QueryString["timestamp"]);
                            err.AppendLine("nonce=" + Request.QueryString["nonce"]);
                            err.AppendLine("mysign=" + mysign);
                            System.IO.File.WriteAllText(Server.MapPath("/weixin/err.txt"), err.ToString());
                        }
                        #endregion
                    }

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
                if (Replys == null)
                    Replys = new UnitOfWork().FindAll<Model.WeiXin_Reply>().ToList();

                Model.WeiXin_Reply Reply;
                string resxml = "";
               
                switch (requestXML.MsgType)
                {
                    case "text":
                        Reply = Replys.Where(c => c.ReplyKey == requestXML.Content).FirstOrDefault();
                        resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ActionOption.ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + Reply.ReplyContent + "]]></Content><FuncFlag>0</FuncFlag></xml>";
                        break;
                    case "image":
                    case "event":
                        Reply = Replys.Where(c => c.ReplyKey == requestXML.EventKey).FirstOrDefault();
                        StringBuilder josn = new StringBuilder();
                         josn.Append("<xml>");
                        josn.Append("<ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName>");
                        josn.Append("<FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName>");
                        josn.Append("<CreateTime>" + ActionOption.ConvertDateTimeInt(DateTime.Now) + "</CreateTime>");
                        josn.Append("<MsgType><![CDATA[news]]></MsgType>");
                        josn.Append("<ArticleCount>1</ArticleCount>");
                        josn.Append("<Articles>");
                        josn.Append("<item>");
                        josn.Append("<Title><![CDATA[" + Reply.Title+ "]]></Title>");
                        josn.Append("<Description><![CDATA[" + Reply.Description + "]]></Description>");
                        if (!string.IsNullOrEmpty(Reply.PicUrl))
                            josn.Append("<PicUrl><![CDATA[" + SiteConfig.GetSiteUrl()+ Reply.PicUrl + "]]></PicUrl>");
                        if (!string.IsNullOrEmpty(Reply.Url))
                        {
                            josn.Append("<Url><![CDATA[" + (Reply.Url.ToLower().IndexOf("http://") > -1 ? "" : SiteConfig.GetSiteUrl()) + Reply.Url + "]]></Url>");
                        }
                        josn.Append("</item>");
                        josn.Append("</Articles>");
                        josn.Append("</xml> ");
                        if (josn.ToString().Length > 0)
                            resxml = josn.ToString();
                        break;
                }


                return resxml;
            }
            catch
            {
                //WriteTxt("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());
            }
            return "";
        }
    }
}