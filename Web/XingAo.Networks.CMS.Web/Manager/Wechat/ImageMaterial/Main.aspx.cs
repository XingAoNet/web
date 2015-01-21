using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Web.Common;
using XingAo.Networks.CMS.Model.DatabaseModel;
using System.Collections.Specialized;
using XingAo.Networks.CMS.Model.Enums;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.ImageMaterial
{
    public partial class Main : Common.BaseListPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Form.Action = Request.GetPath() + "/main?wxid=" + "";
                txtParentID.Items.Add(new ListItem("全部", ""));
                MaterialFamily.Edit.mflists(txtParentID, "");

            }
            UnitOfWork uk = new UnitOfWork();
            string kind = Request["txtParentID"];
            var mywhere = QueryBuilder.Create<Model.ImageMaterial>().Equals(c => c.WGuid, "").Like(c => c.Keys, keyString);
            if (!string.IsNullOrEmpty(kind))
            {
                mywhere = mywhere.Equals(c => c.ParentID, kind.ObjToInt(0));
                txtParentID.SelectedValue = kind;
            }
            int r = 0;
            var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.Where(c => c.IsDelete != 1).OrderByDescending(c => c.ID), PageNum, PageSize, out r);
            NameValueCollection keyvalue = EnumTransform.GetDescriptionAddValue(typeof(WeiWebEnum.Matching));
            TotalCount = r;//绑定前必须给总记录数赋值
            var datas = data.Select(c => new { Name = c.MaterialFamily, c.IDateTime, c.EditTime, c.Keys, KeyType = keyvalue.AllKeys[c.KeyType], c.OrderID, c.Title, c.ID, CurrentUrl = (new Model.SiteConfig().SiteUrl + "/Mobile/Website/Info_Img.aspx?wxid=" + c.WGuid + "&id=" + c.ID + "&title=" + c.Title) }).ToList();
            Rep_List.DataSource = datas;
            Rep_List.DataBind();
        }

        protected string GetMaterialFamily(object Family)
        {
            if (Family == null) return "根目录";
            return ((Model.MaterialFamily)Family).Name;
        }

    }
}