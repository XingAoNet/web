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
using XingAo.Networks.CMS.Model.Enums;
using XingAo.NetWorks.VerifyPermissions.Utility;
using System.Collections.Specialized;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.TextMaterial
{
    public partial class Main : Common.BaseListPage
    {
        UnitOfWork uk = new UnitOfWork();
        NameValueCollection keyvalue;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IOperatingInfo ioif = new OperatingInfo();
                var mywhere = QueryBuilder.Create<Model.TextMaterial>().Like(c => c.Keys, keyString);
                mywhere = mywhere.Equals(p => p.WGuid, "");
                int r = 0;
                var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.Where(c => c.IsDelete != 1).OrderByDescending(c => c.ID), PageNum, PageSize, out r);
                TotalCount = r;//绑定前必须给总记录数赋值
                string i = ioif.Match.ToString();
                keyvalue = EnumTransform.GetDescriptionAddValue<WeiWebEnum.Matching>();
                var datas = data.Select(c => new { c.IDateTime, c.EditTime, c.Keys, KeyType = keyvalue.AllKeys[(c.KeyType)], c.ReplyContent, c.ID }).ToList();
                Rep_List.DataSource = datas;
                Rep_List.DataBind();
            }
        }
    }
}