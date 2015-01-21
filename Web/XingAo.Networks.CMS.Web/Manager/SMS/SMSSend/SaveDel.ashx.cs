using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Data;
using XingAo.Core.Data;
using XingAo.Core;
using XingAo.Networks.WeChat;

namespace XingAo.Networks.CMS.Web.Manager.SMS.SMSSend
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        UnitOfWork uk = new UnitOfWork();
        string phonesign = ConfigOption.GetConfigString("PhoneSign");

        public void ProcessRequest(HttpContext context)
        {
            Model.ManagerUserCookiesModel loginUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
            string action = context.Request.Params["action"];
            string msg = "发送成功！";
            if (!string.IsNullOrEmpty(action))
            {
                List<Person> AllowSendMobiles = new List<Person>();
                switch (action.ToLower())
                {
                    case "imprt":
                        #region 导入Excel
                        HttpPostedFile ExcelFile = context.Request.Files["ExcelFile"];
                        string SheetName = context.Request.Form["SheetName"];
                        if (ExcelFile.ContentLength > 0)
                        {
                            if (ExcelFile.ContentLength > 4 * 1024000)
                            {
                                msg = "文件过大";
                                return;
                            }
                            string fileContentType = ExcelFile.ContentType;

                            string excelPath = string.Empty;
                            if (AllowType(fileContentType))
                            {
                                try
                                {
                                    #region 上传Excel文件
                                    string Rpath = "/Upload/" + loginUser.UserID + "/";
                                    string FilePath = HttpContext.Current.Server.MapPath("~" + Rpath);

                                    if (!Directory.Exists(FilePath))
                                        Directory.CreateDirectory(FilePath);

                                    FilePath = FilePath + DateTime.Now.ToString("yyMMdd") + "/";
                                    if (!Directory.Exists(FilePath))
                                        Directory.CreateDirectory(FilePath);


                                    //原文件文件名  
                                    string PostName = ExcelFile.FileName;

                                    //保存物理文件名
                                    string curPostName = Guid.NewGuid().ToString();
                                    string ExtenName = System.IO.Path.GetExtension(PostName);
                                    string fn = curPostName + ExtenName;
                                    string savePath = FilePath + fn;
                                    //判断文件是否存在
                                    if (File.Exists(savePath))
                                    {
                                        fn = DateTime.Now.Ticks.ToString() + ExtenName;
                                        savePath = FilePath + fn;
                                    }
                                    //保存原图
                                    ExcelFile.SaveAs(savePath);
                                    excelPath = savePath;
                                    #endregion
                                }
                                catch
                                {
                                    // Response.Write(ex.Message);
                                }
                                #region 返回数据
                                if (!string.IsNullOrEmpty(excelPath))
                                {
                                    DataTable dt = OledbImp.GetTable(excelPath, SheetName);
                                    if (dt != null)
                                    {
                                        StringBuilder _datas = new StringBuilder();
                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            _datas.AppendFormat("{0}|{1},", dr[0].ToString().Trim(), dr[1].ToString().Trim());
                                        }
                                        //msg = _datas.ToString().Trim(',');
                                        msg = "{\"statusCode\":\"200\",\"message\":\"" + _datas.ToString().Trim(',') + "\",\"navTabId\":\"\",\"rel\":\"\",\"callbackType\":\"\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}";

                                    }

                                    File.Delete(excelPath);
                                }
                                #endregion
                            }


                        }
                        #endregion
                        break;
                    case "resend":
                        #region 短信重发
                        if (!string.IsNullOrEmpty(context.Request.Form["ids"]))
                        {
                            //string[] ID = context.Request.Form["ids"].Split(',');
                            //foreach (Model.Phone_Msg _mg in uk.FindByFunc<Model.Phone_Msg>(c => ID.Contains(c.Id.ToString())))
                            //{
                            //    AllowSendMobiles.Add(new Person(_mg.UserName, _mg.Mobiles, _mg.MsgInfo));
                            //}
                            //msg = SendMsg(AllowSendMobiles, true);
                            string PageNum = context.Request.QueryString["pagenum"];
                            string PageSize = context.Request.QueryString["pagesize"];
                            Dictionary<string, string> par = new Dictionary<string, string>();
                            par.Add("PageIndex", PageNum);
                            par.Add("PageSize", PageSize);
                            par.Add("SenderUserID", loginUser.UserID.ToString());
                            par.Add("SenderName", loginUser.RealName);
                            string timespan = "";
                            SMSSign.MakeSign(ConfigOption.GetConfigString("AppUser"), ConfigOption.GetConfigString("AppPwd"), ref par, out timespan);
                            WebUtils web = new WebUtils();
                            string resultjson = web.DoPost(ConfigOption.GetConfigString("PostUrl") + "API/SendLog", par);
                            var result = resultjson.JsonToObject<Model.SMSModel.APIResult<Model.SMSModel.LogModel>>();
                            resultjson = "";
                            string[] IDS = context.Request.Form["ids"].Split(',');
                            int SucessNum = 0;
                            int ErrNum = 0;
                            foreach (string id in IDS)
                            {
                                par = new Dictionary<string, string>();
                                web = new WebUtils();
                                Model.SMSModel.SendLog sendmodel = result.Data.FirstOrDefault().DataList.Where(c => c.Id == id.ObjToInt()).FirstOrDefault();
                                //开始组装API私有参数
                                par.Add("SMS_ID", "0");
                                par.Add("SMS_MobsNames", (sendmodel.Mobiles + "|" + sendmodel.SendName).TrimEnd(','));
                                par.Add("SMS_Content", sendmodel.MsgInfo.Substring(0, sendmodel.MsgInfo.LastIndexOf('【')));
                                par.Add("SMS_SendType", "-1");
                                par.Add("SMS_WeekDay", "0");
                                par.Add("SMS_MonthDay", "0");
                                par.Add("SMS_SendTime", DateTime.Now.ToString());
                                par.Add("SMS_Sign", "【" + phonesign + "】");
                                par.Add("SMS_SenderID", loginUser.UserID.ToString());
                                par.Add("SMS_SenderName", loginUser.RealName);
                                //组装API私有参数结束
                                timespan = "";
                                SMSSign.MakeSign(ConfigOption.GetConfigString("AppUser"), ConfigOption.GetConfigString("AppPwd"), ref par, out timespan);//调用签名方法并返回此API的私有参数及公有参数以及签名时间刻度
                                resultjson = web.DoPost(ConfigOption.GetConfigString("PostUrl") + "API/Send", par);//Post方法请求API得到服务器返回信息
                                var r = resultjson.JsonToObject<Model.SMSModel.APIResult<Model.SMSModel.SendListModel>>();
                                if (r != null && !r.IsErr)
                                {
                                    SucessNum = SucessNum + 1;
                                    //msg = r.ServerMsg;
                                }
                                else
                                {
                                    ErrNum = ErrNum + 1;
                                    //msg = (r == null ? "请求失败！" : r.ServerMsg);
                                }
                            }
                            if (ErrNum != 0)
                                msg = SucessNum + "条短信成功发送" + "< br/>" + ErrNum + "条短信发送失败";
                            else
                                msg = SucessNum + "条短信成功发送";
                        }
                        #endregion
                        break;
                    default:
                        #region 发送短信
                        string mobAndNames = "";//手机|姓名,手机|姓名
                        string FTxtMobiles = context.Request.Form["FTxtMobiles"];//自定义号码
                        string us = context.Request.Form["us"];
                        string content = context.Request.Form["TextMessage"];
                        string _bo = string.Empty;
                        if (!string.IsNullOrEmpty(FTxtMobiles))//自定义号码
                        {
                            FTxtMobiles = FTxtMobiles.Replace("，", ",").Replace("\r\n", ",").Trim(',');
                            #region 自定义手机号码
                            foreach (string mo in FTxtMobiles.Trim().Split(','))
                            {
                                _bo = mo.Trim().Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                                if (_bo != "" && _bo.Length == 11)
                                {
                                    if (AllowSendMobiles.Where(p => p.Mobile.Equals(_bo)).Count() == 0)
                                    {
                                        mobAndNames += _bo + "|,";
                                        AllowSendMobiles.Add(new Person("", _bo, content));
                                    }
                                }
                            }
                            #endregion
                        }

                        if (!string.IsNullOrEmpty(us))//导入的数据
                        {
                            #region 自定义手机号码
                            foreach (string mo in us.Trim().Split(','))
                            {
                                if (mo != "")
                                {
                                    string[] ms = mo.Split('|');
                                    if (ms.Length == 2)
                                    {
                                        _bo = ms[0].Trim();
                                        if (_bo != "" && _bo.Length == 11)
                                        {
                                            if (AllowSendMobiles.Where(p => p.Mobile.Equals(_bo)).Count() == 0)
                                            {
                                                mobAndNames += _bo + "|" + ms[1] + ",";
                                                AllowSendMobiles.Add(new Person(ms[1], _bo, content));
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        if (loginUser != null) //判断是否登录
                        {
                            WebUtils web = new WebUtils();//声明Post、Get操作类
                            Dictionary<string, string> par = new Dictionary<string, string>();
                            //开始组装API私有参数
                            par.Add("SMS_ID", "0");
                            par.Add("SMS_MobsNames", mobAndNames.TrimEnd(','));
                            par.Add("SMS_Content", content);
                            par.Add("SMS_SendType", "-1");
                            par.Add("SMS_WeekDay", "0");
                            par.Add("SMS_MonthDay", "0");
                            par.Add("SMS_SendTime", DateTime.Now.ToString());
                            par.Add("SMS_Sign", "【" + phonesign + "】");
                            par.Add("SMS_SenderID", loginUser.UserID.ToString());
                            par.Add("SMS_SenderName", loginUser.RealName);
                            //组装API私有参数结束
                            string timespan = "";
                            XingAo.Core.SMSSign.MakeSign(ConfigOption.GetConfigString("AppUser"), ConfigOption.GetConfigString("AppPwd"), ref par, out timespan);//调用签名方法并返回此API的私有参数及公有参数以及签名时间刻度

                            string resultjson = web.DoPost(ConfigOption.GetConfigString("PostUrl") + "API/Send", par);//Post方法请求API得到服务器返回信息
                            var r = resultjson.JsonToObject<Model.SMSModel.APIResult<Model.SMSModel.SendListModel>>();
                            if (r != null && !r.IsErr)
                            {
                                msg = r.ServerMsg;
                            }
                            else
                                msg = (r == null ? "请求失败！" : r.ServerMsg);
                            //msg = SendMsg(AllowSendMobiles, false);
                        }
                        else
                            msg = "未登录";
                        #endregion
                        break;
                }
            }
            context.Response.Write(msg);
        }


        //private string SendMsg(List<Person> AllowSendMobiles, bool isResend)
        //{
            
        //    string Msg = string.Empty;
        //    string code = "200";
        //    Model.ManagerUserCookiesModel loginUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
        //    if (loginUser != null) //判断是否登录
        //    {
        //        string ResultInfo = string.Empty;
        //        Model.Phone_Msg model;
        //        int sendLen = 0;
        //        int sendNum = 0;
        //        string sendMsg = string.Empty;
        //        string SendUserName = loginUser.RealName;
        //        foreach (Person person in AllowSendMobiles)
        //        {
        //            if (person.Mobile.Trim().Length == 11)
        //            {
        //                sendMsg = person.Content + (isResend ? "" : "【" + phonesign + "】");
        //                sendNum = Ts(sendMsg);
        //                if ((sendLen + sendNum) <= 90)//mode.PhonesMsgNum
        //                {
        //                    bool SendSmsIsErr = !PhoneSend.SendMsg(sendMsg, person.Mobile.Trim(), out ResultInfo, ConfigOption.GetConfigString("Passage").ObjToInt(1));

        //                    model = new Model.Phone_Msg();
        //                    model.IDateTime = DateTime.Now;
        //                    model.Creater = loginUser.UserID.ToString();
        //                    model.EditTime = DateTime.Now;
        //                    model.Editer = SendUserName;// SessionHelper.ManagerMember.RealName;
        //                    model.Mobiles = person.Mobile;
        //                    model.UserName = person.Name;
        //                    model.SendDateTime = DateTime.Now;
        //                    model.MsgInfo = sendMsg;
        //                    model.SendResultMsg = ResultInfo;
        //                    model.SendName = SendUserName;// SessionHelper.ManagerMember.RealName.ToString();
        //                    uk.Save(model, model.Id);
        //                    if (!SendSmsIsErr)
        //                    {
        //                        sendLen += sendNum;
        //                    }
        //                }
        //            }
        //        }
        //        //减去手机号码
        //        //mode.PhonesMsgNum = mode.PhonesMsgNum - sendLen;
        //        //uk.Save(mode, mode.ID);
        //        string err = "";
        //        Msg = "成功发送" + sendLen + "条短信";
        //        uk.Commit(out err);
        //        if (err != "")
        //        {
        //            code = "300";
        //            Msg = "保存失败：" + err;
        //        }
        //    }
        //    else
        //        Msg = "非法用户";

        //    if (isResend)
        //        return "{\"statusCode\":\"" + code + "\",\"message\":\"" + Msg + "\",\"navTabId\":\"\",\"rel\":\"\",\"callbackType\":\"\",\"forwardUrl\":\"\",\"confirmMsg\":\"\"}";
        //    else
        //        return Msg;
        //}


        private int Ts(string content)
        {
            int mnum = content.Length / 67;
            int mnum2 = content.Length % 67;
            return mnum + (mnum2 > 0 ? 1 : 0);
        }

        /// <summary>
        /// 允许文件格式
        /// </summary>
        /// <param name="FileType"></param>
        /// <returns></returns>
        private bool AllowType(string FileType)
        {
            switch (FileType.ToLower())
            {
                case "application/vnd.ms-excel":
                case "application/x-xls":
                case "application/octet-stream":
                case "application/kset":
                    return true;
                default:
                    return false;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    [Serializable]
    public class Person
    {
        public Person()
        {

        }
        public Person(string _Name, string _Mobile)
        {
            Mobile = _Mobile;
            Name = _Name;
        }

        public Person(string _Name, string _Mobile, string content)
        {
            Mobile = _Mobile;
            Name = _Name;
            Content = content;
        }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}