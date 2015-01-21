using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using System.Text;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.SMS.SMSSend
{
    public partial class Send : Common.BaseListPage
    {
        List<Model.SMS_ContactGroup> group;
        List<Model.SMS_Contact> users;
        public string Sign = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                Model.ManagerUserCookiesModel loginUser = CookiesHelp.GetUsersCookies<Model.ManagerUserCookiesModel>();
                if (loginUser != null) //判断是否登录
                {
                    Sign = "【" + ConfigOption.GetConfigString("PhoneSign") + "】";
                }

                int Uid = loginUser.UserID;
                 group = uk.LoadWhereLambda<Model.SMS_ContactGroup>(p => p.MembersID == Uid).OrderBy(p => p.GroupCode).ToList();
                users = uk.LoadWhereLambda<Model.SMS_Contact>(p => p.MembersID == Uid).ToList();
                List<Model.MemberGroups> list = uk.FindAll<Model.MemberGroups>().OrderBy(c => c.OrderNum).ToList();
                acclist.DataSource = list;
                acclist.DataBind();
                //MobTree.Text = BuilderHtml("").ToString();

                if (loginUser != null)
                {
                    try
                    {
                        Dictionary<string, string> par = new Dictionary<string, string>();
                        string timespan = "";
                        SMSSign.MakeSign(ConfigOption.GetConfigString("AppUser"), ConfigOption.GetConfigString("AppPwd"), ref par, out timespan);
                        WebUtils web = new WebUtils();
                        string resultjson = web.DoPost(ConfigOption.GetConfigString("PostUrl") + "API/GetUserInfo", par);
                        var result = resultjson.JsonToObject<Model.SMSModel.APIResult<Model.SMSModel.Users>>();
                        if (result != null && !result.IsErr)
                            LiNum.Text = result.Data.FirstOrDefault().CanUseCount.ToString();                        
                    }
                    catch { }
                }
            }
        }
        private StringBuilder BuilderHtml(string code)
        {
            IEnumerable<Model.SMS_ContactGroup> g;
            if (code == "")
            {
                g = group.Where(p => p.GroupCode.Length == 4);
            }
            else
                g = group.Where(p=>p.GroupCode.Length==code.Length+4&&p.GroupCode.StartsWith(code));
            StringBuilder sb = new StringBuilder();
            if (g.Count() == 0)
                return sb;
            else
            {               
                    sb.AppendLine("<ul>");
            }
            foreach (Model.SMS_ContactGroup gr in g)
            {
                sb.Append("<li><a href=\"javascript\">"+gr.GroupName+"</a>");                
                sb.AppendLine(BuilderHtml(gr.GroupCode).ToString());
                IEnumerable<Model.SMS_Contact> u = users.Where(p => p.GroupID == gr.ID);
                if (u.Count() > 0)
                {
                    sb.AppendLine("<ul>");
                    foreach (Model.SMS_Contact us in u)
                    {
                        if (us != null && us.ID > 0 && us.Mob != null && us.Name != null && us.Company!=null)
                         sb.AppendLine("<li><a href=\"#\"  tname=\"chkMob\" tvalue=\""+us.Mob.Trim()+"\" title=\""+us.Company+"  "+us.Mob+"\">"+us.Name+"</a></li>");
                    }
                    sb.AppendLine("</ul>");
                }
                sb.AppendLine("</li>");
            }
            return sb.AppendLine("</ul>");
        }
    }
}