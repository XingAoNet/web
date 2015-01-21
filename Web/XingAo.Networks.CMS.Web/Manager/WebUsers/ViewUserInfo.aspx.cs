using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.WebUsers
{
    public partial class ViewUserInfo : Common.BaseEditPage
    {
        //发送邮件地址（用于参数传递）
        public string emailAddr = string.Empty;
        //发送手机号码（用于参数传递）
        public string mobile = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.WebUsers model = uk.FindSigne<Model.WebUsers>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtUserName.Text = model.UserName;
                        txtRealName.Text = model.RealName;
                        txtPoint.Text = model.Points.ToString();
                        txtVipLevel.Text = model.VipLevel.ToString();
                        txtEmail.Text = emailAddr = model.Email;
                        txtMobile.Text = mobile = model.Mobile;
                        txtCanUse.Text = model.CanUse == 1 ? "可用" : "禁用";
                        txtAudit.Text = model.Audit == 1 ? "已审核" : "未审核";
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}