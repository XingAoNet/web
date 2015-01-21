using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Advertising.AD
{
    public partial class Edit : Common.BaseEditPage
    {
        public string JsonParDefaultValue = "[]";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtGroupID.DataValueField = "ID";
                txtGroupID.DataTextField = "GroupName";
                txtGroupID.DataSource = new UnitOfWork().LoadWhereLambda<Model.AdvertisingGroup>(p => true, p => p.OrderBy(c => c.ID), 1, 99999).ToList();
                txtGroupID.DataBind();
                txtGroupID.Items.Insert(0, new ListItem("--请选择--",""));
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.Advertising model = new UnitOfWork().FindSigne<Model.Advertising>(p => p.ID == id);
                    if(model != null && model.ID > 0)
                    {
                        txtGroupID.SelectedValue = model.GroupID.ToString();
                        txtHtml.Text = model.Html;
                        txtShowType.SelectedValue = model.ShowType.ToString();
                        txtTitle.Text = model.Title;
                        JsonParDefaultValue = model.ParametersJson;
                        ClientScript.RegisterStartupScript(this.GetType(), "cheang", "CreateForm('"+model.ShowType.ToString()+"')", true);
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
    }
}