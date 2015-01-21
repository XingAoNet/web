using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Organizations.OrgMembers
{
    public partial class Main : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string OrgId = Request.QueryString["OrgId"];
                if (!string.IsNullOrEmpty(OrgId))
                {
                    UnitOfWork uk = new UnitOfWork();
                    TxtOrgId.Value = OrgId;
                    ParamList.DataSource = uk.FindAll<Model.Organization_Relation_Member>().Where(c => c.OrgId == OrgId).ToList();
                    ParamList.DataBind();
                }
                else
                    JUIJsonResult.Err("数据不存在！", "");
               
            }
        }
    }
}