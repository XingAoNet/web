using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Networks.CMS.Common;
using XingAo.Networks.CMS.DbHelper;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Articles
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rep_List.DataSource = new UnitOfWork().FindAll<Model.CustomTable>().ToList();
                Rep_List.DataBind();
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.DataShare model = new UnitOfWork().FindSigne<Model.DataShare>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {

                        txtFields.Text = model.Fields;
                        txtMethodName.Text = model.MethodName;
                        txtMethodType.SelectedValue = model.MethodType.ToString();
                        txtOrderBy.Text = model.OrderBy;
                        txtTables.Text = model.Tables;
                        txtWhereStr.Text = model.WhereStr;
                        txtDescriptions.Text = model.Descriptions;
                        SqlTxt.Text = "select " + txtFields.Text + " from " + txtTables.Text;
                        if (!string.IsNullOrEmpty(txtWhereStr.Text))
                            SqlTxt.Text += " where " + txtWhereStr.Text;
                        if (!string.IsNullOrEmpty(txtOrderBy.Text))
                            SqlTxt.Text += " order by " + txtOrderBy.Text;
                    }
                    else
                        OptionResultJson.Err("数据不存在！", "");
                }
            }
        }
    }
}