using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Networks.CMS.Web.Common;
using System.Data.SqlClient;
using System.Data;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Mobile.Website
{
    public partial class Info_Img : MobileTemplatePage
    {
        protected string title { get; set; }
        protected bool HasErr { get; set; }
        protected string IDateTime { get; set; }
        protected string PictuerAdress { get; set; }
        protected bool IsShow { get; set; }
        protected string DetailedContent { get; set; }
        protected string Url { get; set; }
        protected string IsShowTime { get; set; }
        protected string Praise { get; set; }
        protected string Keys { get; set; }
        protected string url { get; set; }
        protected string Abstract { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                title = "错误提示";
                HasErr = false;
                string color = string.Empty;
                if (!string.IsNullOrEmpty(wxid))
                {

                    SqlParameter[] parameters = {              
                         new SqlParameter("@wxid",SqlDbType.VarChar,50),
                         new SqlParameter("@Id", SqlDbType.Int) };
                    parameters[0].Value = wxid;
                    parameters[1].Value = Request.QueryString["Id"].ObjToInt(0);
                    DataSet ds = MSSQLImp.RunProcedure("MobileWebSite_ImageMaterial_Detail", parameters);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SiteTel = ds.Tables[0].Rows[0]["Tel"].ToString();
                        color = ds.Tables[0].Rows[0]["TitleColor"].ToString();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        Model.OtherModel.NavConfig[] Navs = ds.Tables[1].Rows[0][0].ToString().JsonToObject<Model.OtherModel.NavConfig[]>();
                        RpMemu.DataSource = Navs;
                        RpMemu.DataBind();
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        HasErr = true;
                        title = ds.Tables[2].Rows[0]["title"].ToString();
                        IDateTime = ds.Tables[2].Rows[0]["IDateTime"].ToString();
                        PictuerAdress = ds.Tables[2].Rows[0]["PictuerAdress"].ToString();
                        IsShow = ds.Tables[2].Rows[0]["IsShow"].ToString().ObjToInt(0)==1;
                        DetailedContent = ds.Tables[2].Rows[0]["DetailedContent"].ToString();
                        Url = ds.Tables[2].Rows[0]["Url"].ToString();
                        IsShowTime = ds.Tables[2].Rows[0]["IsShowTime"].ToString();
                        Praise = ds.Tables[2].Rows[0]["Praise"].ToString();
                        Keys = ds.Tables[2].Rows[0]["Keys"].ToString();
                        Abstract = ds.Tables[2].Rows[0]["Abstract"].ToString();
                    }
                    //MobileHelp1.setTel = SiteTel;
                    //MobileHelp1.wxid = wxid;
                    //MobileHelp1.color = color;
                    if (Request.UrlReferrer != null)
                    {
                        Uri backurl = Request.UrlReferrer;
                        url = backurl.ToString();
                    }
                    if (url == "")
                        url = new Model.SiteConfig().SiteUrl + "/mobile/website/?wxid=" + wxid;
                }
            }
        }
    }
}