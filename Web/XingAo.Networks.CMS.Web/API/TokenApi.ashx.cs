using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using XingAo.Networks.WeChat;
using System.Net;
using System.Web.UI;
using XingAo.Core.Data;
using XingAo.Core;
using XingAo.Networks.CMS.Model;
using XingAo.Networks.WeChat.Location;

namespace XingAo.Networks.CMS.Web.Api
{
    /// <summary>
    /// TokenApi 的摘要说明
    /// </summary>
    public class TokenApi :Page, IHttpHandler
    {
        public static List<Model.WeiXin_Account> Accounts = null;
        private string Token = "";
        HttpRequest request =null;
        HttpResponse response = null;
        HttpServerUtility server = null;
        UnitOfWork uk = new UnitOfWork();
        public new void ProcessRequest(HttpContext hc)
        {
            request = hc.Request;
            response = hc.Response;
            server = hc.Server;
            response.ContentType = "text/plain";

            Token = request.QueryString["n"];
            if (request.HttpMethod.ToLower() == "post")
            {
                #region
                string postStr = "";
                Stream s = request.InputStream;
                byte[] b = new byte[s.Length];
                s.Read(b, 0, (int)s.Length);
                postStr = Encoding.UTF8.GetString(b);

                if (!string.IsNullOrEmpty(postStr))
                {
                    #region 封装请求类
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

                    if (requestXML.MsgType == "link")
                    {
                        requestXML.Url = rootElement.SelectSingleNode("url").InnerText;
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
                    #endregion
                    //回复消息
                    response.Write(ResponseMsg(requestXML));
                }
                #endregion
            }
            else
            {
                if (!string.IsNullOrEmpty(Token))
                {
                    #region 验证签名
                    string echostr = request.QueryString["echostr"];
                    string mysign = "";
                    string signature = request.QueryString["signature"];
                    string timestamp = request.QueryString["timestamp"];
                    string nonce = request.QueryString["nonce"];

                    if (ActionOption.CheckSign(Token, signature, timestamp, nonce, out mysign))
                        response.Write(echostr);
                    else
                    {
                        StringBuilder err = new StringBuilder();
                        err.AppendLine("datetime=" + DateTime.Now.ToString());
                        err.AppendLine("signature=" + request.QueryString["signature"]);
                        err.AppendLine("timestamp=" + request.QueryString["timestamp"]);
                        err.AppendLine("nonce=" + request.QueryString["nonce"]);
                        err.AppendLine("mysign=" + mysign);
                        System.IO.File.WriteAllText(hc.Server.MapPath("/Api/err.txt"), err.ToString());
                    }
                    #endregion
                }

            }
        }

        #region
        /// <summary>
        /// 回复消息(微信信息返回)
        /// </summary>
        /// <param name="weixinXML"></param>
        private string ResponseMsg(RequestXML requestXML)
        {
            try
            {
                if (Accounts == null)
                    Accounts = uk.FindAll<Model.WeiXin_Account>().ToList();
                Model.WeiXin_Account Account = Accounts.Where(c => c.SourceId == requestXML.ToUserName).FirstOrDefault();

                #region
                if (Account != null)
                {
                    string MsgTyle = "Image";
                    string wxguid = "";
                    List<MsgJson> ContentJsons = new List<MsgJson>();
                    switch (requestXML.MsgType)
                    {
                        case "event":
                            #region 事件处理
                            switch (requestXML.Event)
                            {
                                case "unsubscribe":
                                    #region 取消关注
                                    ContentJsons.Add(new MsgJson("欢迎您下次关注", "什么原因导致您取消关注请用您宝贵的时间已经请发送给我们！", "", "#"));
                                    #endregion
                                    break;
                                case "subscribe":
                                    #region 关注
                                    ContentJsons.Add(new MsgJson("欢迎您的访问", "感谢你的关注", "", "#"));
                                    Model.Attention Atten = uk.FindAll<Model.Attention>().FirstOrDefault();
                                    if (Atten != null)
                                    {
                                        ContentJsons.Clear();
                                        if (Atten.Type == 1)
                                        {
                                            if (string.IsNullOrEmpty(Atten.OtherURL))
                                                ContentJsons.Add(new MsgJson(Atten.Title, Atten.Abstract, Atten.PictuerAdress, "/Mobile/Attention.aspx?id=" + Atten.ID));
                                            else
                                                ContentJsons.Add(new MsgJson(Atten.Title, Atten.Abstract, Atten.PictuerAdress, Atten.OtherURL));
                                        }
                                        else
                                        {
                                            MsgTyle = "Text";
                                            ContentJsons.Add(new MsgJson("",Atten.DetailedContent, "", "#"));
                                        }
                                    }
                                    #endregion
                                    break;
                                case "scan":
                                    MsgTyle = "Text";
                                    break;
                                default:
                                    Model.CustomMenu key = uk.FindAll<Model.CustomMenu>().Where(c => c.WGuid == wxguid && c.Keys == requestXML.EventKey).FirstOrDefault();
                                    ContentJsons = ReplyJson(key.Source, key.Keys, wxguid, 2, out MsgTyle);
                                    break;
                            }
                            #endregion
                            break;
                        case "location":
                            #region

                            double _lx = StringOption.GetobjectToSingle(requestXML.Location_X, 0);
                            double _ly = StringOption.GetobjectToSingle(requestXML.Location_Y, 0);
                            ContentJsons.Add(new MsgJson("你所在位置：" + requestXML.Label, "搜索最近位置", "", "/Mobile/Map.aspx?lng=" + _lx + "&lnt=" + _ly + "&wx=" + wxguid + "&lb=" + server.UrlEncode(requestXML.Label)));
                            double[] ds = CoordDispose.getAround(_lx, _ly, 5000); 
                            Model.LbsMaterial[] locations = uk.FindByFunc<Model.LbsMaterial>(c => c.WGuid == wxguid && c.Longitude > ds[3] && c.Latitude > ds[0] && c.Longitude <= ds[1] && c.Latitude <= ds[2]).Take(3).ToArray();
                            if (locations.Length <= 0)
                                locations = uk.FindAll<Model.LbsMaterial>().Where(c => c.WGuid == wxguid).OrderBy(c => c.Longitude).Take(3).ToArray();

                            foreach (Model.LbsMaterial Material in locations)
                            {
                                ContentJsons.Add(new MsgJson("距" + Material.Title +
                                    CoordDispose.GetDistanceGoogle(new Degree(_lx, _ly),
                                    new Degree(StringOption.GetobjectToSingle(Material.Latitude, 0), StringOption.GetobjectToSingle(Material.Longitude, 0))) + "米", Material.Abstract, Material.PictureAdrress, "/Mobile/MapLine.aspx?lng=" + _lx + "&lnt=" + _ly + "&lb=" + server.UrlEncode(requestXML.Label) + "&id=" + Material.ID));
                            }

                            #endregion
                            break;
                        case "link":
                           
                            break;
                        default:
                            #region
                            List<Model.KeywordsIndex> KeywordsIndex = uk.FindAll<Model.KeywordsIndex>().Where(c => c.WGuid == wxguid && c.KeyWords.Contains(requestXML.Content)).ToList();
                            if (KeywordsIndex.Count > 0)
                            {
                                int i = 0;
                                foreach (Model.KeywordsIndex Keyword in KeywordsIndex)
                                {
                                    i++;
                                    ContentJsons.AddRange(ReplyJson(Keyword.TableName, Keyword.PrimaryValue, wxguid, i, out MsgTyle));
                                }
                            }
                            else
                            {
                                Model.DefaultSettings Settings = uk.FindSigne<Model.DefaultSettings>(p => p.WGuid == wxguid);
                                if (Settings != null && Settings.ID > 0)
                                {
                                    if (string.IsNullOrEmpty(Settings.Url))
                                        ContentJsons.Add(new MsgJson(Settings.Title, Settings.Abstract, Settings.PictuerAdress, "/Mobile/Settings.aspx?id=" + Settings.ID));
                                    else
                                        ContentJsons.Add(new MsgJson(Settings.Title, Settings.Abstract, Settings.PictuerAdress, Settings.Url));
                                }
                            }
                            #endregion
                            break;
                    }
                    return ToJson(requestXML.FromUserName, requestXML.ToUserName, ActionOption.ConvertDateTimeInt(DateTime.Now), ContentJsons, MsgTyle);
                }
                #endregion
            }
            catch 
            {
                //WriteTxt("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());
            }
            return "";
        }


        /// <summary>
        /// Url参数
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Key"></param>
        /// <param name="NewValue"></param>
        /// <returns></returns>
        public string ChagePara(string Url, string Key, string NewValue)
        {
            string strReturn = "";
            string[] arrUrl = Url.Split('?');
            bool isFindKey = false;
            if (arrUrl.Length < 2)
            {
                strReturn = Url + "?" + Key + "=" + NewValue;
            }
            else
            {
                string[] arrPara = arrUrl[1].Split('&');
                strReturn = arrUrl[0].ToString() + "?";
                foreach (string p in arrPara)
                {
                    if (("," + p + ",").IndexOf("," + Key + "=") > -1)
                    {
                        strReturn += Key + "=" + NewValue + "&";
                        isFindKey = true;
                    }
                    else
                    {
                        strReturn += p + "&";
                    }
                }
                if (!isFindKey)
                {
                    strReturn += Key + "=" + NewValue;
                }
                else
                {
                    strReturn = strReturn.TrimEnd('&');
                }
            }
            return strReturn;
        }


        /// <summary>
        /// 业务逻辑
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="KeyWords"></param>
        /// <param name="wguid"></param>
        /// <param name="MsgTyle"></param>
        /// <returns></returns>
        private List<MsgJson> ReplyJson(string TableName, string KeyWords, string wguid, int i, out string MsgTyle)
        {
            bool isList=KeyWords.IndexOf("Limit_") > -1;
            List<MsgJson> ContentJsons=new List<MsgJson>();
            MsgTyle = "Image";
            switch (TableName)
            {
                case "Activities":
                    #region
                    if (isList)
                    {
                        string[] param=KeyWords.Split('_');
                        int PageSize = param[1].ObjToInt(1);
                        int Family = 0;
                        if (param.Length == 3)
                        {
                            Family = param[2].ObjToInt(0);
                        }
                        IEnumerable<Model.Activities> Activities = uk.FindByFunc<Model.Activities>(c => c.WGuid == wguid);
                        if (Family > 0)
                            Activities = Activities.Where(c => c.ParentID == Family);

                        foreach (Model.Activities Activitie in Activities.OrderByDescending(c => c.IDateTime).Take(PageSize))
                            ContentJsons.Add(new MsgJson(Activitie.Title, Activitie.Abstract + "\n" + Activitie.StartTime.ToShortDateString() + "截止" + Activitie.EditTime.ToShortDateString(), Activitie.PictureAddress, "/Mobile/Registration/RegistrationHead.aspx?aguid=" + Activitie.AGuid ));

                        ContentJsons.Add(new MsgJson("更多>>", "", "", "/Mobile/Registration/RegistrationList.aspx?wxid=" + wguid + "&ParentID=" + Family));
                    }
                    else
                    {
                        Model.Activities Activitie = uk.FindSigne<Model.Activities>(c => c.AGuid == KeyWords && c.WGuid == wguid);
                       if (Activitie != null)
                       {
                           ContentJsons.Add(new MsgJson(Activitie.Title, Activitie.Abstract + "\n" + Activitie.StartTime.ToShortDateString() + "截止" + Activitie.EditTime.ToShortDateString(), Activitie.PictureAddress, "/Mobile/Registration/RegistrationHead.aspx?aguid=" + Activitie.AGuid));
                       }
                    }
                    #endregion
                    break;
                case "TextMaterial":
                    MsgTyle = "Text";
                    #region
                    Model.TextMaterial TextMsg = uk.FindSigne<Model.TextMaterial>(c => c.TGuid == KeyWords && c.WGuid == wguid);
                     if (TextMsg != null)
                     {
                         ContentJsons.Add(new MsgJson("", TextMsg.ReplyContent, "", ""));
                     }
                    #endregion
                    break;
                case "ImageMaterial":
                    #region
                    Model.ImageMaterial ImageText = uk.FindSigne<Model.ImageMaterial>(c => c.IMGuid == KeyWords && c.WGuid == wguid);
                    if (ImageText != null)
                    {
                        if (i == 1)
                            ContentJsons.Add(new MsgJson(ImageText.Title, ImageText.Abstract, ImageText.PictuerAdress, string.IsNullOrEmpty(ImageText.Url) ? "/Mobile/MsgShow.aspx?id=" + ImageText.ID : ImageText.Url));
                        else
                            ContentJsons.Add(new MsgJson(ImageText.Title, ImageText.Abstract, ImageText.Thumbnail, string.IsNullOrEmpty(ImageText.Url) ? "/Mobile/MsgShow.aspx?id=" + ImageText.ID : ImageText.Url));
                    }
                    #endregion
                    break;
                case "ScratchCard":
                    #region
                    if (isList)
                    {
                        string[] param = KeyWords.Split('_');
                        int PageSize = param[1].ObjToInt(1);
                        int Family = 0;
                        if (param.Length == 3)
                        {
                            Family = param[2].ObjToInt(0);
                        }
                        IEnumerable<Model.ScratchCard> ScratchCards = uk.FindByFunc<Model.ScratchCard>(c => c.WGuid == wguid);
                        if (Family > 0)
                            ScratchCards = ScratchCards.Where(c => c.ParentID == Family);

                        foreach (Model.ScratchCard ScratchCard in ScratchCards.OrderByDescending(c => c.IDateTime).Take(PageSize))
                            ContentJsons.Add(new MsgJson(ScratchCard.Title, ScratchCard.Abstract + "\n" + ScratchCard.StartTime.ToShortDateString() + "截止" + ScratchCard.EditTime.ToShortDateString(), ScratchCard.PictureAddress, "/Mobile/ScratchCard/Card.aspx?sguid=" + ScratchCard.SGuid));

                        ContentJsons.Add(new MsgJson("更多>>", "", "", "/Mobile/ScratchCard/default.aspx?wxid=" + wguid + "&ParentID=" + Family));
                    }
                    else
                    {
                        Model.ScratchCard ScratchCard = uk.FindSigne<Model.ScratchCard>(c => c.SGuid == KeyWords && c.WGuid == wguid);
                        if (ScratchCard != null)
                        {
                            ContentJsons.Add(new MsgJson(ScratchCard.Title, ScratchCard.Abstract + "\n" + ScratchCard.StartTime.ToShortDateString() + "截止" + ScratchCard.EditTime.ToShortDateString(), ScratchCard.PictureAddress, "/Mobile/ScratchCard/Card.aspx?sguid=" + ScratchCard.SGuid));
                        }
                    }
                    #endregion
                    break;
                case "MaterialFamily":
                    #region
                    if (isList)
                    {
                        string[] param = KeyWords.Split('_');
                        if (param.Length == 3)
                        {
                            int PageSize = param[1].ObjToInt(1);
                            int Family = param[2].ObjToInt(2);
                            int j = 0;
                            foreach (Model.ImageMaterial Material in uk.LoadWhereLambda<Model.ImageMaterial>(c => c.ParentID == Family && c.WGuid == wguid).OrderByDescending(c => c.IDateTime).OrderBy(o => o.OrderID).Take(PageSize).ToArray())
                            {
                                j++;
                                if (j == 1)
                                    ContentJsons.Add(new MsgJson(Material.Title, Material.Abstract, Material.PictuerAdress, string.IsNullOrEmpty(Material.Url) ? "/Mobile/MsgShow.aspx?id=" + Material.ID : Material.Url));
                                else
                                    ContentJsons.Add(new MsgJson(Material.Title, Material.Abstract, Material.Thumbnail, string.IsNullOrEmpty(Material.Url) ? "/Mobile/MsgShow.aspx?id=" + Material.ID : Material.Url));
                            }
                            
                            ContentJsons.Add(new MsgJson("更多", "", "", "/Mobile/MsgList.aspx?ChannelId=" + Family));
                        }
                    }
                    #endregion
                    break;
                case "WeiWebsite":
                    #region
                    //Model.WeiWebsite website = uk.FindSigne<Model.WeiWebsite>(c => c.WGuid == wguid);
                    //if (website!=null)
                    //    ContentJsons.Add(new MsgJson(website.Title, website.ImageTextContent, website.PictureAddress, "/Mobile/Website/Default.aspx?wxid=" + wguid));
                    #endregion
                    break;
                case "BigWheel":
                    #region
                    if (isList)
                    {
                        string[] param = KeyWords.Split('_');
                        int PageSize = param[1].ObjToInt(1);
                        int Family = 0;
                        if (param.Length == 3)
                        {
                            Family = param[2].ObjToInt(0);
                        }
                        IEnumerable<Model.BigWheel> bigwheels = uk.FindByFunc<Model.BigWheel>(c => c.WGuid == wguid);
                        if (Family > 0)
                            bigwheels = bigwheels.Where(c => c.ParentID == Family);

                        foreach (Model.BigWheel bigwheel in bigwheels.OrderByDescending(c => c.IDateTime).Take(PageSize))
                            ContentJsons.Add(new MsgJson(bigwheel.Title, bigwheel.Abstract + "\n" + bigwheel.StartTime.ToShortDateString() + "截止" + bigwheel.EditTime.ToShortDateString(), bigwheel.PictureAddress, "/Mobile/BigWheels/BigWheel.aspx?bguid=" + bigwheel.BGuid + "&wxid=" + wguid));

                        ContentJsons.Add(new MsgJson("更多>>", "", "", "/Mobile/BigWheels/BigWheelList.aspx?wguid=" + wguid + "&ParentID=" + Family));
                    }
                    else
                    {
                        Model.BigWheel bigwheel = uk.FindSigne<Model.BigWheel>(c => c.BGuid == KeyWords && c.WGuid == wguid);
                        if (bigwheel != null)
                        {
                            ContentJsons.Add(new MsgJson(bigwheel.Title, bigwheel.Abstract + "\n" + bigwheel.StartTime.ToShortDateString() + "截止" + bigwheel.EditTime.ToShortDateString(), bigwheel.PictureAddress, "/Mobile/BigWheels/BigWheel.aspx?bguid=" + bigwheel.BGuid + "&wxid=" + wguid));
                        }
                    }
                    #endregion
                    break;

            }
            return ContentJsons;
        }

        /// <summary>
        /// 格式化返回信息（纯文本格式）
        /// </summary>
        /// <param name="FromUserName"></param>
        /// <param name="ToUserName"></param>
        /// <param name="TimeInt"></param>
        /// <param name="ContentJsons"></param>
        /// <returns></returns>
        private string TextJson(string FromUserName, string ToUserName, int TimeInt, List<MsgJson> ContentJsons)
        {
            if (ContentJsons == null) return "";
            if (ContentJsons.Count == 0) return "";
            StringBuilder josn = new StringBuilder();
            josn.Append("<xml>");
            josn.Append("<ToUserName><![CDATA[" + FromUserName + "]]></ToUserName>");
            josn.Append("<FromUserName><![CDATA[" + ToUserName + "]]></FromUserName>");
            josn.Append("<CreateTime>" + TimeInt + "</CreateTime>");
            josn.Append("<MsgType><![CDATA[text]]></MsgType>");
            josn.Append("<Content><![CDATA[");
            foreach (MsgJson Reply in ContentJsons)
            {
                josn.Append(Reply.Title+"\n"+Reply.Description);
            }
            josn.Append("]]></Content>");
            josn.Append("<FuncFlag>0</FuncFlag>");
            josn.Append("</xml> ");
            return josn.ToString();
        }
        private readonly string HostUrl = new Model.SiteConfig().SiteUrl;
        /// <summary>
        ///  格式化返回信息（图文格式）
        /// </summary>
        /// <param name="FromUserName"></param>
        /// <param name="ToUserName"></param>
        /// <param name="TimeInt"></param>
        /// <param name="ContentJsons"></param>
        /// <param name="MsgTyle"></param>
        /// <returns></returns>
        private string ToJson(string FromUserName, string ToUserName, int TimeInt, List<MsgJson> ContentJsons, string MsgTyle)
        {
            if (ContentJsons == null) return "";
            if (ContentJsons.Count==0) return "";
            if (MsgTyle == "Text") return TextJson(FromUserName, ToUserName, TimeInt, ContentJsons);
            StringBuilder josn = new StringBuilder();
            josn.Append("<xml>");
            josn.Append("<ToUserName><![CDATA[" + FromUserName + "]]></ToUserName>");
            josn.Append("<FromUserName><![CDATA[" + ToUserName + "]]></FromUserName>");
            josn.Append("<CreateTime>" + TimeInt + "</CreateTime>");
            josn.Append("<MsgType><![CDATA[news]]></MsgType>");
            josn.Append("<ArticleCount>" + ContentJsons.Count + "</ArticleCount>");
            josn.Append("<Articles>");
            foreach (MsgJson Reply in ContentJsons)
            {
                josn.Append("<item>");
                josn.Append("<Title><![CDATA[" + Reply.Title + "]]></Title>");
                josn.Append("<Description><![CDATA[" + Reply.Description + "]]></Description>");
                if (!string.IsNullOrEmpty(Reply.PicUrl))
                    josn.Append("<PicUrl><![CDATA[" + (Reply.PicUrl.ToLower().IndexOf("http://") > -1 ? "" : HostUrl) + Reply.PicUrl + "]]></PicUrl>");
                if (!string.IsNullOrEmpty(Reply.Url))
                {
                    josn.Append("<Url><![CDATA[" + (Reply.Url.ToLower().IndexOf("http://") > -1 ? "" : HostUrl) + Reply.Url + UrlParam(Reply.Url, FromUserName, DateTime.Now.Ticks.ToString()) + "]]></Url>");
                }
                josn.Append("</item>");
            }


            josn.Append("</Articles>");
            josn.Append("</xml> ");
            return josn.ToString();
        }


        private string UrlParam(string URL,string OpenID,string DateTime)
        {
            return (URL.IndexOf('?') > -1 ? "&" : "?") + "openid=" + OpenID + "&time=" + DateTime + "&access_token=" + (OpenID + DateTime).ToMD5Two();
        }



        #endregion
    }
}
