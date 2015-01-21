using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using System.Linq.Expressions;

namespace XingAo.Networks.CMS.Web.Manager.Templates
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork() ;
                Rep_LabelList.DataSource = uk.FindAll<Model.Labels>().ToList();
                Rep_LabelList.DataBind();

                Rep_SysLabelList.DataSource = uk.FindAll<Model.SysLabels>().ToList();
                Rep_SysLabelList.DataBind();

                Rep_CommModelList.DataSource = uk.LoadWhereLambda<Model.Templates>(p=>p.TemplateType==0).ToList();
                Rep_CommModelList.DataBind();


                TemplateGroup.DataSource = uk.FindAll<Model.TemplatesGroup>().ToList();
                TemplateGroup.DataValueField = "ID";
                TemplateGroup.DataTextField = "GroupName";
                TemplateGroup.DataBind();

                int ID = Request.QueryString["ID"].ObjToInt();
                if (ID > 0)
                {
                    Model.Templates model = uk.FindSigne<Model.Templates>(c=>c.ID==ID);
                    if (model != null)
                    {
                        txtID.Value = ID.ToString();
                        txtTemplateDescription.Text = model.TemplateDescription;
                        txtTemplateEName.Text = model.TemplateEName;                  
                        txtTemplateHtml.Text = model.TemplateHtml;

                        txtTemplateName.Text = model.TemplateName;
                        txtTemplateType.SelectedValue = model.TemplateType.ToString();
                        TemplateGroup.SelectedValue = model.TemplateGroupId.ToString();
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