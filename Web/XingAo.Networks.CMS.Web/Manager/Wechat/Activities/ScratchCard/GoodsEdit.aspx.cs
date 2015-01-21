using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model.DatabaseModel;
using XingAo.Networks.CMS.Web.Common;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Activities.ScratchCard
{
    public partial class GoodsEdit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Action = "Good";
                string sguid = Request.QueryString["SGuid"];
                txtSGuid.Value = sguid;
                int id = Request.QueryString["id"].ObjToInt();
                if (id > 0)
                {
                    txtID.Value = id.ToString();
                    Model.ScratchCard_Goods model = new UnitOfWork().FindSigne<Model.ScratchCard_Goods>(p => p.ID == id && p.ScratchCardGuid == sguid);
                    if (model != null && model.ID > 0)
                    {
                        txtGoodsName.Text = model.GoodsName;
                        txtGoodsCount.Text = model.GoodsCount.ToString();
                        txtUsedCount.Text = model.UsedCount.ToString();
                        txtAllowMob.Text = model.AllowMob;
                        txtGoodsName.Text = model.GoodsName;
                        txtSGuid.Value = model.ScratchCardGuid;
                    }
                    else
                        JUIJsonResult.Err("数据不存在！", "");
                }
            }
        }

    }
}