using System;
using System.Linq;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.TestDataShare
{
    public partial class ReceiveAccessToken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ServerBack =Server.UrlDecode( Request.QueryString["Sever_Result"]);
                if (ServerBack.IndexOf("Error:") > -1)
                {
                    Response.Write(ServerBack);
                }
                else
                {
                    //{'AccessToken'%3a'58E00CF6-8015-4CF2-9D2E-A63F9C968453'%2c'RefreshToken'%3a'75F4F6A8-6664-43C8-BADA-DE264E02FCBB'%2c'StartTime'%3a'11+18+2013++9%3a35AM'%2c'EndTime'%3a'11+18+2013++9%3a45AM'%2c'ErrMsg'%3a''}
                    AccessTokenModel token = ServerBack.JsonToObject<AccessTokenModel>();
                    if (token.ErrMsg != "")
                    {
                        Response.Write(token.ErrMsg);
                    }
                    else
                    {
                        Panel1.Visible = true;
                        AccessToken.Value = token.AccessToken;
                        DropDownList1.DataSource = new UnitOfWork().FindAll<Model.DataShare>().ToList();
                        DropDownList1.DataTextField = "MethodName";
                        DropDownList1.DataValueField = "id";
                        DropDownList1.DataBind();
                        DropDownList1.Items.Insert(0, new ListItem("-请选择-",""));
                    }
                }
            }
        }
        private class AccessTokenModel
        {
            /// <summary>
            /// 授权令牌
            /// </summary>
            public string AccessToken { get; set; }
            /// <summary>
            /// 刷新授权令牌的  令牌
            /// </summary>
            public string RefreshToken { get; set; }
            /// <summary>
            /// 开始时间
            /// </summary>
            public DateTime StartTime { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            public DateTime EndTime { get; set; }
            /// <summary>
            /// 错误信息
            /// </summary>
            public string ErrMsg { get; set; }
        }
    }
}