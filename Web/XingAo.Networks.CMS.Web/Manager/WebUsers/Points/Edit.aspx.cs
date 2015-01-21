using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Web.Manager.WebUsers.Points
{
    public partial class Edit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //UnitOfWork uk = new UnitOfWork();
                //int id = Request.QueryString["id"].ObjToInt();
                //if (id > 0)
                //{
                //    txtID.Value = id.ToString();
                //    Model.xxx model = uk.FindSigne<Model.xxx>(p => p.ID == id);
                //    if (model != null && model.ID > 0)
                //    {
                //        // txtxxxx.Text = model.xxxx;                        
                //    }
                //    else
                //        OptionResultJson.Err("数据不存在！", "");
                //}
            }
        }
    }
}