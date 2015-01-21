using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core.Data;
using XingAo.Core;
using System.Data;
using System.Data.SqlClient;

namespace XingAo.Networks.CMS.Web.Mobile.Registration
{
    /// <summary>
    /// CheckAdmin 的摘要说明
    /// </summary>
    public class CheckSubmit : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext hc)
        {
            string msg = string.Empty;
            hc.Response.ContentType = "text/plain";
            string action = hc.Request.Form["action"];
            string aguid = hc.Request.Form["aguid"];
            if (!string.IsNullOrEmpty(aguid) && !string.IsNullOrEmpty(action))
            {
                UnitOfWork uk = new UnitOfWork();
                switch (action)
                {
                    case "enroll":
                        #region 用户报名
                        string telphone = hc.Request.Form["Moblie"].Trim();
                        string u = hc.Request.Form["u"];
                        string content = hc.Request.Form["percontent"];
                        string openid = hc.Request.Form["openid"];
                        #endregion
                        #region 数据验证
                        if (string.IsNullOrEmpty(openid))
                        {
                            hc.Response.Write("{\"code\":\"300\",\"msg\":\"非法访问\"}");
                            hc.Response.End();
                        }

                        //if (uk.FindAll<Model.Registration>().Where(c => c.OpenId == openid && c.AGuid == aguid).Count() > 0)
                        //{
                        //    hc.Response.Write("{\"code\":\"300\",\"msg\":\"此微信已报名\"}");
                        //    hc.Response.End();
                        //}
                        int regCount = uk.FindAll<Model.Registration>().Where(c => c.AGuid == aguid).Count();
                        int telphoneCount = uk.FindAll<Model.Registration>().Where(c => c.AGuid == aguid &&  c.Telphone == telphone).Count();
                        Model.Activities active = uk.FindSigne<Model.Activities>(c => c.AGuid == aguid);
                        if (regCount >= active.PersonNum)
                        {
                            hc.Response.Write("{\"code\":\"300\",\"msg\":\"报名人数已满\"}");
                            hc.Response.End();

                        }

                        if (telphoneCount > 0)
                        {
                            hc.Response.Write("{\"code\":\"300\",\"msg\":\"手机号已存在\"}");
                            hc.Response.End();
                        }

                        #endregion
                        #region 数据提交
                        Model.Registration regist = new Model.Registration();
                        regist.AGuid = aguid;
                        regist.Name = u;
                        regist.Telphone = telphone;
                        regist.IDateTime = DateTime.Now;
                        regist.EditTime = DateTime.Now;
                        regist.Editer = u;
                        regist.Creater = u;
                        regist.OpenId = openid;
                        regist.Address = content;//所有出姓名手机外的信息
                        uk.Save(regist, regist.ID);
                        string err = "";
                        uk.Commit(out err);
                        if (err == "")
                        {
                            hc.Response.Write("{\"code\":\"200\",\"msg\":\"<tr><td>" + regist.Name + "</td><td>" + regist.Telphone + "</td><td>" + regist.IDateTime.ToShortDateString() + "</td></tr>\"}");
                            hc.Response.End();
                        }
                        else
                        {
                            hc.Response.Write("{\"code\":\"300\",\"msg\":\"本次提交数据异常:" + err + "\"}");
                            hc.Response.End();
                        }
                        #endregion
                        break;
                    case "admin":
                        #region 前台用户登录
                        string password = hc.Request.Form["pwd"].Trim();
                        string name = hc.Request.Form["u"];
                        string Md5Password = MD5.MakeMD5(password);

                         SqlParameter[] parameters = {              
                         new SqlParameter("@UMobile",SqlDbType.VarChar,15),
                         new SqlParameter("@Md5Password", SqlDbType.VarChar,50),
                         new SqlParameter("@aguid", SqlDbType.VarChar,50) };
                         parameters[0].Value = name;
                         parameters[1].Value = Md5Password;
                         parameters[2].Value = aguid;
                         DataSet ds = MSSQLImp.RunProcedure("CheckAdmin", parameters);
                         msg = "参数错误！";
                         if (ds.Tables.Count > 0)
                         {
                             if (ds.Tables[0].Rows.Count > 0)
                             {
                                 string _info = ds.Tables[0].Rows[0][0].ToString();
                                 if (_info == "ok")
                                 {
                                     HttpContext.Current.Session["adminLogin"] = "success";
                                     hc.Response.Write("{\"code\":\"200\",\"msg\":\"登录成功\"}");
                                     hc.Response.End();
                                 }
                                 else
                                 {
                                     hc.Response.Write("{\"code\":\"300\",\"msg\":\"" + _info + "\"}");
                                     hc.Response.End();
                                 }
                             }
                         }
                        msg = "账号或密码错误！";
                        hc.Response.Write("{\"code\":\"300\",\"msg\":\"" + msg + "\"}");
                        hc.Response.End();
                        #endregion
                        break;
                }
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
}