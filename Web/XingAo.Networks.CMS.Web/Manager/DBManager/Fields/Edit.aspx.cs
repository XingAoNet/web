using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Networks.CMS.Model;
using System.Collections.Specialized;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.DBManager.Fields
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                BindDroupDownList(txtDataType, typeof(FieldTypeEnum));
                BindDroupDownList(txtFormControlType, typeof(FormControlTypeEnum));
                BindDroupDownList(txtDataValidation, typeof(DataValidationEnum));
                int ID = Request.QueryString["ID"].ObjToInt();
                if (ID > 0)
                {
                    Model.CustomTableField model = uk.FindSigne<Model.CustomTableField>(p=>p.ID==ID);
                    if (model != null)
                    {
                        //数据库相关项
                        txtTID.Value = model.TID.ToString();
                        txtFieldName.ReadOnly = true;
                        txtIsPrimaryKey.SelectedValue = model.IsPrimaryKey.ToString();
                        txtID.Value = ID.ToString();
                        txtChineseName.Text = model.ChineseName;
                        string[] datatype = (model.DataType.Replace(")", "") + "((").Split('(');
                        txtDataType.SelectedValue = ((int)datatype[0].ToEnum<FieldTypeEnum>()).ToString();
                        txtLeng.Text = datatype[1].Replace("max", "0");
                        txtDescription.Text = model.Description;
                        txtFieldName.Text = model.FieldName;
                        txtDefaultValue.Text = model.DefaultValue;
                        txtIsSystemField.SelectedValue = model.IsSystemField.ToString();
                        txtIsSystemField.Enabled = !(model.IsSystemField == 1);
                        //编辑页面相关项

                        txtShowFormIndex.Text = model.ShowFormEditIndex.ToString();
                        txtShowInForm.SelectedValue = model.ShowEditInForm.ToString();
                        Model.EditFormControl editform = model.ShowFormEditParJson.JsonToObject<Model.EditFormControl>();
                        if (editform != null)
                        {
                            txtUseTag_P.SelectedValue = editform.UseTag_P ? "1" : "0";
                            txtDrawLin.SelectedValue = editform.DrawLineAfter ? "1" : "0";
                            txtDataBind.Text = editform.DataBindTableTxtFieldValue;
                            txtWidth.Text = editform.Width;
                            txtHeight.Text = editform.Height;
                            txtDataValidationConparTo.Text = editform.DataValidationCompareID;
                            txtDataValidation.SelectedValue = ((int)editform.DataValidation).ToString();
                            txtFormTxt.Text = editform.FormTxt;
                            txtFormControlType.Text = ((int)editform.ControlType).ToString();
                        }
                        //列表页相关项
                        Model.ListFormControl listform = model.ShowListParJson.JsonToObject<Model.ListFormControl>();
                        if (listform != null)
                        {
                            txtShowList.SelectedValue = model.ShowList.ToString();
                            txtAlign.SelectedValue = listform.Align;
                            txtDataItemAlign.SelectedValue = listform.DataItemAlign;
                            txtDisplayTitleText.Text = listform.DisplayTitleText;
                            txtDisplayValue.Text = listform.DisplayValue;
                            //model.FieldName=  listform.FieldName;
                            txtFormat.Text = listform.Format;
                            txtHrefLink.Text = listform.HrefLink;
                            txtTitleWidth.Text = listform.TitleWidth;
                            txtShowListIndex.Text = model.ShowListIndex.ToString();
                        }
                        //列表顶部搜索相关项
                        
                            Model.SearchFormControl searchformcontrol = model.ShowInSearchJson.JsonToObject<Model.SearchFormControl>();
                            if (searchformcontrol != null)
                            {
                                txtShowSearch.SelectedValue = model.ShowInSearch.ToString();
                                txtBeforControlText.Text = searchformcontrol.BeforControlText;
                                txtSearchFormControlType.SelectedValue = searchformcontrol.ControlType.ToString();
                                txtSearchFormDataBind.Text = searchformcontrol.DataBindTableTxtFieldValue;
                                txtSeachOpt.SelectedValue = searchformcontrol.SeachOpt.Replace(">", "＞").Replace("<", "＜").Replace("=", "＝");
                                txtShowSearchOrder.Text = model.ShowInSearchIndex.ToString();
                            }
                    }
                    else
                    {
                        JUIJsonResult.ShowMsg("记录不存在", "", JUIJsonResult.StateCode.Err, "");
                    }
                }
                else
                {
                    txtTID.Value = Request.QueryString["TID"];
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
                dr.Items.Insert(0,new ListItem("--请选择--",""));
        }
    }
}