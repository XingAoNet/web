using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Navigation
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
               
                #region 绑定所属栏目

                 txtPID.Items.Add(new ListItem("--请选择--", ""));
                txtPID.Items.Add(new ListItem("顶级栏目", "0"));
                foreach (Model.WebNavigation item in uk.LoadWhereLambda<Model.WebNavigation>(p => true, p => p.OrderBy(c => c.Code), 1, 9999)) 
                {
                    txtPID.Items.Add(new ListItem("|".PadRight(item.Code.Length / 4 * 3, '-') + item.Name, item.ID.ToString()));
                }
                #endregion

                #region 绑定三种模板


                foreach (Model.Templates data in uk.LoadWhereLambda<Model.Templates>(p => true, p => p.OrderByDescending(c => c.ID), 1, 9999))
                {
                    if (data.TemplateType > 0)
                    {
                        switch (data.TemplateType)
                        {
                            case 1:
                                txtIndexTemplate.Items.Add(new ListItem(data.TemplateName, data.ID.ToString()));
                                break;
                            case 2:
                                txtListTemplate.Items.Add(new ListItem(data.TemplateName, data.ID.ToString()));
                                break;
                            case 3:
                                txtInfoTemplate.Items.Add(new ListItem(data.TemplateName, data.ID.ToString()));
                                break;
                        }
                    }
                }
                txtIndexTemplate.Items.Insert(0, new ListItem("无", "0"));
                txtListTemplate.Items.Insert(0, new ListItem("无", "0"));
                txtInfoTemplate.Items.Insert(0, new ListItem("无", "0"));
                #endregion

                #region 修改前赋值
                int ID = Request.QueryString["ID"].ObjToInt();
                if (ID > 0)
                {
                    Model.WebNavigation model = uk.FindSigne<Model.WebNavigation>(p => p.ID == ID);
                    if (model != null)
                    {
                        txtID.Value = ID.ToString();
                        txtPID.SelectedValue = model.Code.Length == 4 ? "0" : new UnitOfWork().FindByFunc<Model.WebNavigation>(p => p.Code == model.Code.Substring(0, model.Code.Length - 4)).FirstOrDefault().ID.ToString();// Impl.WebNavigationRepository().GetIDByCode(model.Code.Substring(0, model.Code.Length - 4)).ToString();
                        txtEName.Text = model.EName;
                        txtIndexTemplate.SelectedValue = model.IndexTemplate.ToString();
                        txtInfoTemplate.SelectedValue = model.InfoTemplate.ToString();
                        txtListTemplate.SelectedValue = model.ListTemplate.ToString();
                        txtName.Text = model.Name;
                        txtOutLink.Text = model.OutLink;
                        txtPic.Text = model.Pic;
                        txtPicHover.Text = model.PicHover;
                        txtSearchEngineDescription.Text = model.SearchEngineDescription;
                        txtSearchEngineKeyWords.Text = model.SearchEngineKeyWords;
                        txtShowInLeftNavigation.SelectedValue = model.ShowInLeftNavigation.ToString();
                        txtShowInTopNavigation.SelectedValue = model.ShowInTopNavigation.ToString();
                        txtTarget.Text = model.Target;
                        if (ID == 1)//当栏目id等于1的时候（首页）
                        {
                            txtPID.Enabled = false;//不能修改顶级栏目
                            txtIndexTemplate.Enabled = false;//不能修改顶级栏目
                            SelectTemplate.Visible = false;//模板选择隐藏
                        }
                    }
                    else
                    {
                        JUIJsonResult.ShowMsg("记录不存在", "", JUIJsonResult.StateCode.Err, "");
                    }

                }
                #endregion
            }
        }
    }
}