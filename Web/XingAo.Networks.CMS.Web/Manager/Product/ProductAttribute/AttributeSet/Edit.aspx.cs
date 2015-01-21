using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using System.Collections.Specialized;
using XingAo.Networks.CMS.Model;

namespace XingAo.Networks.CMS.Web.Manager.Product.ProductAttribute.AttributeSet
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk=new UnitOfWork();
                BindDroupDownList(txtFormControlType, typeof(FormControlTypeEnum));
                BindDroupDownList(txtDataValidation, typeof(DataValidationEnum));
                int id = Request.QueryString["id"].ObjToInt();
                txtGroupID.DataTextField = "GroupName";
                txtGroupID.DataValueField = "id";
                txtGroupID.DataSource = uk.FindAll<Model.Product_AttributeGroup>().ToList();
                txtGroupID.DataBind();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.Product_Attribute model = new UnitOfWork().FindSigne<Model.Product_Attribute>(p => p.ID == id);
                    if (model != null && model.ID > 0)
                    {
                        txtAttrName.Text = model.AttrName;
                        txtDescriptions.Text = model.Descriptions;
                        txtGroupID.SelectedValue = model.GroupID.ToString();
                        txtOrderNum.Text = model.OrderNum.ToString();
                        Model.EditFormControl editform = model.ControlResendJson.JsonToObject<Model.EditFormControl>();
                        txtDataValidation.SelectedValue = ((int)editform.DataValidation).ToString();
                        txtFormControlType.Text = ((int)editform.ControlType).ToString();
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }
        /// <summary>
        /// 绑定返射回来的枚举
        /// </summary>
        /// <param name="dr">绑定到哪个DropDownList控件上</param>
        /// <param name="type">哪个枚举的type</param>
        private void BindDroupDownList(DropDownList dr, Type type)
        {
            NameValueCollection keyv = EnumTransform.GetDescriptionAddValue(type);
            foreach (string key in keyv.AllKeys)
                dr.Items.Add(new ListItem(key, keyv[key]));
            dr.Items.Insert(0, new ListItem("--请选择--", ""));
        }
    }
}