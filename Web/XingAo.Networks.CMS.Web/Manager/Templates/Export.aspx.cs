using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Templates
{
    public partial class Export : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtID.DataValueField  = "id";
                txtID.DataTextField = "title";
                using (UnitOfWork uk = new UnitOfWork())
                {
                    txtID.DataSource = uk.FindAll<Model.TemplatesBak>().ToList<Model.TemplatesBak>();// new UnitOfWork().FindByFunc<Model.TemplatesBak>(p => true).ToList();// Impl.TemplatesBakRepository().GetList().ToList();
                    txtID.DataBind();
                }
                 txtID.Items.Insert(0,new ListItem("新建","0"));
                txtID.Items.Insert(0,new ListItem("--请选择--",""));
            }
        }
    }
}