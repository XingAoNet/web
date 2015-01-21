using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Networks.CMS.Common;
using System.Linq.Expressions;
using XingAo.Networks.CMS.DbHelper;
using XingAo.Networks.WeChat;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.WeiXin
{
    public partial class Main : Common.BaseListPage
    {
        List<Contacts> Contacts = new List<Contacts>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Request.QueryString["ID"].ObjToInt();
                if (ID > 0)
                {
                    UnitOfWork uk = new UnitOfWork();
                    Model.WeiXin_Account model = uk.FindSigne<Model.WeiXin_Account>(c => c.Id == ID);
                    if (model != null)
                    {
                        TxtID.Value = model.Id.ToString();
                        Li_Name.Text = model.AccountName;
                        LoginInfo login = ActionOption.GetToken(model.AccountName, model.AccountPwd);
                        CgiData cg = ActionOption.SubscribeMP(login);

                        Contacts = cg.friendsList;
                        GroupDroupDown.DataSource = cg.groupsList;
                        GroupDroupDown.DataValueField = "id";
                        GroupDroupDown.DataTextField = "name";
                        GroupDroupDown.DataBind();
                        
                    }
                    else
                    {
                        OptionResultJson.ShowMsg("记录不存在", "", OptionResultJson.StateCode.Err, "");
                    }
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