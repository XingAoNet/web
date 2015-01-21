﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using System.Linq.Expressions;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.Collect
{
    public partial class Main : Common.BaseListPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var mywhere = QueryBuilder.Create<Model.Collect>()
                   .Like(c => c.Name, keyString);

                int r = 0;
                var data = new UnitOfWork().LoadWhereLambda(mywhere.Expression, p => p.OrderByDescending(c => c.Id), PageNum, PageSize, out r);
                TotalCount = r;//绑定前必须给总记录数赋值
                Rep_List.DataSource = null;
                Rep_List.DataBind();
            }
        }
    }
}