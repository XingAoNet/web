using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Mobile
{
    public partial class Settings : MobileTemplatePage
    {
        protected string title { get; set; }
        protected Model.DefaultSettings Model { get; set; }
        protected string wxid { get; set; }
        protected string Abstract { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                title = "错误提示";
                int Id = Request.QueryString["Id"].ObjToInt(0);
                if (Id > 0)
                {
                    Model = new UnitOfWork().FindSigne<Model.DefaultSettings>(c => c.ID == Id);
                    if (Model != null)
                    {
                        Abstract = Model.Abstract;
                        title = Model.Title;
                        wxid = Model.WGuid;
                    }
                    //Model.WeiWebsite wb = new UnitOfWork().FindSigne<Model.WeiWebsite>(c => c.WGuid == wxid);
                    //if (wb != null)
                    //    SiteTel = wb.Tel;
                }

            }
        }
    }
}