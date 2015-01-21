using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Collect
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                TableDropDown.DataSource = uk.FindAll<Model.CustomTable>().ToList();
                TableDropDown.DataTextField = "ChineseName";
                TableDropDown.DataValueField = "Id";
                TableDropDown.DataBind();

                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                   
                    txtID.Value = id.ToString();
                    Model.Collect model = new UnitOfWork().FindSigne<Model.Collect>(p => p.Id == id);
                    if (model != null && model.Id > 0)
                    {
                        CkUse.Checked = model.IsUse.GetValueOrDefault() == 1;
                        txtName.Text = model.Name;
                        txtTime.Text = model.StartTime;
                        txtUrl.Text = model.Url;
                        txtReg.Text = model.Expression;
                        txtContentReg.Text = model.ContentExpression;

                        ParamList.DataSource = uk.FindAll<Model.Collect_Pattern>().Where(c=>c.CollectId==model.CollectId).ToList();
                        ParamList.DataBind();
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}