using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Organizations.Elects
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {

                    Model.OrganizationElect model = new UnitOfWork().FindSigne<Model.OrganizationElect>(p => p.Id == id);
                    if (model != null && model.Id > 0)
                    {
                        txtID.Value = model.Id.ToString();
                        txtDate.Text = model.ElectDate.ToString("yyyy-MM-dd");
                        txtName.Text = model.ElectName;
                        txthost.Text = model.Electhost;
                        txtDescription.Text = model.ElectDescribe;
                       
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}