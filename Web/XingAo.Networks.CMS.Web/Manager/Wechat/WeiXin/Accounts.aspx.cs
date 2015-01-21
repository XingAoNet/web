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

namespace XingAo.Networks.CMS.Web.Manager.Wechat.WeiXin
{
    public partial class Accounts : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int groupid = Request.Params["groupid"].ObjToInt();
                UnitOfWork uk = new UnitOfWork();
                Model.WeiXin_Account model = uk.FindAll<Model.WeiXin_Account>().Where(c => c.IsUse == 1).FirstOrDefault();
                if (model != null)
                {
                    int PageNum2 = Request["numPerPage"].ObjToInt(0);
                    LoginInfo login = ActionOption.GetToken(model.AccountName, model.AccountPwd);
                    CgiData cg = ActionOption.SubscribeMP(login, PageNum2, groupid);
                    Rep_List.DataSource = cg.friendsList;
                    Rep_List.DataBind();

                    LiPager.Text = "当前页" + (cg.pageIdx + 1) + " <a href='javascript:;' ref='" + ((cg.pageIdx - 1) <= 0 ? 0 : cg.pageIdx - 1) + "'><<</a>" + " <a href='javascript:;' ref='" + (((cg.pageIdx + 1) >= cg.pageCount) ? cg.pageIdx : cg.pageIdx + 1) + "'>>></a>";



                }
                else
                {
                    JUIJsonResult.ShowMsg("记录不存在", "", JUIJsonResult.StateCode.Err, "");
                }
            }
        }
    }
}