using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Networks.CMS.Web.Manager.Common;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model;
using System.Text;

namespace XingAo.Networks.CMS.Web.Manager.Templates
{
    public partial class Main : BaseListPage
    {
        public string sTemplateType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                var where = QueryBuilder.Create<Model.Templates>()
                  .Like(c => c.TemplateName, keyString);

                int GroupID = Request["GroupID"].ObjToInt(0);
                if (GroupID>0)
                {
                  where= where.Equals(p => p.TemplateGroupId , GroupID);
                }
                if (!string.IsNullOrEmpty(Request["TemplateType"]))
                {
                    int type = Request["TemplateType"].ObjToInt();
                    where = where.Equals(p => p.TemplateType , type);
                    TemplateType.Value = Request["TemplateType"];
                }


                UnitOfWork uk = new UnitOfWork();
                int totalCount = 0;
                StringBuilder groupHtml=new StringBuilder("<select id=\"GroupID\" name=\"GroupID\">");
                groupHtml.AppendLine("<option value=\"-1\">--不限分组--</option>");
              foreach(TemplatesGroup group in  uk.FindAll<TemplatesGroup>())
              {
                  groupHtml.AppendLine("<option value=\"" + group.Id.ToString() + "\"" + (GroupID==group.Id?" selected":"") + ">" + group.GroupName + "</option>");
              }
              TempLateGroupID.Text = groupHtml.ToString() + "</select>";
                //绑定前必须给总记录数赋值
                Rep_List.DataSource = uk.LoadWhereLambda<Model.Templates>(where.Expression, p => p.OrderByDescending(c => c.ID), PageNum, PageSize, out totalCount).ToList();
                Rep_List.DataBind();
                TotalCount = totalCount;

            }
        }


        public string GetTemplateType(string typeValue)
        {
            switch (int.Parse(typeValue))
            {

                case 0: return "公共模块";
                case 1: return "首页模板";
                case 2: return "列表页模板";
                case 3: return "详细页模板";
                default: return "未知";
            }
        }
    }
}