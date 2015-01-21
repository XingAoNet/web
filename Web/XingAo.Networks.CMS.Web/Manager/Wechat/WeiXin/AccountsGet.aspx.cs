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
    public partial class AccountsGet : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["JsonOnly"].ObjToInt() == 1)
            {
                p1.Visible = false;
                Response.Clear();
                string ID=Request.Form["ID"];
                Response.Write(ID);
                //Response.Write("<script>$.CallBackSetFormValue(['" + ID + "','" + ID + "']);</script>");
            }
            else
            {
                int group = Request.Params["groupid"].ObjToInt(0);
                UnitOfWork uk = new UnitOfWork();
                Model.WeiXin_Account model = uk.FindAll<Model.WeiXin_Account>().Where(c => c.IsUse == 1).FirstOrDefault();
                if (model != null)
                {
                    int PageNum2 = Request["numPerPage"].ObjToInt(0);
                    LoginInfo login = ActionOption.GetToken(model.AccountName, model.AccountPwd);
                    CgiData cg = ActionOption.SubscribeMP(login, PageNum2, group);

                    groupid.DataSource = cg.groupsList;
                    groupid.DataValueField = "id";
                    groupid.DataTextField = "name";
                    groupid.DataBind();


                    Rep_List.DataSource = cg.friendsList;
                    Rep_List.DataBind();
                    TotalCount = cg.pageSize * cg.pageCount;

                }
            }
        }
    }
}