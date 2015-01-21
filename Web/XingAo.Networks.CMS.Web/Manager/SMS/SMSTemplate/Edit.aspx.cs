using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Manager.SMS.SMSTemplate
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                int ID = Request.QueryString["ID"].ObjToInt();
                if (ID > 0)
                {
                    Model.XA_SMS_Templates model = uk.FindSigne<Model.XA_SMS_Templates>(p => p.ID == ID);
                    if (model != null)
                    {
                        //数据库相关项
                        txtID.Value = ID.ToString();
                        txtTemplatesName.Text = model.TemplatesName;
                        txtTemplatesContent.Text = model.TemplatesContent;
                    }
                    else
                    {
                        JUIJsonResult.ShowMsg("记录不存在", "", JUIJsonResult.StateCode.Err, "");
                    }
                }
                else
                {
                    txtID.Value = ID.ToString();
                }
            }
        }
    }
}