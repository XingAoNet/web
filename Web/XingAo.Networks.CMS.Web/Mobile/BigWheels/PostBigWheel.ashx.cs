using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Mobile.BigWheels
{
    /// <summary>
    /// CheckPerson 的摘要说明
    /// </summary>
    public class PostBigWheel : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext hc)
        {
            string msg = string.Empty;
            hc.Response.ContentType = "text/plain";
            string action = hc.Request.Form["action"];
            string bguid = hc.Request.Form["bguid"];
            string openid = hc.Request.Form["openid"];
            string other = string.Empty;
            if (!string.IsNullOrEmpty(bguid) && !string.IsNullOrEmpty(action))
            {
                UnitOfWork uk = new UnitOfWork();
                string err = "";
                switch (action)
                {
                    case "LuckDraw":
                        #region 旋转转盘
                        Model.BigWheel bw = uk.FindSigne<Model.BigWheel>(c => c.BGuid == bguid);
                        List<Model.BWWinPrize> BWPList = uk.FindAll<Model.BWWinPrize>().Where(c => c.OPenId == openid && c.BGuid == bguid).ToList();//中奖信息表
                        int CurRound = BWPList.Where(c => c.IDateTime.Date == DateTime.Now.Date).Count();//当天已使用次数
                        if (bw.TotalNum <= BWPList.Count() || bw.DayNum <= CurRound)
                        {
                            hc.Response.Write("{\"code\":\"300\",\"msg\":\"非法操作，抽奖次数已用完\"}");
                            hc.Response.End();
                        }
                        Model.BWWinPrize bwper = new Model.BWWinPrize();
                        bwper.BGuid = bguid;
                        bwper.OPenId = hc.Request.Form["openid"];
                        bwper.Prize = hc.Request.Form["prize"];
                        bwper.IDateTime = DateTime.Now;
                        bwper.EditTime = DateTime.Now;
                        bwper.Editer = hc.Request.Form["u"];
                        bwper.Creater = hc.Request.Form["u"];
                        uk.Save(bwper, bwper.ID);
                        other = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                        #endregion
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