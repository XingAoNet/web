using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model.Enums;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.ScratchCard
{
    public partial class GoodsList : Common.BaseListPage
    {
        public string SGuid { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SGuid =Request.QueryString["SGuid"];
                List<Model.ScratchCard_Goods> data = new UnitOfWork().FindAll<Model.ScratchCard_Goods>().Where(c => c.ScratchCardGuid == SGuid).ToList();
                Rep_List.DataSource = data;
                Rep_List.DataBind();
            }
        }
    }
}