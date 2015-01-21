using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using System.Text;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Mobile.Registration
{
    public partial class RegistrationHead : MobileTemplatePage
    {
        public StringBuilder perhtml = new StringBuilder();
        protected bool HasErr { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string color = string.Empty;
                string Tel = string.Empty;
                HasErr = false;
                string openid = Request.QueryString["openid"];
                UnitOfWork uk = new UnitOfWork();
                context = "活动进行中";
                aguid = Request.QueryString["aguid"];
               
                int reglist = uk.FindAll<Model.Registration>().Where(c => c.AGuid == aguid).Count();
                Model.Activities active = uk.FindSigne<Model.Activities>(c => c.AGuid == aguid);
               // Model.WeiWebsite wb = uk.FindSigne<Model.WeiWebsite>(c => c.WGuid == wxid);
                if (active != null)
                {
                    HasErr = true;
                    #region 报名表单
                    if (!string.IsNullOrEmpty(active.PerContent))
                    {
                        RpList.DataSource = active.PerContent.Split(',');
                        RpList.DataBind();
                    }
                    #endregion

                    #region 验证报名
                    DateTime time = DateTime.Now;
                    bool err = false;
                    if (reglist >= active.PersonNum)
                    {
                        context = "人数已满";
                        err = true;

                    }
                    if (!err && active.IsDelete == 1 && active.StartTime < time && active.EndTime > time)
                    {
                        context = "活动已取消";
                        err = true;
                    }
                    //if (!err && reglist.Where(c => c.OpenId == openid).Count() > 0)
                    //{
                    //    context = "您已报名";
                    //    err = true;
                    //}
                    if (!err && active.StartTime >= time)
                    {
                        context = "敬请期待";
                        err = true;
                    }

                    if (!err && (active.EndTime <= time))
                    {
                        context = "活动已结束";
                        err = true;
                    }
                    LiState.Text = context;
                    PostFrom.Visible = !err;
                    #endregion

                    Model.Activities registration = uk.FindAll<Model.Activities>().Where(c => c.AGuid == aguid).FirstOrDefault();
                    aguid = registration.AGuid;
                    title = registration.Title;
                    Abstract = registration.Abstract;
                    LiCreateTime.Text = registration.StartTime.ToString("MM月dd日 hh:mm") + " 截止 " + registration.EndTime.ToString("MM月dd日 hh:mm");
                    PictureAddress = "http://" + Request.Url.Host + registration.PictureAddress;

                    addtime = registration.IDateTime.ToShortDateString();
                    detailedcontent = registration.DetailedContent;
                    List<Model.Registration> regisList = uk.FindAll<Model.Registration>().Where(c => c.AGuid == registration.AGuid).ToList();
                    //if (wb != null)
                    //{
                    //    Tel = wb.Tel;
                    //    color = wb.TitleColor;
                    //}
                }
                //MobileHelp1.setTel = Tel;
                //MobileHelp1.color = color;
                //MobileHelp1.wxid = wxid;
            }
        }

        #region//页面传值
        public string PictureAddress
        {
            get;
            set;
        }

        /// <summary>
        /// 活动简介
        /// </summary>
        public string Abstract
        {
            get;
            set;
        }

        public string context
        {
            get;
            set;
        }

        public string aguid
        {
            get;
            set;
        }

        public string title
        {
            get;
            set;
        }
        public string addtime
        {
            get;
            set;
        }
        public string detailedcontent
        {
            get;
            set;
        }
        #endregion

    }
}
