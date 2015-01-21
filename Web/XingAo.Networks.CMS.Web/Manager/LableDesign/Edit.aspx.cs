using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using System.Text;

namespace XingAo.Networks.CMS.Web.Manager.LableDesign
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnitOfWork uk = new UnitOfWork();
                var ctable = uk.FindAll<Model.CustomTable>().ToList();
                Rep_List.DataSource = ctable;
                Rep_List.DataBind();
                int ID = Request.QueryString["id"].ObjToInt();

                StringBuilder tran = new StringBuilder();
                tran.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                tran.AppendLine("   <xsl:transform version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" xmlns:pe=\"labelproc\" exclude-result-prefixes=\"pe\">");
                tran.AppendLine("       <xsl:output method=\"html\" />");
                tran.AppendLine("       <xsl:template match=\"/\">\r\n\r\n");
                tran.AppendLine("       </xsl:template>");
                tran.AppendLine("   </xsl:transform>");
                LabelTxt.Text = tran.ToString();

                if (ID > 0)
                {
                    Model.Labels model = uk.FindSigne<Model.Labels>(c => c.ID == ID);
                    if (model != null)
                    {
                        IsPager.Checked = model.IsPager == 1;
                        txtID.Value = ID.ToString();
                        txtLableName.Text = model.LableName;
                        txtLabelDescription.Text = model.LabelDescription;
                        TxtPageSize.Text = model.PagerSize.ToString();
                        SqlTxt.Text = model.DbSql;
                        AnalyzeJX.SelectedValue = model.Analyze;
                        if (!string.IsNullOrEmpty(model.TemplateHtml))
                            LabelTxt.Text = model.TemplateHtml;
                        else
                        {
                            if (model.Analyze == "Text")
                            {
                                LabelTxt.Text = "";
                            }
                        }
                        Rp_LabelParam.DataSource = model.Params;
                        Rp_LabelParam.DataBind();
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");


                }

            }
        }       
    }
}