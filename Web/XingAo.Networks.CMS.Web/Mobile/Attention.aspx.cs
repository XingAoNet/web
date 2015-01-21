using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Core;

namespace XingAo.Networks.CMS.Web.Mobile
{
    public partial class Attention : System.Web.UI.Page
    {
        protected string title { get; set; }
        protected Model.Attention Model { get; set; }
        protected string wxid { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                title = "错误提示";
                int Id = Request.QueryString["Id"].ObjToInt(0);
                if (Id > 0)
                {
                    Model =  new UnitOfWork().FindSigne<Model.Attention>(c => c.ID == Id);
                    if (Model != null)
                    {
                        title = Model.Title;
                        wxid=Model.WGuid;
                    }
                }

            }
        }
    }
}