using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using System.Text;
using XingAo.Networks.WeChat;

namespace XingAo.Networks.CMS.Web.Manager.SMS//----------修改命名空间
{
    /// <summary>
    /// SaveDel 的摘要说明
    /// </summary>
    public class SaveDel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];

            string ids = context.Request.Form["UserID"];
            string msg = "发送成功！";
            UnitOfWork uk = new UnitOfWork();
            if (!string.IsNullOrEmpty(ids))//添加或修改
            {
                string[] userids=ids.Trim(',').Split(',');
                Model.Members[] modes = uk.FindByFunc<Model.Members>(p => userids.Contains(p.ID.ToString())).ToArray();

                List<Person> AllowSendMobiles = new List<Person>();

                StringBuilder sendMobiles = new StringBuilder();
         
                string content = context.Request.Form["TextMessage"];

                Model.ManagerUserCookiesModel LogonUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();

                //是否发送微信
                string SendWx = context.Request.Form["SendWx"];

                string WxToken = string.Empty;
                LoginInfo login=null;
                Model.WeiXin_Account Accountmodel = uk.FindAll<Model.WeiXin_Account>().Where(c => c.IsUse == 1).FirstOrDefault();
                if (Accountmodel != null)
                {
                    login = ActionOption.GetToken(Accountmodel.AccountName, Accountmodel.AccountPwd);
                }


                #region 自定义手机号码
                string FTxtMobiles = context.Request.Form["FTxtMobiles"];
                if (FTxtMobiles.Trim() != "")
                {
                    foreach (string mo in FTxtMobiles.Trim().Split(','))
                    {
                        if (mo.Trim() != "")
                        {
                            if (AllowSendMobiles.Where(p => p.Mobile.Equals(mo)).Count() == 0)
                            {
                                AllowSendMobiles.Add(new Person("", mo));
                                sendMobiles.AppendFormat("{0},", mo);
                            }
                        }
                    }
                }
                #endregion
               

                #region 会员用户
                foreach (Model.Members m in modes)
                {
                    #region 采集手机号码
                    if (!string.IsNullOrEmpty(m.mobile) && m.mobile.Length == 11)
                    {
                        if (AllowSendMobiles.Where(p => p.Mobile == m.mobile).Count() == 0)
                        {
                            AllowSendMobiles.Add(new Person(m.TName, m.mobile));
                            sendMobiles.AppendFormat("{0},", m.mobile);
                        }
                    }
                    #endregion

                    #region 发送微信
                    if (login != null && SendWx == "1" && !string.IsNullOrEmpty(m.weixinhao))
                    {
                        ActionOption.SendMessage(login, content, m.weixinhao);
                    }
                    #endregion

                    #region 发送邮件

                    #endregion

                }
                #endregion

                #region 发送短信
                if (context.Request.Form["SendMobile"] == "1")
                {
                    #region 发送并保存到历史记录
                    string ResultInfo = string.Empty;
                    if (sendMobiles.Length > 0)
                    {
                        if (PhoneSend.SendMsg(content, sendMobiles.ToString().Trim(','), out ResultInfo))
                        {
                            Model.Phone_Msg model;
                            foreach (Person person in AllowSendMobiles)
                            {
                                model = new Model.Phone_Msg();
                                model.Mobiles = person.Mobile;
                                model.UserName = person.Name;
                                model.SendDateTime = DateTime.Now;
                                model.MsgInfo = content;
                                model.SendResultMsg = ResultInfo;
                                model.SendName = LogonUser.RealName; ;
                                uk.Save(model, model.Id);

                            }
                        }
                    }
                    #endregion
                }
                #endregion
            }

            string err = "";
            uk.Commit(out err);
            if (err != "")
            {
                msg = "发送失败：<br />失败："+err;
            }
            context.Response.Write(msg);
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
        public string Mobile { get; set; }
        public string Name { get; set; }
    }
}