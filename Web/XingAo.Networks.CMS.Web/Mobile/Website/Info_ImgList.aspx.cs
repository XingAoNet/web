using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using XingAo.Networks.CMS.Model;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;
using System.Data.SqlClient;
using System.Data;

namespace XingAo.Networks.CMS.Web.Mobiles.Website
{
    public partial class Info_ImgList : MobileTemplatePage
    {
        public string url = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(wxid))
                {
                    string color = string.Empty;
                    SqlParameter[] parameters = {              
                         new SqlParameter("@wxid",SqlDbType.VarChar,50),
                         new SqlParameter("@ChannelId", SqlDbType.Int) };
                    parameters[0].Value = wxid;
                    parameters[1].Value = Request.QueryString["ChannelId"].ObjToInt(0);
                    DataSet ds = MSSQLImp.RunProcedure("MobileWebSite_ImageMaterial_List", parameters);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SiteTel = ds.Tables[0].Rows[0]["Tel"].ToString();
                        color = ds.Tables[0].Rows[0]["TitleColor"].ToString();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        this.Title = ds.Tables[2].Rows[0]["Name"].ToString();
                        LiTitle.Text = this.Title;
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        Model.OtherModel.NavConfig[] Navs = ds.Tables[1].Rows[0][0].ToString().JsonToObject<Model.OtherModel.NavConfig[]>();
                        RpMemu.DataSource = Navs;
                        RpMemu.DataBind();
                    }

                    ListRp.DataSource = ds.Tables[3];
                    ListRp.DataBind();
                    //MobileHelp1.setTel = SiteTel;
                    //MobileHelp1.wxid = wxid;
                    //MobileHelp1.color = color;
                    if (Request.UrlReferrer != null)
                    {
                        Uri backurl = Request.UrlReferrer;
                        url = backurl.ToString();
                    }
                    if(url=="")
                        url = new Model.SiteConfig().SiteUrl + "/mobile/website/?wxid=" + wxid;
                }
            }
        }
    }
}