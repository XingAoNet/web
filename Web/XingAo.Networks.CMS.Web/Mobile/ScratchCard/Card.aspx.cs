using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Mobile.ScratchCard
{
    public partial class Card : MobileTemplatePage
    {
        public string GoodUrl { get; set; }
        public bool isFx { get; set; }
        public bool isInfoNo { get; set; }
        public string Background { get; set; }
        public string ImgWidth { get; set; }
        public string ImgHeight { get; set; }

        public string CanvasTop { get; set; }
        public string CanvasLeft { get; set; }
        public string Abstract { get; set; }

        #region
        public string title;//标题
        public string detailedcontent;//详细内容
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string openid = Request.QueryString["OpenID"];
                if (!string.IsNullOrEmpty(openid))
                {
                    string ScratchCardID = Request.QueryString["sguid"];

                    SqlParameter[] parameters01 = {              
                     new SqlParameter("@ScratchCardID", SqlDbType.VarChar,50),
                     new SqlParameter("@WeiXingID", SqlDbType.VarChar,1000) };
                    parameters01[0].Value = ScratchCardID;
                    parameters01[1].Value = openid;
                    DataSet ds = MSSQLImp.RunProcedure("getScratchCard", parameters01);
                    if (ds.Tables.Count == 5)
                    {
                        string goodName = string.Empty;
                        int w = 300;
                        int h = 200;
                        #region
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Abstract = ds.Tables[0].Rows[0]["Abstract"].ToString();
                            Background = ds.Tables[0].Rows[0]["CardBG"].ToString();
                            title = ds.Tables[0].Rows[0]["title"].ToString();
                            detailedcontent = ds.Tables[0].Rows[0]["InHtml"].ToString();
                            LiCreateTime.Text = StringOption.ObjToDate(ds.Tables[0].Rows[0]["StartTime"].ToString(), DateTime.Now.AddDays(-365)).ToString("MM月dd日 hh:mm") + " 截止 " + StringOption.ObjToDate(ds.Tables[0].Rows[0]["EndTime"].ToString(), DateTime.Now.AddDays(-365)).ToString("MM月dd日 hh:mm");

                            string _MaskCoordinate = ds.Tables[0].Rows[0]["MaskCoordinate"].ToString();
                            string[] MaskCoordinate = _MaskCoordinate.Split('|');
                            string[] xy = MaskCoordinate[0].Split(',');
                            string[] x2y2 = MaskCoordinate[2].Split(',');
                            w = x2y2[0].ObjToInt();
                            h = x2y2[1].ObjToInt();
                            ImgWidth = x2y2[0];
                            ImgHeight = x2y2[1];
                            CanvasTop = xy[1];
                            CanvasLeft = xy[0];
                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                txtName.Value = ds.Tables[3].Rows[0]["Name"].ToString();
                                txtID.Value = ds.Tables[3].Rows[0]["ID"].ToString();
                                txtMobile.Value = ds.Tables[3].Rows[0]["Mobile"].ToString();
                                txtE_mail.Value = ds.Tables[3].Rows[0]["E_Mail"].ToString();
                                txtAddress.Value = ds.Tables[3].Rows[0]["Address"].ToString();
                            }
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                #region 已经参加抽奖
                                if (ds.Tables[1].Rows.Count > 0)
                                    goodName = ds.Tables[1].Rows[0]["GoodsName"].ToString();
                                else
                                    goodName = ds.Tables[0].Rows[0]["DefaultGoodName"].ToString();
                                #endregion
                            }
                            else
                            {
                                #region
                                DateTime now = DateTime.Now;
                                DateTime stime = StringOption.ObjToDate(ds.Tables[0].Rows[0]["StartTime"].ToString(), now.AddDays(-365));
                                DateTime etime = StringOption.ObjToDate(ds.Tables[0].Rows[0]["EndTime"].ToString(), now.AddDays(-365));
                                if (stime < now && now <= etime)
                                {
                                    #region 检测是否登记用户信息
                                    if (openid.Length < 6)
                                    {
                                        isInfoNo = false;
                                        goodName = "请从微信菜单进入参加活动";
                                    }
                                    else
                                        if (ds.Tables[3].Rows.Count > 0)
                                        {
                                            string Result = ScratchCardImp.CreateScratchCard(ScratchCardID, openid, ds.Tables[3].Rows[0]["Name"].ToString(), ds.Tables[3].Rows[0]["Mobile"].ToString());
                                            if (!string.IsNullOrEmpty(Result))
                                            {
                                                string[] oksmsgInfo = Result.Split(':');
                                                if (!string.IsNullOrEmpty(oksmsgInfo[1]))
                                                    goodName = oksmsgInfo[1];
                                            }
                                        }
                                        else
                                        {
                                            isInfoNo = true;
                                            goodName = "请先填写基本信息";
                                        }
                                    #endregion
                                    isFx = true;
                                }
                                else
                                {
                                    if (now < stime)
                                        goodName = "活动暂未开始";
                                    else
                                        goodName = "活动已结束";
                                }
                                #endregion
                            }
                            RpList.DataSource = ds.Tables[4];
                            RpList.DataBind();
                            GoodUrl = this.ResolveUrl("~/Shared/DrawImg.aspx?name=" + HttpUtility.HtmlEncode(goodName));
                        }
                        #endregion
                    }
                }
            }
        }
    }
}