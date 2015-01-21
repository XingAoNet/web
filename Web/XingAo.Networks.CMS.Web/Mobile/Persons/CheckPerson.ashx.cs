using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Mobile.Persons
{
    /// <summary>
    /// CheckPerson 的摘要说明
    /// </summary>
    public class CheckPerson : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext hc)
        {
            string msg = string.Empty;
            hc.Response.ContentType = "text/plain";
            string action = hc.Request.Form["action"];
            string bguid = hc.Request.Form["bguid"];
            string openid = hc.Request.Form["openid"];
            string other = string.Empty;
            if (!string.IsNullOrEmpty(action))
            {
                UnitOfWork uk = new UnitOfWork();
                string err = "";
                switch (action)
                {
                    case "enroll":
                        #region 用户报名
                        string telphone = hc.Request.Form["Mobile"].Trim();
                        string u = hc.Request.Form["u"];
                        string content = hc.Request.Form["percontent"];
                        string address = hc.Request.Form["address"];
                        string email = hc.Request.Form["email"];
                        string wxid = hc.Request.Form["wxid"];
                        #endregion
                        #region 数据验证
                        if (string.IsNullOrEmpty(openid) || openid.Length < 6)
                        {
                            hc.Response.Write("{\"code\":\"300\",\"msg\":\"请从微信菜单进入参加活动\"}");
                            hc.Response.End();
                        }
                        List<Model.BWPerson> bwPersonList = uk.FindAll<Model.BWPerson>().Where(c => c.WGuid == wxid).ToList();//.Where(c => c.BGuid == bguid)
                        int telphoneCount = bwPersonList.Where(c => c.BGuid == bguid && c.Mobile == telphone && c.OPenId != openid).Count();
                        if (telphoneCount > 0)
                        {
                            hc.Response.Write("{\"code\":\"300\",\"msg\":\"手机号已存在\"}");
                            hc.Response.End();
                        }
                        #endregion
                        #region 数据提交
                        Model.BWPerson bwperson = uk.FindSigne<Model.BWPerson>(c => c.OPenId == openid);
                        if (bwperson == null)
                        {
                            bwperson = new Model.BWPerson();
                            bwperson.IDateTime = DateTime.Now;
                            bwperson.Creater = u;
                            bwperson.OPenId = openid;
                            bwperson.WGuid = wxid;
                        }
                        bwperson.BGuid = bguid;
                        bwperson.Name = u;
                        bwperson.Mobile = telphone;
                        bwperson.EditTime = DateTime.Now;
                        bwperson.Editer = u;
                        bwperson.Address = address;
                        bwperson.E_Mail = email;
                        if (bwperson.ID == 0)
                            uk.Save(bwperson, bwperson.ID);
                        #endregion
                        break;
                    case "admin":
                        #region 前台用户登录
                        #endregion
                        break;
                }
                uk.Commit(out err);
                if (err == "")
                {
                    hc.Response.Write("{\"code\":\"200\",\"msg\":\"提交成功\",\"Other\":\"" + other + "\"}");
                    hc.Response.End();
                }
                else
                {
                    hc.Response.Write("{\"code\":\"300\",\"msg\":\"本次提交数据异常:" + err + "\"}");
                    hc.Response.End();
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