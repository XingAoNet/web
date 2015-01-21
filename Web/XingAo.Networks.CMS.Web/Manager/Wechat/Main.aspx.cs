using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;
using XingAo.Networks.WeChat;

namespace XingAo.Networks.CMS.Web.Manager.Wechat
{
    public partial class Main : Common.BaseListPage
    {
        List<Contacts> Contacts = new List<Contacts>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                Model.WeiXin_Account model = uk.FindAll<Model.WeiXin_Account>().Where(c => c.IsUse == 1).FirstOrDefault();
                if (model != null)
                {
                    TxtID.Value = model.Id.ToString();
                    LoginInfo login = ActionOption.GetToken(model.AccountName, model.AccountPwd);
                    CgiData cg = ActionOption.SubscribeMP(login);
                    ActionOption.getFakeid(login, "oZ4IvuKg42gFMQLO21gBMeVh62Eo");

                    Rep_List.DataSource = cg.friendsList;
                    Rep_List.DataBind();
                    LiPager.Text = "当前页" + (cg.pageIdx + 1) + " <a href='javascript:;' ref='" + ((cg.pageIdx - 1) <= 0 ? 0 : cg.pageIdx - 1) + "'><<</a>" + " <a href='javascript:;' ref='" + (((cg.pageIdx + 1) >= cg.pageCount) ? cg.pageIdx : cg.pageIdx + 1) + "'>>></a>";



                    Contacts = cg.friendsList;
                    GroupDroupDown.DataSource = cg.groupsList;
                    GroupDroupDown.DataValueField = "id";
                    GroupDroupDown.DataTextField = "name";
                    GroupDroupDown.DataBind();
                }
            }
        }

      

        /// <summary>
        /// 返回分组联系人
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        protected List<Contacts> GroupContacts(int groupId)
        {
            return Contacts.Where(c => c.group_id == groupId).ToList();
        }
    }
}
