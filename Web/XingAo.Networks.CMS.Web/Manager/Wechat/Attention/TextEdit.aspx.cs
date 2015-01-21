using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model.DatabaseModel;

namespace XingAo.Networks.CMS.Web.Manager.Wechat.Attention
{
    public partial class TextEdit : Common.BaseEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.Attention model = new UnitOfWork().FindAll<Model.Attention>().Where(c => c.Type == 0 && c.WGuid == "").FirstOrDefault();
                if (model != null && model.ID > 0)
                {
                    txtDetailedContent.Text = model.DetailedContent;
                }
            }
        }
    }
}
