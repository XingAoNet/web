using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;
using System.Data.SqlClient;
using System.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Mobile.BigWheels
{
    public partial class BigWheel : MobileTemplatePage
    {
        public string jiangping = string.Empty;
        public int num = 0;
        protected bool HasErr { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HasErr = false;
                IsHasPerson = true;
                UnitOfWork uk = new UnitOfWork();
                string openid = Request.QueryString["openid"];
                BGuid = Request.QueryString["BGuid"];//"Bd81028ba11214384922eae10fe6076e9";
                SqlParameter[] parameters = {              
                         new SqlParameter("@openid",SqlDbType.VarChar,150),
                         new SqlParameter("@BGuid", SqlDbType.VarChar,80) };
                parameters[0].Value = openid;
                parameters[1].Value = BGuid;
                DataSet ds = MSSQLImp.RunProcedure("MobileWebSite_BigWheel", parameters);
               // List<Model.BWWinPrize> BWWPList = ds.Tables[2].Select("IDateTime.Date");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IsHasPerson = false;
                    name = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtName.Value = name;
                    txtID.Value = ds.Tables[0].Rows[0]["ID"].ToString();
                    txtMobile.Value = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    txtE_mail.Value = ds.Tables[0].Rows[0]["E_Mail"].ToString();
                    txtAddress.Value = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    HasErr = true;
                    CurRound = ds.Tables[3].Rows[0][0].ObjToInt(0);//当天已使用次数
                    maxRound = ds.Tables[1].Rows[0]["DayNum"].ObjToInt(0);
                    #region 验证报名
                    DateTime time = DateTime.Now;
                    DateTime starttime = StringOption.ObjToDate(ds.Tables[1].Rows[0]["StartTime"].ToString(), DateTime.Now);
                    if (!err && StringOption.ObjToDate(ds.Tables[1].Rows[0]["StartTime"].ToString(), DateTime.Now) >= time)
                    {
                        context = "敬请期待";
                        err = true;
                    }
                    DateTime endtime = StringOption.ObjToDate(ds.Tables[1].Rows[0]["EndTime"].ToString(), DateTime.Now);
                    if (!err && (endtime <= time))
                    {
                        context = "活动已结束";
                        err = true;
                    }
                    if (!err && ds.Tables[1].Rows[0]["IsDelete"].ObjToInt(0) == 1 && StringOption.ObjToDate(ds.Tables[1].Rows[0]["StartTime"].ToString(), DateTime.Now) < time && endtime > time)
                    {
                        context = "活动已取消";
                        err = true;
                    }
                    if (!err && (CurRound >= ds.Tables[1].Rows[0]["DayNum"].ObjToInt(0)))//当天次数用完，或总次数用完 || ds.Tables[1].Rows[0]["TotalNum"].ObjToInt(0) <= BWWPList.Count()
                    {
                        context = "抽奖次数已用完";
                        err = true;
                    }
                    title = ds.Tables[1].Rows[0]["Title"].ToString();
                    LiCreateTime.Text = starttime.ToString("MM月dd日 hh:mm") + " 截止 " + endtime.ToString("MM月dd日 hh:mm");
                    detailedcontent = ds.Tables[1].Rows[0]["DetailedContent"].ToString();
                
                    #endregion
                    Abstract = ds.Tables[1].Rows[0]["Abstract"].ToString();
                    jiangping = ds.Tables[1].Rows[0]["Prize"].ToString();
                    if (!string.IsNullOrEmpty(jiangping))
                        num = jiangping.Split(',').Length;
                    RpList.DataSource = ds.Tables[2];
                    RpList.DataBind();
                }
                //if (ds.Tables[4].Rows.Count > 0) 
                //{
                //    MobileHelp1.setTel = ds.Tables[4].Rows[0]["Tel"].ToString();
                //    MobileHelp1.color = ds.Tables[4].Rows[0]["TitleColor"].ToString();
                //    MobileHelp1.wxid = wxid;
                //}
            }
        }
        #region
        public string title;//标题
        public string Abstract;//简介
        public string detailedcontent;//详细内容
        public string BGuid;
        public bool IsHasPerson;//是否有用户信息
        public string name;//用户姓名
        public int CurRound = 0;//当天已使用次数
        public int maxRound = 0;//当天最大使用次数
        public string context = "";
        public bool err = false;
        #endregion
    }
}
