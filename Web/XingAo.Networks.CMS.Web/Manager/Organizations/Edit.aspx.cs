using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Organizations
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
                    
                    Model.Organization model = new UnitOfWork().FindSigne<Model.Organization>(p => p.Id == id);
                    if (model != null && model.Id > 0)
                    {
                        txtElectId.Value = model.ElectId;
                        txtID.Value = model.Id.ToString();
                        txtNo.Text = model.OrgCode;
                        txtDescription.Text = model.OrgDescribe;
                        txtName.Text = model.OrgName;

                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }

            }
        }
    }
}