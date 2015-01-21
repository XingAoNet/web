using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.DataShare.ParameterConf
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int DataShareID = Request["DataShareID"].ObjToInt();
                txtDataShareID.Value = DataShareID.ToString();
                int ID = Request.QueryString["ID"].ObjToInt();
                txtID.Value = ID.ToString();
                if (ID > 0)
                {
                    Model.DataShare_ParameterConfig model = new UnitOfWork().FindSigne<Model.DataShare_ParameterConfig>(p => p.ID == ID && p.DataShareID == DataShareID);
                    if (model != null && model.ID > 0)
                    {

                        txtAllowEmpty.SelectedValue = model.AllowEmpty.ToString();
                        txtDataType.SelectedValue = model.DataType;
                        txtOperators.SelectedValue = model.Operators;

                        txtDataShareID.Value = model.DataShareID.ToString();
                        txtFieldName.Text = model.FieldName;
                        txtParameterName.Text = model.ParameterName;
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