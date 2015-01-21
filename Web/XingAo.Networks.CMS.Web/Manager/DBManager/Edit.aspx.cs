using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.DBManager
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Request.QueryString["ID"].ObjToInt();
                if (ID > 0)
                {

                    Model.CustomTable model = new UnitOfWork().FindSigne<Model.CustomTable>(p => p.ID == ID);

                    if (model != null)
                    {
                        txtID.Value = ID.ToString();
                        txtChineseName.Text = model.ChineseName;
                        txtDescription.Text = model.Description;
                        txtTableName.Text = model.TabName;
                        txtTableName.ReadOnly = true;
                        txtIsSystemTable.SelectedValue = model.IsSystemTable.ToString();
                        txtIsSystemTable.Enabled = !(model.IsSystemTable == 1);
                    }
                    else
                    {
                        JUIJsonResult.ShowMsg("记录不存在", "", JUIJsonResult.StateCode.Err, "");
                    }

                }
            }
        }
    }
}