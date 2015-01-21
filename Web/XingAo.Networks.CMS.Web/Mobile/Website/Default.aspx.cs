using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using System.Data.SqlClient;
using System.Data;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Mobile.Website
{
    public partial class Default : MobileTemplatePage
    {
        public string headjsons;
        public string backurl;
        protected string selectmode { get; set; }
        public string SetTel = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string color = string.Empty;
                SqlParameter[] parameters = {              
                         new SqlParameter("@wxid",SqlDbType.VarChar,50) };
                parameters[0].Value = wxid.ObjToStr();
                DataSet ds = MSSQLImp.RunProcedure("MobileWebSite_Index", parameters);

                RegList.DataSource = ds.Tables[0];
                RegList.DataBind();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    this.Title = ds.Tables[1].Rows[0]["Title"].ToString();
                    backurl = ds.Tables[1].Rows[0]["BackPicktue"].ToString();
                    SetTel = ds.Tables[1].Rows[0]["Tel"].ToString();
                    color = ds.Tables[1].Rows[0]["TitleColor"].ToString();
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                   headjsons = ds.Tables[2].Rows[0]["CssType"].ToString();
                   selectmode = ds.Tables[2].Rows[0]["SelectMode"].ToString();
                }
                //MobileHelp1.setTel = SetTel;
                //MobileHelp1.wxid = wxid;
                //MobileHelp1.color = color;
            }
        }
    }
}
