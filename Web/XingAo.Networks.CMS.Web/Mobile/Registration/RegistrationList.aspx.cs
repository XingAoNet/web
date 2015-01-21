using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using XingAo.Networks.CMS.Web.Common;
using System.Data.SqlClient;
using System.Data;

namespace XingAo.Networks.CMS.Web.Mobile.Registration
{
    public partial class RegistrationList : MobileTemplatePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string color = string.Empty;
                SqlParameter[] parameters = {              
                         new SqlParameter("@wxid",SqlDbType.VarChar,50),
                         new SqlParameter("@ChannelId", SqlDbType.Int) };
                parameters[0].Value = wxid.ObjToStr();
                parameters[1].Value = Request.QueryString["ParentID"].ObjToInt(0);
                DataSet ds = MSSQLImp.RunProcedure("MobileWebSite_Registration_List", parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SiteTel = ds.Tables[0].Rows[0]["Tel"].ToString();
                    color = ds.Tables[0].Rows[0]["TitleColor"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    this.Title = ds.Tables[2].Rows[0]["Name"].ToString();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    Model.OtherModel.NavConfig[] Navs = ds.Tables[1].Rows[0][0].ToString().JsonToObject<Model.OtherModel.NavConfig[]>();
                    RpMemu.DataSource = Navs;
                    RpMemu.DataBind();
                }

                RegList.DataSource = ds.Tables[3];
                RegList.DataBind();
                //MobileHelp1.setTel = SiteTel;
                //MobileHelp1.wxid = wxid;
                //MobileHelp1.color = color;
            }
        }

        public string openid
        {
            get;
            set;
        }
    }
}
