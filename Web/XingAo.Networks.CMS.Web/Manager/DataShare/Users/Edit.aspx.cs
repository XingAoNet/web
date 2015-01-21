using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using System.Text;

namespace XingAo.Networks.CMS.Web.Manager.DataShare.Users
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                string CurrentUserAllowCall = "";                
                int ID = Request.QueryString["ID"].ObjToInt();
                if (ID > 0)
                {
                    txtID.Value = ID.ToString();
                    Model.DataShare_Users model = uk.FindSigne<Model.DataShare_Users>(p => p.ID == ID);
                    if (model != null)
                    {
                        txtUserName.Text = model.UserName;
                        txtUserName.ReadOnly = true;
                        txtKeys.Text = model.Keys;
                        txtPrivateKey.Value = model.PrivateKey;
                        CurrentUserAllowCall = ","+model.AllowCall+",";
                    }
                    else
                    {
                        JUIJsonResult.ShowMsg("记录不存在", "", JUIJsonResult.StateCode.Err, "");
                    }
                }
                else
                {
                    RSAEncrypt ras = new RSAEncrypt();
                    txtKeys.Text = ras.PublicKey.EncryptStr();
                    txtPrivateKey.Value = ras.PrivateKey;
                }
                StringBuilder AllowCall = new StringBuilder("<ul id='txtAllowCallList'>");
                foreach (var share in uk.FindAll<Model.DataShare>())
                {
                    AllowCall.AppendLine("<li><input type='checkbox' name='txtAllowCall' value='" + share.MethodName + "'"+(CurrentUserAllowCall.IndexOf(","+share.MethodName+",")>-1?" checked='checked'":"")+" />" + share.MethodName + (string.IsNullOrEmpty(share.Descriptions) ? "" : "(" + share.Descriptions + ")") + "</li>");
                }
                txtAllowCall.Text = AllowCall.AppendLine("</ul>").ToString();
                txtAllowCall.DataBind();
            }
        }
    }
}