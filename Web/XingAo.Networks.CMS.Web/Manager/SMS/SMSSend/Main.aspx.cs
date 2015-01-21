using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.SMS.SMSSend
{
    public partial class Main : Common.BaseListPage
    {
        private string _keyResult = "";
        /// <summary>
        /// 快速搜索内的搜索关键字
        /// </summary>
        public string keyResult
        {
            get
            {
                string temp = Request["keyResult"];
                return temp;
            }
            set { _keyResult = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.ManagerUserCookiesModel loginUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
                Dictionary<string, string> par = new Dictionary<string, string>();
                par.Add("PageIndex", PageNum.ToString());
                par.Add("PageSize", PageSize.ToString());
                par.Add("SenderUserID", loginUser.UserID.ToString());
                par.Add("SenderName", loginUser.RealName);
                string timespan = "";
                XingAo.Core.SMSSign.MakeSign(ConfigOption.GetConfigString("AppUser"), ConfigOption.GetConfigString("AppPwd"), ref par, out timespan);
                XingAo.Core.WebUtils web = new WebUtils();
                string resultjson = web.DoPost(ConfigOption.GetConfigString("PostUrl") + "API/SendLog", par);
             var  result= resultjson.JsonToObject<Model.SMSModel.APIResult< Model.SMSModel.LogModel>>();
             if (result != null && !result.IsErr)
             {
                 TotalCount = result.Data.FirstOrDefault().RecordCount;
                 Rep_List.DataSource = result.Data.FirstOrDefault().DataList.Where(p=>(string.IsNullOrEmpty(keyString)||p.Mobiles.Contains(keyString))||(string.IsNullOrEmpty(keyResult)||p.SendResultMsg.Contains(keyResult))).ToList();
                 Rep_List.DataBind();
             }
             else
                 JUIJsonResult.Err(result == null ? "请求失败！" : result.ServerMsg, "");
            }
        }
    }
}